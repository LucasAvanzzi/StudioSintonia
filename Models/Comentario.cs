using System.ComponentModel.DataAnnotations;

namespace StudioSintoniaPreview.Models
{
    public class Comentario
    {
        [Key]
        public int ComentarioId { get; set; }
        public int UsuarioModelId { get; set; }

        [MaxLength(100)]
        public string UsuarioNome { get; set; }

        public int PostModelId { get; set; }

        [MaxLength(4)]
        public string TipoPostagem { get; set; }
    }
}
