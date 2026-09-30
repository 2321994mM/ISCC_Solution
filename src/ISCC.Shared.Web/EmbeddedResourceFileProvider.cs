using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Internal;
using Microsoft.Extensions.Primitives;

namespace ISCC.Shared.Web;

/// <summary>
/// Serves files that were embedded in this assembly at build time.
/// </summary>
/// <remarks>
/// <para>
/// Exists because the framework's own <c>ManifestEmbeddedFileProvider</c> needs a
/// hand-maintained <c>Manifest.xml</c> listing every file. That manifest drifts the moment
/// someone adds an asset to <c>wwwroot</c> and forgets it, and the failure mode is a 404
/// at runtime with a clean build. This provider derives the mapping from the real
/// resource names instead, so the set of files it serves is by construction the set of
/// files that exist.
/// </para>
/// <para>
/// Resource names are built by MSBuild as
/// <c>{AssemblyName}.{path with / and . replaced by .}</c>, so
/// <c>wwwroot/iscc-components.js</c> becomes
/// <c>ISCC.Shared.Web.wwwroot.iscc-components.js</c>. The reverse mapping assumes
/// subdirectories only, which is why a file name must not contain a dot-separated path
/// beyond its own extension.
/// </para>
/// </remarks>
internal sealed class EmbeddedResourceFileProvider : IFileProvider
{
    private readonly Assembly _assembly;
    private readonly string _resourcePrefix;
    private readonly IReadOnlyDictionary<string, string> _resources;
    private readonly DateTimeOffset _lastModified;

    /// <summary>
    /// Creates a provider over the embedded resources under a namespace prefix.
    /// </summary>
    /// <param name="assembly">Assembly holding the resources.</param>
    /// <param name="resourcePrefix">
    /// Resource-name prefix to serve, without a trailing dot. For this assembly's
    /// <c>wwwroot</c> that is <c>{AssemblyName}.wwwroot</c>.
    /// </param>
    public EmbeddedResourceFileProvider(Assembly assembly, string resourcePrefix)
    {
        _assembly = assembly;
        _resourcePrefix = resourcePrefix + ".";
        _lastModified = ResolveLastModified(assembly);

        // Built once: IFileProvider is called per request, and Assembly
        // .GetManifestResourceNames() is not cheap enough to call on every lookup.
        _resources = assembly.GetManifestResourceNames()
            .Where(name => name.StartsWith(_resourcePrefix, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(
                name => name.Substring(_resourcePrefix.Length),
                name => name,
                StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>Resource names found, relative to the prefix. Useful when debugging.</summary>
    public IReadOnlyCollection<string> ResourceNames => (IReadOnlyCollection<string>)_resources.Keys;

    /// <summary>
    /// The timestamp reported for every served file.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The assembly's own file time, which is the build that produced these bytes. That
    /// makes the <c>Last-Modified</c> header honest and lets conditional requests work.
    /// </para>
    /// <para>
    /// The fallback cannot be <c>DateTimeOffset.MinValue</c>: StaticFileMiddleware
    /// converts this value to a Win32 FILETIME, and MinValue is outside the representable
    /// range, so it throws <c>ArgumentOutOfRangeException</c> and every static file 500s.
    /// The fallback exists for single-file publishing, where the assembly has no file
    /// behind it.
    /// </para>
    /// </remarks>
    private static DateTimeOffset ResolveLastModified(Assembly assembly)
    {
        var location = assembly.Location;

        if (!string.IsNullOrEmpty(location) && File.Exists(location))
        {
            return new DateTimeOffset(File.GetLastWriteTimeUtc(location), TimeSpan.Zero);
        }

        return new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero);
    }

    /// <inheritdoc />
    public IFileInfo GetFileInfo(string subpath)
    {
        var relative = Normalize(subpath);

        return relative is not null && _resources.TryGetValue(relative, out var resource)
            ? new EmbeddedResourceFileInfo(relative, resource, _assembly, _lastModified)
            : new NotFoundFileInfo(subpath);
    }

    /// <inheritdoc />
    public IDirectoryContents GetDirectoryContents(string subpath)
    {
        var relative = Normalize(subpath);

        if (relative is not null)
        {
            // A request for a directory: only an exact "" prefix (the root) makes sense
            // here, since the shared wwwroot is flat.
            var prefix = relative.Length == 0 ? string.Empty : relative + ".";
            var matches = _resources.Keys
                .Where(key => key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                .Select(key => (IFileInfo)new EmbeddedResourceFileInfo(key, _resources[key], _assembly, _lastModified))
                .ToList();

            return matches.Count > 0
                ? new DirectoryListing(relative, matches)
                : NotFoundDirectoryContents.Singleton;
        }

        return NotFoundDirectoryContents.Singleton;
    }

    /// <inheritdoc />
    /// <remarks>
    /// Always a no-op. These files only change when this assembly is rebuilt, so there is
    /// nothing on disk to watch. A null token is the framework's convention for "this
    /// will never change".
    /// </remarks>
    public IChangeToken Watch(string filter) => NullChangeToken.Singleton;

    /// <summary>
    /// Turns a request path into the matching resource-name suffix, or null when the path
    /// is unusable.
    /// </summary>
    private static string? Normalize(string? subpath)
    {
        if (string.IsNullOrEmpty(subpath)) return string.Empty;

        var trimmed = subpath.TrimStart('/');

        // Reject anything that tries to climb out of the virtual root. The embedded
        // resource namespace cannot be escaped, but a normalized path keeps the lookup
        // from being fooled by a crafted request.
        if (trimmed.Contains("..", StringComparison.Ordinal)) return null;

        return trimmed.Replace('/', '.').Replace('\\', '.');
    }

    /// <summary>An <see cref="IFileInfo"/> over one embedded resource.</summary>
    private sealed class EmbeddedResourceFileInfo : IFileInfo
    {
        private readonly string _resourceName;
        private readonly Assembly _assembly;

        public EmbeddedResourceFileInfo(
            string name,
            string resourceName,
            Assembly assembly,
            DateTimeOffset lastModified)
        {
            Name = name;
            _resourceName = resourceName;
            _assembly = assembly;
            LastModified = lastModified;

            using var stream = OpenRead();
            if (stream is not null)
            {
                Length = stream.Length;
            }
        }

        public string Name { get; }

        public DateTimeOffset LastModified { get; }

        public long Length { get; }

        public bool IsDirectory => false;

        public bool Exists => true;

        public string? PhysicalPath => null;

        public Stream CreateReadStream() =>
            _assembly.GetManifestResourceStream(_resourceName)
            ?? throw new InvalidOperationException(
                $"Embedded resource '{_resourceName}' was listed but cannot be opened.");

        private Stream? OpenRead()
        {
            try
            {
                return CreateReadStream();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }

    /// <summary>
    /// A flat listing. The framework's own in-memory implementation is internal, and
    /// writing the five members is cheaper than working around that.
    /// </summary>
    private sealed class DirectoryListing : IDirectoryContents
    {
        private readonly IEnumerable<IFileInfo> _files;

        public DirectoryListing(string path, IEnumerable<IFileInfo> files)
        {
            Path = path;
            _files = files;
        }

        public bool Exists => true;

        public string Path { get; }

        public IEnumerator<IFileInfo> GetEnumerator() => _files.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
