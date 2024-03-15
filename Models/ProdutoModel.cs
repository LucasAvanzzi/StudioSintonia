using System.ComponentModel.DataAnnotations;

namespace StudioSintoniaPreview.Models
{
    public class ProdutoModel
    {
        [Key]
        public int ProdutoModelId { get; set; }
        [MaxLength(500)]
        public string DescricaoId { get; set; }
        public double Valor { get; set; }
        [MaxLength(500)]
        public string Coments { get; set; }
        public string Likes { get; set; }
    }
}
