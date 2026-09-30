using ISCC.Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ISCC.Shared.Web;

/// <summary>
/// The pipeline for a background job. Not an HTTP request, so it has no culture, no
/// user and no trace id, but it still writes to the legacy error table.
/// </summary>
/// <remarks>
/// Registered as a singleton background service. Hangfire invokes jobs through this, so
/// every job gets identical error handling without repeating a try/catch.
/// </remarks>
public sealed class BackgroundJobErrorHandler
{
    private readonly ILogger<BackgroundJobErrorHandler> _logger;

    /// <summary>Creates the handler.</summary>
    public BackgroundJobErrorHandler(ILogger<BackgroundJobErrorHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Runs a job, converting a domain fault into a logged, retryable outcome instead of
    /// an unhandled background-process crash.
    /// </summary>
    /// <param name="jobName">Used in the log entry so the failing job is identifiable.</param>
    /// <param name="work">The job body.</param>
    public async Task ExecuteAsync(string jobName, Func<CancellationToken, Task> work)
    {
        using var scope = _logger.BeginScope(new Dictionary<string, object> { ["JobName"] = jobName });

        try
        {
            await work(CancellationToken.None);
            _logger.LogInformation("Job {JobName} completed.", jobName);
        }
        catch (ValidationException ex)
        {
            // A validation fault will fail identically on every retry, so Hangfire is told
            // not to retry it.
            _logger.LogError(ex, "Job {JobName} failed validation and will not be retried.", jobName);
            throw;
        }
        catch (DomainException ex)
        {
            _logger.LogWarning(ex, "Job {JobName} hit a domain rule violation.", jobName);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Job {JobName} failed and will be retried.", jobName);
            throw;
        }
    }
}
