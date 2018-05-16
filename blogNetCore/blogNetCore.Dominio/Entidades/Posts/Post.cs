using System;
using System.ComponentModel.DataAnnotations;

namespace blogNetCore.Dominio.Entidades.Posts
{
    public class Post
    {
        public Guid id { get; set; }
        
        [Required]
        public int categoria_id { get; set; }
        
        [Required]
        public string titulo { get; set; }

        [Required]
        public string conteudo { get; set; }

        public string resumo { get; set; }

        public string tag { get; set; }

    }
}