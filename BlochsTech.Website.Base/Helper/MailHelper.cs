using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace BlochsTech.Website.Base.Helper
{
    /// <summary>
    ///  Send mail helper class.
    /// </summary>
    public static class MailHelper
    {
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="sendTo">The send to.</param>
        /// <param name="payPalLink">The PayPal link.</param>
        public static void SendEmail(string name, string sendTo, string payPalLink)
        {
            string senderAddress = ConfigurationManager.AppSettings["smtpUser"];
            string password = ConfigurationManager.AppSettings["smtpPass"];
            var loginInfo = new NetworkCredential(senderAddress, password);
            var msg = new MailMessage();

            var smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"], Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]))
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = loginInfo
            };

            try
            {
                msg.From = new MailAddress(senderAddress);
                msg.To.Add(new MailAddress(sendTo));
                msg.Subject = ConfigurationManager.AppSettings["SubjectEmail"];
                msg.Body = string.Format(ConfigurationManager.AppSettings["BodyEmail"], name, payPalLink);
                msg.IsBodyHtml = true;
                smtpClient.Send(msg);

            }
            catch (Exception e)
            {
                Bootstrap.Log.Error("Error send email message to : {0}\n Error message: {1}\n Stack Trace: {2}", sendTo, e.Message, e.StackTrace);
            }

        }

    }
}