var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//更改监听端口
builder.WebHost.UseUrls("http://*:8965");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Console.WriteLine(
    "项目使用方法：\n" +
    "Get请求 http://localhost:8965/SendingMail?smtpService=[SMTP服务器]&sendEmail=[发件人邮箱]&sendPwd=[SMTP密码]&port=[SMTP端口，默认为587]&reAddress=[收件人邮箱]&subject=[邮件主题]&body=[邮件内容]\n" +
    "或Post请求 http://localhost:8965/SendingMail Body传入Json格式数据\n" +
    "{\n" +
    "\t\"smtpService\":\"[SMTP服务器]\",\n" +
    "\t\"sendEmail\":\"[发件人邮箱]\",\n" +
    "\t\"sendPwd\":\"[SMTP密码]\",\n" +
    "\t\"port\":[SMTP端口，默认为587],\n" +
    "\t\"reAddress\":\"[收件人邮箱]\",\n" +
    "\t\"subject\":\"[邮件主题]\",\n" +
    "\t\"body\":\"[邮件内容]\"\n" +
    "}");

app.Run();