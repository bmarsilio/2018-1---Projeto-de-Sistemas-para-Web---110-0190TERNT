using System;

namespace Ftec.ProjetoTeste.Web.Models
{
   
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }
        
        public CategoriaProduto Categoria { get; set; }
    }
}