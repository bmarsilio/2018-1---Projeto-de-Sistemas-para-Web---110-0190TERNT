﻿using blogNetCore.Models;
using blogNetCore.Aplicacao.Dto;

namespace blogNetCore.Mapping
{
    public class CategoriaMapping
    {
        public static Categoria toModel(CategoriaDto categoriaDto)
        {
            return new Categoria()
            {
                descricao = categoriaDto.descricao,
                id = categoriaDto.id
            };
        }

        public static CategoriaDto toDto(Categoria categoria)
        {
            return new CategoriaDto()
            {
                descricao = categoria.descricao,
                id = categoria.id
            };
        }
    }
}