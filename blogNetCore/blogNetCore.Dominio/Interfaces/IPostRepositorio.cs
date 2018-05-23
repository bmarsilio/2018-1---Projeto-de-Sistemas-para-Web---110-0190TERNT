using System;
using blogNetCore.Dominio.Entidades.Posts;

namespace blogNetCore.Dominio.Interfaces
{
    public interface IPostRepositorio
    {

        void Inserir(Post post);
        
        void Alterar(Post post);
        
        void Excluir(Guid id);
        
        Post Procurar(Guid id);

    }
}