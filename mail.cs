using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Collections;
using System.ComponentModel;

namespace mail
{
    public class Send
    {

        public static int SendMassage(string host, string useraddress,
                                   string userpassword, string sendto, string message)
        //传五个参数
        //打卡结果，打卡成功执行发邮件，打卡失败终止发邮件
        //邮件服务器、发件人地址和密码、收件人地址
        {
            SmtpClient client = new SmtpClient(host, 587);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(useraddress, userpassword);

            string subject = "打卡结果";//邮件标题
            string body = message;//邮件正文

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress(useraddress, "software of check-in");
            msg.To.Add(sendto);

            msg.Subject = subject+message;//邮件标题   
            msg.Body = body;//邮件内容   
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码   
            msg.IsBodyHtml = false;//是否是HTML邮件   
            msg.Priority = MailPriority.Normal;//邮件优先级   

            try
            {
                client.Send(msg);
                return 0;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return 1;
            }
        }
    }

}