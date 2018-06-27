using blogNetCore.Dominio.Entidades.Categorias;
using blogNetCore.Aplicacao.Dto;
using blogNetCore.Dominio.Entidades.Posts;

namespace blogNetCore.Aplicacao.Adapter
{
    public static class PostAdapter
    {

        public static Post toDomain(PostDto postDto)
        {
            return new Post()
            {
                id = postDto.id,
                categoria_id = postDto.categoria_id,
                titulo = postDto.titulo,
                conteudo = postDto.conteudo,
                resumo = postDto.resumo,
                tag = postDto.tag
            };
        }

        public static PostDto toDto(Post post)
        {
            return new PostDto()
            {
                id = post.id,
                categoria_id = post.categoria_id,
                titulo = post.titulo,
                conteudo = post.conteudo,
                resumo = post.resumo,
                tag = post.tag
            };
        }

    }
}