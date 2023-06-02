using System.Net;
using System.Net.Mail;

namespace SMTPMailSendAPI.Tool;

public class SMTPMail
{
    private readonly MailConfiguration _mailConfiguration; //SMTP服务器

    public SMTPMail(MailConfiguration mailConfiguration)
    {
        _mailConfiguration = mailConfiguration;
    }

    public string Send()
    {
        try
        {
//确定smtp服务器地址 实例化一个Smtp客户端
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Host = _mailConfiguration.smtpService;
            smtpclient.Port = _mailConfiguration.port; //qq邮箱可以不用端口

            //确定发件地址与收件地址
            MailAddress sendAddress = new MailAddress(_mailConfiguration.sendEmail);
            MailAddress receiveAddress = new MailAddress(_mailConfiguration.reAddress);

            //构造一个Email的Message对象 内容信息
            MailMessage mailMessage = new MailMessage(sendAddress, receiveAddress);
            mailMessage.Subject = _mailConfiguration.subject;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = _mailConfiguration.body;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            //邮件发送方式  通过网络发送到smtp服务器
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;

            //如果服务器支持安全连接，则将安全连接设为true
            smtpclient.EnableSsl = true;
            try
            {
                //是否使用默认凭据，若为false，则使用自定义的证书，就是下面的networkCredential实例对象
                smtpclient.UseDefaultCredentials = false;

                //指定邮箱账号和密码,需要注意的是，这个密码是你在QQ邮箱设置里开启服务的时候给你的那个授权码
                NetworkCredential networkCredential =
                    new NetworkCredential(_mailConfiguration.sendEmail, _mailConfiguration.sendPwd);
                smtpclient.Credentials = networkCredential;

                //发送邮件
                smtpclient.Send(mailMessage);
                return "发送成功";
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return "发送失败：" + ex.Message;
            }
        }
        catch (Exception e)
        {
            return "发送失败：" + e.Message;
        }
    }
}

public class MailConfiguration
{
    /// <summary>
    /// SMTP服务器
    /// </summary>
    public string smtpService { get; set; }

    /// <summary>
    /// 发件人邮箱
    /// </summary>
    public string sendEmail { get; set; }

    /// <summary>
    /// SMTP密码
    /// </summary>
    public string sendPwd { get; set; }

    /// <summary>
    /// SMTP端口
    /// </summary>
    public int port { get; set; } = 587;

    /// <summary>
    /// 接收邮件的地址
    /// </summary>
    public string reAddress { get; set; }

    /// <summary>
    /// 邮件主题
    /// </summary>
    public string subject { get; set; }

    /// <summary>
    /// 邮件内容
    /// </summary>
    public string body { get; set; }
}