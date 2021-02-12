using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mail;
namespace covidipedia.front.Pages
{
    public enum Need {
        ServerProblem,
        ConnectorProblem,
        Other
    }

    public class PrivacyModel : PageModel
    {
        //Inner Classes
        public class ContactForm {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public string message { get; set; }
            public Need? need { get; set; }
        }
        

        //Variables
        private readonly ILogger<PrivacyModel> _logger;

        [BindProperty]
        public ContactForm contact {get; set;}


        //Constructor
        public PrivacyModel(ILogger<PrivacyModel> logger) {
            _logger = logger;
        }


        //Methods
        public void OnGet() { }
        public IActionResult OnPost() {
            if (!ModelState.IsValid) return RedirectToPage("Privacy");
            _logger.LogInformation($"A new contact form has been received: {Environment.NewLine}firstName: {contact.firstName}; {Environment.NewLine}lastName: {contact.lastName}; {Environment.NewLine}email: {contact.email}; {Environment.NewLine}need: {contact.need}; {Environment.NewLine}message: {contact.message};");
            SendMail(contact.email,contact.need.ToString(),contact.message,contact.firstName,contact.lastName);
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
}
