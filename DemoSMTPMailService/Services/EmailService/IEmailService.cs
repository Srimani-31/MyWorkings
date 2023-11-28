using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSMTPMailService.Models;

namespace DemoSMTPMailService.Services.EmailService
{
  public interface IEmailService
  {
    public Task SendEmailAsync(EmailDto emailDto);
  }
}
