using System.ComponentModel.DataAnnotations;

namespace StudioSintoniaPreview.Models
{
    public class PostModel
    {
        [Key]
        public int PostModelId { get; set; }

        [MaxLength(500)]
        public string Descricao { get; set; }

        [MaxLength (500)]
        public string TipoPostagem { get; set; }
        public byte[] Midia { get; set; } // Armazenamento de mídia
        public int UsuarioId { get; set; }
    }
}
