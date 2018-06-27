using blogNetCore.Models;
using blogNetCore.Aplicacao.Dto;

namespace blogNetCore.Mapping
{
    public class PostMapping
    {
        public static Post toModel(PostDto postDto)
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