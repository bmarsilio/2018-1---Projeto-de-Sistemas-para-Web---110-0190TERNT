using System;
using blogNetCore.Dominio.Entidades.Posts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace blogNetCore.Repositorio.Teste
{
    [TestClass]
    public class PostRepositorioTeste
    {
        private String server;
        private String database;
        private String uid;
        private String pwd;
        private String sslmode;
        
        public PostRepositorioTeste()
        {
            this.server = "localhost";
            this.database = "blogNetCore";
            this.uid = "root";
            this.pwd = "";
            this.sslmode = "none";
        }

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
                PostRepositorio postRepositorio = new PostRepositorio("Server="+this.server+";Database="+this.database+";Uid="+this.uid+";Pwd="+this.pwd+";SslMode="+this.sslmode+"");
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
            Post post = new Post();

            post.id = new Guid("a758d194-7a19-408e-81e8-c146fe19d1d6");
            post.categoria_id = new Guid("ccdb5c4b-4a00-47d6-8921-000243470fb5");
            post.titulo = "titulo do post 1";
            post.conteudo = "conteudo do post 1";
            post.resumo = "resumo do post 1";
            post.tag = "tag do post 1";

            try
            {
                PostRepositorio postRepositorio = new PostRepositorio("Server="+this.server+";Database="+this.database+";Uid="+this.uid+";Pwd="+this.pwd+";SslMode="+this.sslmode+"");
                postRepositorio.Alterar(post);
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
            Guid id = new Guid("a758d194-7a19-408e-81e8-c146fe19d1d6");

            try
            {
                PostRepositorio postRepositorio = new PostRepositorio("Server="+this.server+";Database="+this.database+";Uid="+this.uid+";Pwd="+this.pwd+";SslMode="+this.sslmode+"");
                postRepositorio.Excluir(id);
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
            Guid id = new Guid("0b427809-e104-4226-913f-2d7acfb33a9a");

            try
            {
                PostRepositorio postRepositorio = new PostRepositorio("Server="+this.server+";Database="+this.database+";Uid="+this.uid+";Pwd="+this.pwd+";SslMode="+this.sslmode+"");
                postRepositorio.Procurar(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}