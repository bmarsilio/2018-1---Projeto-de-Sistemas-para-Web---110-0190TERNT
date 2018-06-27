using System;
using System.ComponentModel.DataAnnotations;

namespace blogNetCore.Models
{
    public class Categoria
    {
        [Required]
        public string descricao { get; set; }

        public Guid id { get; set; }

    }
}