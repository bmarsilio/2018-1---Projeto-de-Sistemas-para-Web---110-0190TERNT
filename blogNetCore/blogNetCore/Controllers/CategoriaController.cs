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
            ViewData["title"] = "Categorias";
            
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

            return View("Index");
        }
        
        public IActionResult Edit()
        {
            ViewData["title"] = "Edição Categoria";
            
            return View();
        }
    }
}