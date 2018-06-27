using System;

namespace blogNetCore.Aplicacao.Dto
{
    public class PostDto
    {
        public Guid id { get; set; }
        
        public Guid categoria_id { get; set; }
        
        public String titulo { get; set; }
        
        public String conteudo { get; set; }
        
        public String resumo { get; set; }
        
        public String tag { get; set; }
    }
}