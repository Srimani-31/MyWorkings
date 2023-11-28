using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSMTPMailService.Models
{
  public class EmailDto
  {
    public EmailDto()
    {
      From = "srimaniofficial31102002@gmail.com";
      Password = "nopdjywqtzmcqyfq";
      To = "nr383619@gmail.com";
      Subject = "Congrats! On Cracking our interview";
      Body = "Welcome to Accenture family!\nOne of the most popular IT Service & Consulting in tech industry\nWe will react to you shortly with offer letter!";
    }
    public string From { get; set; } 
    public string Password { get; set; }
    public string To { get; set; } 
    public string Subject { get; set; } 
    public string Body { get; set; }
  }
}
