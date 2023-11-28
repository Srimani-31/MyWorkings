using DemoSMTPMailService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace DemoSMTPMailService.Services.EmailService
{
  public class EmailService : IEmailService
  {
    public Task SendEmailAsync(EmailDto emailDto)
    {
      emailDto = emailDto.From == "string" ? new EmailDto() : emailDto;

      //create and configure the smtp client
      SmtpClient client = new SmtpClient("smtp.gmail.com")
      {
        Port = 587,
        Credentials = new NetworkCredential(emailDto.From, emailDto.Password),
        UseDefaultCredentials = false,
        EnableSsl = true
      };

      //creating email message
      MailMessage mailMessage = new MailMessage
      {
        From = new MailAddress(emailDto.From),
        Subject = emailDto.Subject,
        Body = emailDto.Body,
        IsBodyHtml = false
      };

      //sending email
      mailMessage.To.Add(emailDto.To);

      //send the email
      return client.SendMailAsync(mailMessage);
    }
  }
}
