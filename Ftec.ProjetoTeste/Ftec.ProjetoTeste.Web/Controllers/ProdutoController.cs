using System;
using System.Collections.Generic;
using Ftec.ProjetoTeste.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetoTeste.Web.Controllers
{
    public class ProdutoController : Controller
    {
        // GET
        public IActionResult Index()
        {
            List<Produto> produtos;

            produtos = MoqFactory.MoqFactory.GerarListaProduto(15);

            ViewBag.Produtos = produtos;
            
            return View();
        }
        
        public IActionResult Formulario()
        {
            var categorias = this.getCategoriaProdutos();

            ViewBag.Categorias = categorias;       
            
            return View();
        }
        
        [HttpPost]
        public IActionResult Adiciona(Models.Produto produto)
        {
            // Processamento da gravação

            return RedirectToAction("Index");
        }

        public IActionResult Altera(string produtoId)
        {
            ViewBag.ProdutoId = produtoId;

            var categorias = this.getCategoriaProdutos();

            ViewBag.Categorias = categorias; 
            
            return View();
        }

        private List<CategoriaProduto> getCategoriaProdutos()
        {
            List<CategoriaProduto> categorias;

            categorias = MoqFactory.MoqFactory.GerarListaCategoriaProduto(10);

            return categorias;
        }
    }
}