using Azure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudioSintoniaPreview.Models
{
    public class PostModel
    {
        //[Key]
        public int PostModelId { get; set; }

        //FK
        [ForeignKey("TagId")]
        public int TagId { get; set; }
        public string? UsuarioModelId { get; set; }


        [MaxLength(500)]
        public string? Conteudo { get; set; }
        [MaxLength(200)]
        public string? Descricao { get; set; }
        [NotMapped]
        public IFormFile? MetaDadosImagem { get; set; }

        public int Curtidas { get; set; }

        public bool Curtido { get; set; }

        [Precision(18,2)]
        public decimal Valor { get; set; }

        // Relacionamentos
        public ICollection<Comentario>? Comentarios { get; set; }
        public ICollection<Tag>? Tags { get; set; }

    }
}
