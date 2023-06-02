using Microsoft.AspNetCore.Mvc;
using SMTPMailSendAPI.Tool;

namespace SMTPMailSendAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SendingMail : ControllerBase
{
    [HttpGet]
    public async Task<string> SendGet([FromQuery] MailConfiguration mailConfiguration)
    {
        SMTPMail _SMTPMail = new SMTPMail(mailConfiguration);
        return await Task.Run(() => _SMTPMail.Send());
    }

    [HttpPost]
    public async Task<string> SendPost([FromBody] MailConfiguration mailConfiguration)
    {
        SMTPMail _SMTPMail = new SMTPMail(mailConfiguration);
        return await Task.Run(() => _SMTPMail.Send());
    }
}