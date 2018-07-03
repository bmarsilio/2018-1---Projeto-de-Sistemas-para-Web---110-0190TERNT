using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blogNetCore.Models;
using MimeKit;

namespace blogNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            ViewBag.subtitulo = "Home";
            ViewBag.imagemFundo = "home-bg.jpg";
            
            return View();
        }
        
        public IActionResult Sobre()
        {
            ViewData["title"] = "Sobre";
            ViewBag.subtitulo = "Sobre";
            ViewBag.imagemFundo = "about-bg.jpg";
            
            return View();
        }
        
        public IActionResult Contato()
        {
            ViewData["title"] = "Contato";
            ViewBag.subtitulo = "Contato";
            ViewBag.imagemFundo = "contact-bg.jpg";
            
            return View();
        }
        
        [HttpPost]
        public IActionResult SendContato(Contato contato)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("blogdotnetcore@gmail.com", "Bnc@147852");
 
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("blogdotnetcore@gmail.com");
            mailMessage.To.Add("bruno.marsilio@gmail.com");
            mailMessage.Body = " nome: " + contato.name + "\n email: " + contato.email + "\n telefone: " + contato.phone + "\n mensagem: " + contato.message;
            mailMessage.Subject = "Contato Blog Net Core";
            client.Send(mailMessage);

            return RedirectToAction("Contato");
        }
        
        public IActionResult Post()
        {
            ViewData["title"] = "Post";
            ViewBag.subtitulo = "Post 123";
            ViewBag.imagemFundo = "post-bg.jpg";
            
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}