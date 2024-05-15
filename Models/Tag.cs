using System.ComponentModel.DataAnnotations;

namespace StudioSintoniaPreview.Models
{
    public class Tag
    {
        //[Key]
        public int TagId { get; set; }

        //FK
        public int PostModelId { get; set; }

        [MaxLength(100)]
        public string? TagNome { get; set; }

        //relacionamento com PostModel
        public virtual ICollection<PostModel>? Postagens { get; set; }

    }
}