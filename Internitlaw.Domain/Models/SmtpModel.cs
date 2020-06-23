using System;
using System.Collections.Generic;
using System.Text;

namespace Internitlaw.Domain.Models
{
	public class SmtpModel
	{
		public string Server { get; set; }
		public string MailAddress { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
