using System;
using blogNetCore.Dominio.Entidades.Categorias;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace blogNetCore.Repositorio.Teste
{
    [TestClass]
    public class CategoriaRepositorioTeste
    {
        private String server;
        private String database;
        private String uid;
        private String pwd;
        private String sslmode;
        
        public CategoriaRepositorioTeste()
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
            Categoria categoria = new Categoria()
            {
                id = Guid.NewGuid(),
                descricao = "categoria"
            };

            try
            {
                CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio("Server="+this.server+";Database="+this.database+";Uid="+this.uid+";Pwd="+this.pwd+";SslMode="+this.sslmode+"");
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

            categoria.id = new Guid("d26a1b32-40bf-4d52-8765-f4d9292d868f");
            categoria.descricao = "categoria 1";

            try
            {
                CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio("Server="+this.server+";Database="+this.database+";Uid="+this.uid+";Pwd="+this.pwd+";SslMode="+this.sslmode+"");
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
                CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio("Server="+this.server+";Database="+this.database+";Uid="+this.uid+";Pwd="+this.pwd+";SslMode="+this.sslmode+"");
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
                CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio("Server="+this.server+";Database="+this.database+";Uid="+this.uid+";Pwd="+this.pwd+";SslMode="+this.sslmode+"");
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