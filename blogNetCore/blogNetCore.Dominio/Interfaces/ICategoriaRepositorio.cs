using System;
using blogNetCore.Dominio.Entidades.Categorias;

namespace blogNetCore.Dominio.Interfaces
{
    public interface ICategoriaRepositorio
    {

        void Inserir(Categoria categoria);
        
        void Alterar(Categoria categoria);
        
        void Excluir(Guid id);
        
        Categoria Procurar(Guid id);

    }
}