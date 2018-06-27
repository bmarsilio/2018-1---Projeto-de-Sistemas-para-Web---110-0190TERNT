using System;
using System.ComponentModel.DataAnnotations;

namespace blogNetCore.Models
{
    public class Post
    {
        [Required]
        public Guid categoria_id { get; set; }
        
        [Required]
        public string titulo { get; set; }

        [Required]
        public string conteudo { get; set; }

        public string resumo { get; set; }

        public string tag { get; set; }
        
        public Guid id { get; set; }

    }
}