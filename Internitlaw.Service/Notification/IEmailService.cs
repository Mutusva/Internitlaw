using System;
using System.Collections.Generic;
using System.Text;

namespace Internitlaw.Service.Notification
{
	public interface IEmailService
	{
		void sendEmail(string toAddress, string subject);
	}
}
