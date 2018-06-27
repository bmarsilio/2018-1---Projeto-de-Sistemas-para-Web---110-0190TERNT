using System;
using System.Collections.Generic;
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

        public List<CategoriaDto> Listar()
        {
            var categorias = categoriaRepositorio.Listar();
            
            List<CategoriaDto> categoriaDtos = new List<CategoriaDto>();

            foreach (var categoria in categorias)
            {
                categoriaDtos.Add(CategoriaAdapter.toDto(categoria));
            }

            return categoriaDtos;
        }
        
        public CategoriaDto Procurar(Guid id)
        {
            var categoria = categoriaRepositorio.Procurar(id);

            var categoriaDto = CategoriaAdapter.toDto(categoria);
            
            return categoriaDto;
        }

        public void Update(CategoriaDto categoriaDto)
        {
            Categoria categoria = CategoriaAdapter.toDomain(categoriaDto);
            
            categoriaRepositorio.Alterar(categoria);
        }

        public void Delete(Guid id)
        {
            categoriaRepositorio.Excluir(id);
        }

    }
}