using System.ComponentModel.DataAnnotations;

namespace StudioSintoniaPreview.Models
{
    public class ProfissaoModel
    {
        //[Key]
        public int ProfissaoModelId { get; set; }
        public string? ProfissaoNome { get; set; }
        public virtual ICollection<UsuarioModel>? UsuariosModel { get; set; }
    }
}
