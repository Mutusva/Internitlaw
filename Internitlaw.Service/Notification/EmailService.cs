using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Mail;
using Internitlaw.Domain.Models;

namespace Internitlaw.Service.Notification
{
	public class EmailService : IEmailService
	{
		private readonly ILogger<EmailService> _logger;
		private readonly IConfiguration _configuration;
		public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		public void sendEmail(string toAddress, string subject)
		{
			try
			{
				var htmlBody = "<h4>Hello there</h4>";
				EmailTask(toAddress, subject, htmlBody);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}
		}

		private void EmailTask(string toAddress, string username, string body)
		{
			BackgroundJob.Enqueue(() => Send(toAddress, username, body));
		}
		private void Send(string toAddress,  string subject, string body)
		{
			MailMessage mail = new MailMessage();
			var settingsSection = _configuration.GetSection("SMTPSettings");
			var smtpModel = settingsSection.Get<SmtpModel>();

			SmtpClient client = new SmtpClient(smtpModel.Server);

			mail.From = new MailAddress(smtpModel.MailAddress);
			mail.To.Add(toAddress);
			mail.Subject = subject;

			mail.IsBodyHtml = true;

			var htmlBody = body;

			mail.Body = htmlBody;

			//client.Port = 587;
			client.Credentials = new System.Net.NetworkCredential(smtpModel.Username, smtpModel.Password);
			client.EnableSsl = true;

			client.Send(mail);
		}
	}
}
