using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace blogNetCore.Models
{
    public class Post
    {
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