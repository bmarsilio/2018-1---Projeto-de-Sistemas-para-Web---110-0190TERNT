using System;
using System.Collections.Generic;
using blogNetCore.Filtro;
using blogNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using blogNetCore.Aplicacao;
using blogNetCore.Mapping;
using blogNetCore.Repositorio;
using blogNetCore.Aplicacao.Dto;
using Microsoft.Extensions.Configuration;

namespace blogNetCore.Controllers
{
    [FiltroAcesso]
    public class CategoriaController : Controller
    {
        private readonly IConfiguration configuration;

        public CategoriaController(IConfiguration config)
        {
            this.configuration = config;
        }

        public IActionResult Index()
        {
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(this.configuration.GetConnectionString("default"));
            CategoriaAplicacao categoriaAplicacao = new CategoriaAplicacao(categoriaRepositorio);

            var categoriaDtos = categoriaAplicacao.Listar();

            List<Categoria> categorias = new List<Categoria>();
            foreach (var categoria in categoriaDtos)
            {
                categorias.Add(CategoriaMapping.toModel(categoria));
            }
            
            ViewData["title"] = "Categorias";

            ViewData["categorias"] = categorias;
            
            return View();
        }
        
        public IActionResult Create()
        {
            ViewData["title"] = "Nova Categoria";
            
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Categoria categoria)
        {
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(this.configuration.GetConnectionString("default"));
            CategoriaAplicacao categoriaAplicacao = new CategoriaAplicacao(categoriaRepositorio);

            CategoriaDto categoriaDto = CategoriaMapping.toDto(categoria);
            
            categoriaAplicacao.Insert(categoriaDto);

            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(Guid id)
        {
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(this.configuration.GetConnectionString("default"));
            CategoriaAplicacao categoriaAplicacao = new CategoriaAplicacao(categoriaRepositorio);

            var categegoriaDto = categoriaAplicacao.Procurar(id);

            var categoria = CategoriaMapping.toModel(categegoriaDto);
            
            ViewData["title"] = "Edição Categoria";

            ViewData["categoria"] = categoria;
            
            return View();
        }
        
        [HttpPost]
        public IActionResult Update(Categoria categoria)
        {
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(this.configuration.GetConnectionString("default"));
            CategoriaAplicacao categoriaAplicacao = new CategoriaAplicacao(categoriaRepositorio);

            CategoriaDto categoriaDto = CategoriaMapping.toDto(categoria);
            
            categoriaAplicacao.Update(categoriaDto);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(String id)
        {
            CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio(this.configuration.GetConnectionString("default"));
            CategoriaAplicacao categoriaAplicacao = new CategoriaAplicacao(categoriaRepositorio);
            
            categoriaAplicacao.Delete(Guid.Parse(id));

            return RedirectToAction("Index");
        }
    }
}