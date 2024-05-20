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
        public int TagId { get; set; }
        public int UsuarioModelId { get; set; }

        [MaxLength(4)]
        public string? Conteudo { get; set; }
        [MaxLength(200)]
        public string? Descricao { get; set; }

        public int Curtidas { get; set; }

        [Precision(18,2)]
        public decimal Valor { get; set; }

        // Relacionamentos
        public ICollection<Comentario>? Comentarios { get; set; }
        public ICollection<Tag>? Tags { get; set; }

       // [ForeignKey("UsuarioModelId")]
        public virtual UsuarioModel? UsuarioModel { get; set; }
    }
}
