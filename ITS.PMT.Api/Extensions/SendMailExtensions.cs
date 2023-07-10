using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace ITS.PMT.Api.Extensions
{
    static public partial class Extension
    {
        public static bool SendMail(this IConfiguration configuration, string toMail, string subject, string body, bool isHtml = false, bool ssl = true)
        {
            try
            {
                string fromMail = configuration["Email:Username"];
                string password = configuration["Email:Password"];
                string displayName = configuration["Email:DisplayName"];
                string host = configuration["Email:Host"];
                int port = Convert.ToInt32(configuration["Email:Port"]);

                SmtpClient client = new()
                {
                    Host = host,
                    EnableSsl = ssl,
                    Port = port
                };

                client.Credentials = new NetworkCredential(fromMail, password);

                using (MailMessage message = new MailMessage(new MailAddress(fromMail, displayName), new MailAddress(toMail))
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true

                })
                {
                    client.Send(message);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
