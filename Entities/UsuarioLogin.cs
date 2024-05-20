using System.ComponentModel.DataAnnotations;
namespace StudioSintoniaPreview.Entities

{
    public class UsuarioLogin
    {
        public int UsuarioLoginId { get; set; }

        [Required, MaxLength(80, ErrorMessage = "Nome não pode exceder 80 caracteres")]
        public string? UsuarioNome { get; set; }

        [EmailAddress]
        [Required, MaxLength(120)]
        public string? UsuarioEmail { get; set; }

        [Required, MaxLength(14)]
        public  decimal? Celular { get; set; }
    }
}
