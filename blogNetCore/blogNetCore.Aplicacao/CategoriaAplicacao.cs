using System;
using blogNetCore.Aplicacao.Adapter;
using blogNetCore.Aplicacao.Dto;
using blogNetCore.Dominio.Interfaces;
using blogNetCore.Dominio.Entidades.Categorias;

namespace blogNetCore.Aplicacao
{
    public class CategoriaAplicacao
    {
        private ICategoriaRepositorio categoriaRepositorio;
        
        public CategoriaAplicacao(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public void Insert(CategoriaDto categoriaDto)
        {
            Categoria categoria = CategoriaAdapter.toDomain(categoriaDto);
            
            categoria.id = Guid.NewGuid();
            
            categoriaRepositorio.Inserir(categoria);
        }

    }
}