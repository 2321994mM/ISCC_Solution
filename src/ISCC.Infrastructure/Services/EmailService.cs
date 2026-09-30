using ISCC.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace ISCC.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }

    public Task SendEmailAsync(string to, string subject, string body, CancellationToken cancellationToken = default)
    {
        // TODO: Integrate with actual SMTP server or email provider
        _logger.LogInformation("Email to: {To}, Subject: {Subject}", to, subject);
        return Task.CompletedTask;
    }
}
