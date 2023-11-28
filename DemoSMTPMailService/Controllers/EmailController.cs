using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSMTPMailService.Models;
using DemoSMTPMailService.Services.EmailService;

namespace DemoSMTPMailService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmailController : ControllerBase
  {
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
      _emailService = emailService;
    }
    [HttpPost]
    public async Task<IActionResult> SendEmailAsync(EmailDto request)
    {
      await _emailService.SendEmailAsync(request);
      return Ok();
    }
  }
}
