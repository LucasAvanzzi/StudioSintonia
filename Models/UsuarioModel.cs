﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StudioSintoniaPreview.Models
{
    public class UsuarioModel
    {
        //[Key]
        public int UsuarioModelId { get; set; }

        //FK
        public int ProfissaoModelId { get; set; }



        public string? UsuarioFoto { get; set; }

        [MaxLength(100)]
        public string? Nome { get; set; }

        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [MaxLength(14)]
        public string? Celular { get; set; }

        [MaxLength(200)]
        public string? UsuarioBio { get; set; }

        [MaxLength(100)]
        public string? UsuarioProfissaoNome { get; set; }

        // Relacionamento com Postagem
        public ICollection<PostModel>? Postagens { get; set; }

        [ForeignKey("ProfissaoModelId")]
        public virtual ProfissaoModel? ProfissaoModel { get; set; }

    }
}