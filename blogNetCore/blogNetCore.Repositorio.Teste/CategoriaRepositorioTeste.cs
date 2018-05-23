using System;
using blogNetCore.Dominio.Entidades.Categorias;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace blogNetCore.Repositorio.Teste
{
    [TestClass]
    public class CategoriaRepositorioTeste
    {
        [TestMethod]
        public void TesteGravar()
        {
            Categoria categoria = new Categoria()
            {
                id = Guid.NewGuid(),
                descricao = "salame"
            };

            try
            {
                CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio("Server=localhost;Database=blogNetCore;Uid=root;Pwd=;SslMode=none");
                categoriaRepositorio.Inserir(categoria);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [TestMethod]
        public void TesteAlterar()
        {
            Categoria categoria = new Categoria();

            categoria.id = new Guid("1334470b-9a8b-4cb3-b267-78156175bf89");
            categoria.descricao = "salame 1";

            try
            {
                CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio("Server=localhost;Database=blogNetCore;Uid=root;Pwd=;SslMode=none");
                categoriaRepositorio.Alterar(categoria);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [TestMethod]
        public void TesteExcluir()
        {
           Guid id = new Guid("1334470b-9a8b-4cb3-b267-78156175bf89");

            try
            {
                CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio("Server=localhost;Database=blogNetCore;Uid=root;Pwd=;SslMode=none");
                categoriaRepositorio.Excluir(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [TestMethod]
        public void TesteProcurar()
        {
            Guid id = new Guid("13fe73b5-08bf-484f-9cbf-738f78426adf");

            try
            {
                CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio("Server=localhost;Database=blogNetCore;Uid=root;Pwd=;SslMode=none");
                categoriaRepositorio.Procurar(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}