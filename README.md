# SMTPMailSendAPI

项目使用方法：
Get请求 http://localhost:8965/SendingMail?smtpService=[SMTP服务器]&sendEmail=[发件人邮箱]&sendPwd=[SMTP密码]&port=[SMTP端口，默认为587]&reAddress=[收件人邮箱]&subject=[邮件主题]&body=[邮件内容]
或Post请求 http://localhost:8965/SendingMail Body传入Json格式数据
{
"smtpService":"[SMTP服务器]",
"sendEmail":"[发件人邮箱]",
"sendPwd":"[SMTP密码]",
"port":[SMTP端口，默认为587],
"reAddress":"[收件人邮箱]",
"subject":"[邮件主题]",
"body":"[邮件内容]"
}
