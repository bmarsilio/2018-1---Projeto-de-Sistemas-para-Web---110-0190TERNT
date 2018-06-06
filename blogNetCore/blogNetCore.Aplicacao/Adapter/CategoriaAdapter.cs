using blogNetCore.Dominio.Entidades.Categorias;
using blogNetCore.Aplicacao.Dto;

namespace blogNetCore.Aplicacao.Adapter
{
    public static class CategoriaAdapter
    {

        public static Categoria toDomain(CategoriaDto categoriaDto)
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