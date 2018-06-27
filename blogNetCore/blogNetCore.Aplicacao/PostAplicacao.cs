using System;
using System.Collections.Generic;
using blogNetCore.Aplicacao.Adapter;
using blogNetCore.Aplicacao.Dto;
using blogNetCore.Dominio.Interfaces;
using blogNetCore.Dominio.Entidades.Categorias;
using blogNetCore.Dominio.Entidades.Posts;

namespace blogNetCore.Aplicacao
{
    public class PostAplicacao
    {
        private IPostRepositorio postRepositorio;
        
        public PostAplicacao(IPostRepositorio postRepositorio)
        {
            this.postRepositorio = postRepositorio;
        }

        public void Insert(PostDto postDto)
        {
            Post post = PostAdapter.toDomain(postDto);
            
            post.id = Guid.NewGuid();
            
            postRepositorio.Inserir(post);
        }

        public List<PostDto> Listar()
        {
            var posts = postRepositorio.Listar();
            
            List<PostDto> postDtos = new List<PostDto>();

            foreach (var post in posts)
            {
                postDtos.Add(PostAdapter.toDto(post));
            }

            return postDtos;
        }
        
        public PostDto Procurar(Guid id)
        {
            var post = postRepositorio.Procurar(id);

            var postDto = PostAdapter.toDto(post);
            
            return postDto;
        }

        public void Update(PostDto postDto)
        {
            Post post = PostAdapter.toDomain(postDto);
            
            postRepositorio.Alterar(post);
        }

        public void Delete(Guid id)
        {
            postRepositorio.Excluir(id);
        }

    }
}