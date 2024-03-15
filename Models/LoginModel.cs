using System.ComponentModel.DataAnnotations;

namespace StudioSintoniaPreview.Models
{
    public class LoginModel
    {
        [Key]
        public int LoginModelId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
