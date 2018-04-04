using System;
using System.Collections.Generic;
using Ftec.ProjetoTeste.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ftec.ProjetoTeste.Web.Controllers
{
    public class CategoriaController : Controller
    {
        // GET
        public IActionResult Index()
        {
            const string sessionKey = "categorias";
            
            var value = HttpContext.Session.GetString(sessionKey);
            if (string.IsNullOrEmpty(value))
            {
                List<Models.CategoriaProduto> lista = new List<CategoriaProduto>();
                
                ViewBag.Categorias = lista;
            }
            else
            {
                List<Models.CategoriaProduto> lista;
                
                lista = JsonConvert.DeserializeObject<List<Models.CategoriaProduto>>(value);
                
                ViewBag.Categorias = lista;
            }
            
            return View();
        }
        
        public IActionResult Formulario()
        {            
            return View();
        }
        
        [HttpPost]
        public IActionResult Adiciona(Models.CategoriaProduto categoriaProduto)
        {
            const string sessionKey = "categorias";
            
            var value = HttpContext.Session.GetString(sessionKey);
            if (string.IsNullOrEmpty(value))
            {
                List<Models.CategoriaProduto> lista = new List<CategoriaProduto>();

                categoriaProduto.Id = Guid.NewGuid();
                
                lista.Add(categoriaProduto);
                
                var serialisedCategoria = JsonConvert.SerializeObject(lista);
                HttpContext.Session.SetString(sessionKey, serialisedCategoria);
            }
            else
            {
                List<Models.CategoriaProduto> listaCategoria;
                
                listaCategoria = JsonConvert.DeserializeObject<List<Models.CategoriaProduto>>(value);
                categoriaProduto.Id = Guid.NewGuid();
                
                listaCategoria.Add(categoriaProduto);
                
                var serialisedCategoria = JsonConvert.SerializeObject(listaCategoria);
                HttpContext.Session.SetString(sessionKey, serialisedCategoria);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Altera(string categoriaId)
        {
            ViewBag.CategoriaId = categoriaId;
                        
            return View();
        }

        [HttpPost]
        public IActionResult AlteraCategoria(Models.CategoriaProduto categoriaProduto)
        {
            const string sessionKey = "categorias";
            
            var value = HttpContext.Session.GetString(sessionKey);
            
            List<Models.CategoriaProduto> listaCategoria;
                
            listaCategoria = JsonConvert.DeserializeObject<List<Models.CategoriaProduto>>(value);

            foreach (CategoriaProduto categoria in listaCategoria)
            {
                if (categoria.Id.Equals(categoriaProduto.Id))
                {
                    categoria.Id = categoriaProduto.Id;
                    categoria.Descricao = categoriaProduto.Descricao;
                }
            }
            
            var serialisedCategoria = JsonConvert.SerializeObject(listaCategoria);
            HttpContext.Session.SetString(sessionKey, serialisedCategoria);
            
            return RedirectToAction("Index");
        }
        
        public IActionResult Exclui(string categoriaId)
        {
            const string sessionKey = "categorias";
            
            var value = HttpContext.Session.GetString(sessionKey);
            
            List<Models.CategoriaProduto> listaCategoria;
                
            listaCategoria = JsonConvert.DeserializeObject<List<Models.CategoriaProduto>>(value);

            var posicaoExclui = 0;
            foreach (CategoriaProduto categoria in listaCategoria)
            {
                if (categoria.Id.ToString().Equals(categoriaId))
                {
                    posicaoExclui = listaCategoria.IndexOf(categoria); 
                }
            }
            
            listaCategoria.RemoveAt(posicaoExclui);  
            
            var serialisedCategoria = JsonConvert.SerializeObject(listaCategoria);
            HttpContext.Session.SetString(sessionKey, serialisedCategoria);
            
            return RedirectToAction("Index");
        }
    }
}