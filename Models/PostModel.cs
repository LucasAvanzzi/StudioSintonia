using Azure;
using System.ComponentModel.DataAnnotations;

namespace StudioSintoniaPreview.Models
{
    public class PostModel
    {
        [Key]
        public int PostModelId { get; set; }
        [MaxLength(4)]
        public string TipoPostagem { get; set; }
        [MaxLength(4)]
        public string Conteudo { get; set; }
        [MaxLength(200)]
        public string Descricao { get; set; }

        public int Curtidas { get; set; }

        public decimal Valor { get; set; }

        // Relacionamento com Comentário
        public ICollection<Comentario> Comentarios { get; set; }

        // Relacionamento com Tag
        public ICollection<Tag> Tags { get; set; }
    }
}
