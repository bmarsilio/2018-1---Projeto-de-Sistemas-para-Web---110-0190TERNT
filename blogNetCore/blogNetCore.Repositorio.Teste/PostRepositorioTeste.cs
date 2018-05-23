using System;
using blogNetCore.Dominio.Entidades.Posts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace blogNetCore.Repositorio.Teste
{
    [TestClass]
    public class PostRepositorioTeste
    {
        [TestMethod]
        public void TesteGravar()
        {
            Post post = new Post()
            {
                id = Guid.NewGuid(),
                categoria_id = new Guid("13fe73b5-08bf-484f-9cbf-738f78426adf"),
                titulo = "titulo do post",
                conteudo = "conteudo do post",
                resumo = "resumo do post",
                tag = "tag do post"
            };

            try
            {
                PostRepositorio postRepositorio = new PostRepositorio("Server=localhost;Database=blogNetCore;Uid=root;Pwd=;SslMode=none");
                postRepositorio.Inserir(post);
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
            /*
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
            */
        }
        
        [TestMethod]
        public void TesteExcluir()
        {
            /*
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
            */
        }
        
        [TestMethod]
        public void TesteProcurar()
        {
            /*
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
            */
        }
    }
}