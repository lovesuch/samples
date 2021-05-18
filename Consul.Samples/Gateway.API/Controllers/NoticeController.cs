using System.Text;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Notice()
        {
            var bytes = new byte[10240];
            var i = Request.Body.ReadAsync(bytes, 0, bytes.Length);
            var content = Encoding.UTF8.GetString(bytes).Trim('\0');
            SendEmail(content);
            return Ok("ok");
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="content"></param>
        private void SendEmail(string content)
        {
            try
            {
                dynamic list = JsonConvert.DeserializeObject(content);
                if (list != null && list.Count > 0)
                {
                    var emailBody = new StringBuilder("健康检查故障:\r\n");
                    foreach (var noticy in list)
                    {
                        emailBody.AppendLine("--------------------------------------");
                        emailBody.AppendLine($"Node:{noticy.Node}");
                        emailBody.AppendLine($"Service ID:{noticy.ServiceID}");
                        emailBody.AppendLine($"Service Name:{noticy.ServiceName}");
                        emailBody.AppendLine($"Check ID:{noticy.CheckID}");
                        emailBody.AppendLine($"Check Name:{noticy.Name}");
                        emailBody.AppendLine($"Check Status:{noticy.Status}");
                        emailBody.AppendLine($"Check Output:{noticy.Output}");
                        emailBody.AppendLine("--------------------------------------");
                    }

                    var message = new MimeMessage();
                    // 这里只是是测试邮箱，请不要发垃圾邮件，谢谢
                    message.From.Add(new MailboxAddress("lovesuch", "lovesuch@163.com"));
                    message.To.Add(new MailboxAddress("398282040", "398282040@qq.com"));

                    message.Subject = "作业报警";
                    message.Body = new TextPart("plain") {Text = emailBody.ToString()};
                    using var client = new SmtpClient {ServerCertificateValidationCallback = (s, c, h, e) => true};
                    client.Connect("smtp.163.com", 25, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("lovesuch", "@dmin530.mail");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch
            {
            }
        }
    }
}