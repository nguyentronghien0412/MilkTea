using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataObject;
using System.Xml;

namespace Utilities
{
    public class MailManagement
    {
        public static bool IsValidEmail(string EmailAddress)
        {
            if (!EmailAddress.Contains("@") || !EmailAddress.Contains("."))
                return false;

            var regex = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            //var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.IsMatch(EmailAddress, regex, RegexOptions.IgnoreCase);
        }

        public static string SendMail_GoogleSMTP(dtoMailMessage Msg)
        {
            try
            {
                #region Load SmtpGoogle

                string vHost = Parameters.Definition.SMTP_GG_HOST;
                int vPort = int.Parse(Parameters.Definition.SMTP_GG_PORT);

                bool vEnableSsl = false;
                if (Parameters.Definition.SMTP_GG_SSL == "ON")
                    vEnableSsl = true;

                bool vUseDefaultCredentials = false;
                if (Parameters.Definition.SMTP_GG_CREDENTIALS == "ON")
                    vUseDefaultCredentials = true;

                SmtpDeliveryMethod vDeliveryMethod = SmtpDeliveryMethod.Network;
                if (Parameters.Definition.SMTP_GG_METHOD == "System.Net.Mail.SmtpDeliveryMethod.Network")
                    vDeliveryMethod = SmtpDeliveryMethod.Network;

                string vCredentials_UserName = Parameters.Definition.SMTP_GG_USERNAME;
                string vCredentials_Password = Parameters.Definition.SMTP_GG_PASSWORD;

                #endregion

                SmtpClient vSmtpServer = new SmtpClient
                {
                    Host = vHost,
                    Port = vPort,
                    EnableSsl = vEnableSsl,
                    UseDefaultCredentials = vUseDefaultCredentials,
                    DeliveryMethod = vDeliveryMethod,
                    Credentials = new NetworkCredential(vCredentials_UserName, vCredentials_Password)
                };

                MailMessage vMessage = new MailMessage();
                vMessage.From = new MailAddress(vCredentials_UserName);

                if (Msg.EmailTo != null && Msg.EmailTo.Count > 0)
                    foreach (string email in Msg.EmailTo)
                        vMessage.To.Add(new MailAddress(email));

                if (Msg.CC != null && Msg.CC.Count > 0)
                    foreach (string cc in Msg.CC)
                        vMessage.CC.Add(new MailAddress(cc));

                if (Msg.BCC != null && Msg.BCC.Count > 0)
                    foreach (string bcc in Msg.BCC)
                        vMessage.Bcc.Add(new MailAddress(bcc));

                vMessage.Subject = Msg.Subject;
                vMessage.Body = Msg.Body;
                vMessage.IsBodyHtml = Msg.IsBodyHtml;

                MemoryStream ms = null;
                if (Msg.AttachFiles != null && Msg.AttachFiles.Rows.Count > 0)
                {
                    foreach (DataRow dr in Msg.AttachFiles.Rows)
                    {
                        ms = new MemoryStream(File.ReadAllBytes(dr["FilePath"].ToString()));
                        vMessage.Attachments.Add(new System.Net.Mail.Attachment(ms, dr["FileName"].ToString()));
                    }
                }

                vSmtpServer.Send(vMessage);
                vMessage.Dispose();

                if (ms != null)
                {
                    ms.Close();
                    ms.Dispose();
                }

                return "@@SUCCESS@@";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
