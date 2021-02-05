using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Net.Mail;
namespace covidipedia.front.Pages
{
    [BindProperties]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public Need? Need { get; set; }
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return RedirectToPage("Privacy");
            Console.WriteLine($"firstName {FirstName}");
            Console.WriteLine($"lastName {LastName}");
            Console.WriteLine($"email {Email}");
            Console.WriteLine($"need {Need}");
            Console.WriteLine($"message {Message}");
            Console.WriteLine("Mail send");
            SendMail(Email,Need.ToString(),Message,FirstName,LastName);
            return Page();
        }

        public void SendMail(string mailContact, string subject, string content, string firstName, string lastName)
        {
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "covidipedia@gmail.com",
                    Password="6/EeC3g.4"
                };
                smtp.Credentials=credential;
                smtp.Host= "smtp.gmail.com";
                smtp.Port = 587;
                smtp.DeliveryMethod=SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                var message = new MailMessage
                {
                    Body =firstName+" "+lastName+" contactable à cette adresse : "+mailContact+" <br><br>"+ content,
                    Subject = subject,
                    From = new MailAddress(credential.UserName),
                    IsBodyHtml=true
                };
                message.To.Add("covidipedia@gmail.com");
                smtp.Send(message);
            }
        }
    }

    public enum Need
    {
        ServerProblem,
        ConnectorProblem
    }
}
