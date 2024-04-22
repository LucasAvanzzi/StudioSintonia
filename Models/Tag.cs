using System.ComponentModel.DataAnnotations;

namespace StudioSintoniaPreview.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [MaxLength(100)]
        public string TagNome { get; set; }

        //relacionamento com PostModel
        public ICollection<PostModel> Postagens { get; set; }

    }
}