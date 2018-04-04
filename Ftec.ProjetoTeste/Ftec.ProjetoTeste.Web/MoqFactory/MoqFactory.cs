using System.Collections.Generic;
using Ftec.ProjetoTeste.Web.Models;
using RandomTestValues;

namespace Ftec.ProjetoTeste.Web.MoqFactory
{
    public static class MoqFactory
    {
        public static List<Models.Produto> GerarListaProduto(int quantidadeProdutos)
        {
            List<Models.Produto> lista = new List<Produto>();

            lista = RandomTestValues.RandomValue.List<Models.Produto>(new RandomValueSettings(quantidadeProdutos));

            return lista;
        }
        
        public static List<Models.CategoriaProduto> GerarListaCategoriaProduto(int quantidadeCategoriasProdutos)
        {
            List<Models.CategoriaProduto> lista = new List<CategoriaProduto>();

            lista = RandomTestValues.RandomValue.List<Models.CategoriaProduto>(new RandomValueSettings(quantidadeCategoriasProdutos));

            return lista;
        }
    }
}