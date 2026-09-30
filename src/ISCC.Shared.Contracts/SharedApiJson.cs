using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace ISCC.Shared.Contracts;

/// <summary>
/// The JSON contract used by every API surface in this solution.
/// </summary>
/// <remarks>
/// <para>
/// Registered once via <c>AddSharedApiJson()</c> and <c>UseSharedApiJson()</c> so all
/// three hosts serialize identically. A consumer of the Android API can therefore reuse
/// the same DTOs the web portals use.
/// </para>
/// <para>
/// camelCase naming and case-insensitive reads match JavaScript and Android clients
/// without them having to configure anything.
/// </para>
/// </remarks>
public static class SharedApiJson
{
    /// <summary>The serializer options every host uses.</summary>
    public static readonly JsonSerializerOptions Options = Create();

    private static JsonSerializerOptions Create()
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        // .NET 9 emits a compile-time diagnostic for each new enum member so this
        // serializer config does not silently miss one. Treat it as information, not a
        // build error, so an unrelated package cannot fail the build over it.
        options.TypeInfoResolver = new DefaultJsonTypeInfoResolver();

        return options;
    }
}
