using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using blogNetCore.Aplicacao;
using blogNetCore.Mapping;
using Microsoft.AspNetCore.Mvc;
using blogNetCore.Models;
using blogNetCore.Repositorio;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace blogNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration config)
        {
            this.configuration = config;
        }
        
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            ViewBag.titulo = "Blog .NET Core";
            ViewBag.subtitulo = "Home";
            ViewBag.imagemFundo = "home-bg.jpg";
            
            PostRepositorio postRepositorio = new PostRepositorio(this.configuration.GetConnectionString("default"));
            PostAplicacao postAplicacao = new PostAplicacao(postRepositorio);

            var postDtos = postAplicacao.Listar();

            List<Post> posts = new List<Post>();
            foreach (var post in postDtos)
            {
                posts.Add(PostMapping.toModel(post));
            }
            
            ViewData["posts"] = posts;
            
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
        
        public IActionResult Post(Guid id)
        {
            PostRepositorio postRepositorio = new PostRepositorio(this.configuration.GetConnectionString("default"));
            PostAplicacao postAplicacao = new PostAplicacao(postRepositorio);

            var postDto = postAplicacao.Procurar(id);

            var post = PostMapping.toModel(postDto);
            
            ViewData["title"] = post.titulo;
            ViewBag.titulo = post.titulo;
            ViewBag.subtitulo = post.resumo;
            ViewBag.imagemFundo = "post-bg.jpg";
            
            ViewData["post"] = post;
            
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}