﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudioSintoniaPreview.Models
{
    public class Comentario
    {
       // [Key]
        public int ComentarioId { get; set; }
        //FK
        public string UsuarioModelId { get; set; }
        public int PostModelId { get; set; }

        [MaxLength(100)]
        public string? UsuarioNome { get; set; }

        //[ForeignKey("PostModelId")]
        public virtual PostModel? PostModel { get; set; }

    }
}
