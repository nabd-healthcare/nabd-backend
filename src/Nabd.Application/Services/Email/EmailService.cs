using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nabd.Shared.Configurations;

namespace Nabd.Application.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(
            IOptions<EmailSettings> emailSettings,
            ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendVerificationOtpAsync(string toEmail, string toName, string otpCode)
        {
            var subject = "Verify Your Email - Nabd";
            var htmlBody = GetVerificationOtpEmailTemplate(toName, otpCode);

            return await SendEmailAsync(toEmail, subject, htmlBody);
        }

        public async Task<bool> SendPasswordResetOtpAsync(string toEmail, string toName, string otpCode)
        {
            var subject = "Reset Your Password - Nabd";
            var htmlBody = GetPasswordResetOtpEmailTemplate(toName, otpCode);

            return await SendEmailAsync(toEmail, subject, htmlBody);
        }

        public async Task<bool> SendWelcomeEmailAsync(string toEmail, string toName)
        {
            var subject = "Welcome to Nabd!";
            var htmlBody = GetWelcomeEmailTemplate(toName);

            return await SendEmailAsync(toEmail, subject, htmlBody);
        }

        public async Task<bool> SendPasswordChangedNotificationAsync(string toEmail, string toName)
        {
            var subject = "Password Changed Successfully - Nabd";
            var htmlBody = GetPasswordChangedEmailTemplate(toName);

            return await SendEmailAsync(toEmail, subject, htmlBody);
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string htmlBody, string? plainTextBody = null)
        {
            try
            {
                using var smtpClient = new SmtpClient(_emailSettings.SmtpHost, _emailSettings.SmtpPort)
                {
                    EnableSsl = _emailSettings.EnableSsl,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword),
                    Timeout = 30000 // 30 seconds
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.FromEmail, _emailSettings.FromName),
                    Subject = subject,
                    Body = htmlBody,
                    IsBodyHtml = true,
                    Priority = MailPriority.Normal
                };

                mailMessage.To.Add(new MailAddress(toEmail));

                // Add plain text alternative if provided
                if (!string.IsNullOrEmpty(plainTextBody))
                {
                    var plainView = AlternateView.CreateAlternateViewFromString(plainTextBody, null, "text/plain");
                    mailMessage.AlternateViews.Add(plainView);
                }

                await smtpClient.SendMailAsync(mailMessage);

                _logger.LogInformation("Email sent successfully to {Email}", toEmail);
                return true;
            }
            catch (SmtpException ex)
            {
                _logger.LogError(ex, "SMTP error sending email to {Email}: {Message}", toEmail, ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error sending email to {Email}: {Message}", toEmail, ex.Message);
                return false;
            }
        }

        #region Email Templates

        private string GetVerificationOtpEmailTemplate(string userName, string otpCode)
        {
            return $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; line-height: 1.6; color: #475569; margin: 0; padding: 0; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #0e7490; color: #ffffff; padding: 40px 20px; text-align: center; border-radius: 12px 12px 0 0; }}
        .header h1 {{ margin: 0; color: #ffffff; font-size: 28px; font-weight: 700; }}
        .header p {{ margin: 10px 0 0; color: #cffafe; font-size: 16px; opacity: 0.9; }}
        .content {{ background-color: #ffffff; padding: 40px 30px; border-radius: 0 0 12px 12px; box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1); border: 1px solid #e2e8f0; border-top: none; }}
        .content h2 {{ color: #1e293b; margin-top: 0; font-size: 22px; }}
        .otp-code {{ font-size: 36px; font-weight: 800; color: #0e7490; letter-spacing: 8px; text-align: center; padding: 24px; background-color: #ecfeff; border-radius: 12px; margin: 30px 0; border: 2px dashed #a5f3fc; }}
        .footer {{ text-align: center; padding: 30px 20px; color: #94a3b8; font-size: 13px; }}
        .warning {{ background-color: #fff1f2; padding: 16px; border-left: 4px solid #f43f5e; margin-top: 30px; border-radius: 6px; color: #881337; }}
        .meta-info {{ color: #64748b; font-size: 14px; margin-top: 10px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🩺 Nabd</h1>
            <p>Email Verification</p>
        </div>
        <div class='content'>
            <h2>Hello {userName},</h2>
            <p>Welcome to Nabd! We're excited to have you on board. Please verify your email address to get started.</p>
            
            <p class='meta-info'>Use the code below to complete your registration:</p>
            
            <div class='otp-code'>{otpCode}</div>
            
            <p>This code is valid for <strong>{_emailSettings.VerificationOtpExpirationMinutes} minutes</strong>.</p>
            
            <div class='warning'>
                <strong>Security Notice:</strong> If you didn't request this code, please ignore this email. No one from Nabd will ever ask for your password or OTP.
            </div>
            
            <p style='margin-top: 30px; border-top: 1px solid #e2e8f0; padding-top: 20px;'>Best regards,<br><strong>The Nabd Team</strong></p>
        </div>
        <div class='footer'>
            <p>© {DateTime.Now.Year} Nabd. All rights reserved.</p>
            <p>This is an automated message, please do not reply directly to this email.</p>
        </div>
    </div>
</body>
</html>";
        }

        private string GetPasswordResetOtpEmailTemplate(string userName, string otpCode)
        {
            return $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; line-height: 1.6; color: #475569; margin: 0; padding: 0; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #1e293b; color: #ffffff; padding: 40px 20px; text-align: center; border-radius: 12px 12px 0 0; }}
        .header h1 {{ margin: 0; color: #ffffff; font-size: 28px; font-weight: 700; }}
        .header p {{ margin: 10px 0 0; color: #e2e8f0; font-size: 16px; opacity: 0.9; }}
        .content {{ background-color: #ffffff; padding: 40px 30px; border-radius: 0 0 12px 12px; box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1); border: 1px solid #e2e8f0; border-top: none; }}
        .content h2 {{ color: #1e293b; margin-top: 0; font-size: 22px; }}
        .otp-code {{ font-size: 36px; font-weight: 800; color: #1e293b; letter-spacing: 8px; text-align: center; padding: 24px; background-color: #f1f5f9; border-radius: 12px; margin: 30px 0; border: 2px dashed #cbd5e1; }}
        .footer {{ text-align: center; padding: 30px 20px; color: #94a3b8; font-size: 13px; }}
        .warning {{ background-color: #fff7ed; padding: 16px; border-left: 4px solid #f97316; margin-top: 30px; border-radius: 6px; color: #9a3412; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🩺 Nabd</h1>
            <p>Password Reset Request</p>
        </div>
        <div class='content'>
            <h2>Hello {userName},</h2>
            <p>We received a request to reset your password. If this was you, please use the code below to proceed:</p>
            
            <div class='otp-code'>{otpCode}</div>
            
            <p>This code expires in <strong>{_emailSettings.PasswordResetOtpExpirationMinutes} minutes</strong>.</p>
            
            <div class='warning'>
                <strong>Did not request this?</strong> If you didn't ask to reset your password, you can safely ignore this email. Your account is secure.
            </div>
            
            <p style='margin-top: 30px; border-top: 1px solid #e2e8f0; padding-top: 20px;'>Best regards,<br><strong>The Nabd Team</strong></p>
        </div>
        <div class='footer'>
            <p>© {DateTime.Now.Year} Nabd. All rights reserved.</p>
        </div>
    </div>
</body>
</html>";
        }

        private string GetWelcomeEmailTemplate(string userName)
        {
             return $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; line-height: 1.6; color: #475569; margin: 0; padding: 0; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #0e7490; color: #ffffff; padding: 40px 20px; text-align: center; border-radius: 12px 12px 0 0; }}
        .header h1 {{ margin: 0; color: #ffffff; font-size: 28px; font-weight: 700; }}
        .content {{ background-color: #ffffff; padding: 40px 30px; border-radius: 0 0 12px 12px; box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1); border: 1px solid #e2e8f0; border-top: none; }}
        .footer {{ text-align: center; padding: 30px 20px; color: #94a3b8; font-size: 13px; }}
        .cta-button {{ display: inline-block; padding: 14px 32px; background-color: #0e7490; color: #ffffff; text-decoration: none; border-radius: 8px; margin-top: 20px; font-weight: 600; text-align: center; }}
        .cta-button:hover {{ background-color: #155e75; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🎉 Welcome to Nabd!</h1>
        </div>
        <div class='content'>
            <h2>Hello {userName},</h2>
            <p>Your account has been successfully verified! We're thrilled to have you join the Nabd community.</p>
            
            <p>You now have access to:</p>
            <ul style='color: #334155;'>
                <li>Smart AI-powered diagnosis assistance</li>
                <li>Digital medical prescriptions</li>
                <li>Secure patient history management</li>
            </ul>
            
            <div style='text-align: center;'>
                <a href='{_emailSettings.ApplicationBaseUrl}' class='cta-button'>Go to Dashboard</a>
            </div>
            
            <p style='margin-top: 40px; border-top: 1px solid #e2e8f0; padding-top: 20px;'>Best regards,<br><strong>The Nabd Team</strong></p>
        </div>
        <div class='footer'>
            <p>© {DateTime.Now.Year} Nabd. All rights reserved.</p>
        </div>
    </div>
</body>
</html>";
        }

        private string GetPasswordChangedEmailTemplate(string userName)
        {
            return $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; line-height: 1.6; color: #475569; margin: 0; padding: 0; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #0e7490; color: #ffffff; padding: 40px 20px; text-align: center; border-radius: 12px 12px 0 0; }}
        .header h1 {{ margin: 0; color: #ffffff; font-size: 28px; font-weight: 700; }}
        .content {{ background-color: #ffffff; padding: 40px 30px; border-radius: 0 0 12px 12px; box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1); border: 1px solid #e2e8f0; border-top: none; }}
        .footer {{ text-align: center; padding: 30px 20px; color: #94a3b8; font-size: 13px; }}
        .warning {{ background-color: #f0f9ff; padding: 16px; border-left: 4px solid #0ea5e9; margin-top: 30px; border-radius: 6px; color: #0369a1; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Password Changed</h1>
        </div>
        <div class='content'>
            <h2>Hello {userName},</h2>
            <p>This email is to confirm that your password was changed on <strong>{DateTime.UtcNow:MMMM dd, yyyy 'at' HH:mm} UTC</strong>.</p>
            
            <div class='warning'>
                <strong>Didn't do this?</strong><br>
                If you did not authorize this change, please contact support immediately to secure your account.
            </div>
            
            <p style='margin-top: 30px; border-top: 1px solid #e2e8f0; padding-top: 20px;'>Best regards,<br><strong>The Nabd Team</strong></p>
        </div>
        <div class='footer'>
            <p>© {DateTime.Now.Year} Nabd. All rights reserved.</p>
        </div>
    </div>
</body>
</html>";
        }
        #endregion
    }
}