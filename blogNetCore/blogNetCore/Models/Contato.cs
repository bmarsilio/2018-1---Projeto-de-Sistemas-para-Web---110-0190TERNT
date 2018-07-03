using System.ComponentModel.DataAnnotations;

namespace blogNetCore.Models
{
    public class Contato
    {
        [Required]
        public string name { get; set; }
        
        [Required]
        public string email { get; set; }
        
        [Required]
        public string phone { get; set; }
        
        [Required]
        public string message { get; set; }

    }
}