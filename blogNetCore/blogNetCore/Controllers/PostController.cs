using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using blogNetCore.Aplicacao;
using blogNetCore.Aplicacao.Dto;
using blogNetCore.Filtro;
using blogNetCore.Mapping;
using Microsoft.AspNetCore.Mvc;
using blogNetCore.Models;
using blogNetCore.Repositorio;
using Microsoft.Extensions.Configuration;

namespace blogNetCore.Controllers
{
    [FiltroAcesso]
    public class PostController : Controller
    {
        private readonly IConfiguration configuration;

        public PostController(IConfiguration config)
        {
            this.configuration = config;
        }
        
        public IActionResult Index()
        {
            PostRepositorio postRepositorio = new PostRepositorio(this.configuration.GetConnectionString("default"));
            PostAplicacao postAplicacao = new PostAplicacao(postRepositorio);

            var postDtos = postAplicacao.Listar();

            List<Post> posts = new List<Post>();
            foreach (var post in postDtos)
            {
                posts.Add(PostMapping.toModel(post));
            }
            
            ViewData["title"] = "Posts";

            ViewData["posts"] = posts;
            
            return View();
        }
        
        public IActionResult Create()
        {
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(this.configuration.GetConnectionString("default"));
            CategoriaAplicacao categoriaAplicacao = new CategoriaAplicacao(categoriaRepositorio);

            var categoriaDtos = categoriaAplicacao.Listar();

            List<Categoria> categorias = new List<Categoria>();
            foreach (var categoria in categoriaDtos)
            {
                categorias.Add(CategoriaMapping.toModel(categoria));
            }
            
            ViewData["title"] = "Novo Post";
            
            ViewData["categorias"] = categorias;
            
            return View();
        }
        
        [HttpPost]
        public IActionResult Insert(Post post)
        {
            PostRepositorio postRepositorio = new PostRepositorio(this.configuration.GetConnectionString("default"));
            PostAplicacao postAplicacao = new PostAplicacao(postRepositorio);

            PostDto postDto = PostMapping.toDto(post);
            
            postAplicacao.Insert(postDto);

            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(Guid id)
        {
            PostRepositorio postRepositorio = new PostRepositorio(this.configuration.GetConnectionString("default"));
            PostAplicacao postAplicacao = new PostAplicacao(postRepositorio);

            var postDto = postAplicacao.Procurar(id);

            var post = PostMapping.toModel(postDto);
            
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(this.configuration.GetConnectionString("default"));
            CategoriaAplicacao categoriaAplicacao = new CategoriaAplicacao(categoriaRepositorio);

            var categoriaDtos = categoriaAplicacao.Listar();

            List<Categoria> categorias = new List<Categoria>();
            foreach (var categoria in categoriaDtos)
            {
                categorias.Add(CategoriaMapping.toModel(categoria));
            }
            
            ViewData["title"] = "Edição Post";
            
            ViewData["post"] = post;
            ViewData["categorias"] = categorias;
            
            return View();
        }
        
        [HttpPost]
        public IActionResult Update(Post post)
        {
            PostRepositorio postRepositorio = new PostRepositorio(this.configuration.GetConnectionString("default"));
            PostAplicacao postAplicacao = new PostAplicacao(postRepositorio);

            PostDto postDto = PostMapping.toDto(post);
            
            postAplicacao.Update(postDto);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(String id)
        {
            PostRepositorio postRepositorio = new PostRepositorio(this.configuration.GetConnectionString("default"));
            PostAplicacao postAplicacao = new PostAplicacao(postRepositorio);
            
            postAplicacao.Delete(Guid.Parse(id));

            return RedirectToAction("Index");
        }
    }
}