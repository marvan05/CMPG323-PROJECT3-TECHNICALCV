using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TECHNICALCV.Models;

namespace TECHNICALCV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult WorkExperience()
        {   
            return View();
        }

        public IActionResult Education()
        {
            return View();
        }

        public IActionResult Skills()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(SendMailDto sendMailDto)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                MailMessage mail = new MailMessage();
                // you need to enter your email address
                mail.From = new MailAddress("marlenevanrensburg123@gmail.com");

                // To Email Address - you need to enter your to email address
                mail.To.Add("marlenevanrensburg123@gmail.com");

                mail.Subject = sendMailDto.Subject;

                // Add BC and CC email addresses
                mail.CC.Add("11946237@nwu.ac.za");
                mail.Bcc.Add("marlenevanrensburg123@gmail.com");

                mail.IsBodyHtml = true;

                string content = "Name : " + sendMailDto.Name;
                content += "<br/> Surname : " + sendMailDto.Surname;
                content += "<br/> Email : " + sendMailDto.Email;
                content += "<br/> Cell Phone : " + sendMailDto.Phone; 
                content += "<br/> Message : " + sendMailDto.Message;

                mail.Body = content;

                //Create SMTP instant

                //You need to pass mail server address and you can also specify the port number if you required
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                //Create network credential and you need to give from email address and password
                NetworkCredential networkCredential = new NetworkCredential("marlenevanrensburg123@gmail.com", "#passwordforemail#");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587; //This is default port number.  You can also change this
                smtpClient.EnableSsl = true; //If ssl required you need to enable it
                smtpClient.Send(mail);

                ViewBag.Message = "Thank you! Email Send.";

                //Create the from
                ModelState.Clear();
            }


            catch (Exception ex)
            {
                //If any error occured it will show
                ViewBag.Message = ex.Message.ToString();
            }


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
