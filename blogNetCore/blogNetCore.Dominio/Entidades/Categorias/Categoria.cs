using System;
using System.ComponentModel.DataAnnotations;

namespace blogNetCore.Dominio.Entidades.Categorias
{
    public class Categoria
    {
        public Guid id { get; set; }
        
        [Required]
        public string descricao { get; set; }

    }
}