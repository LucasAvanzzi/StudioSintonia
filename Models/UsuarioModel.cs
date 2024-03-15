using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StudioSintoniaPreview.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UsuarioModelId { get; set; }

        [MaxLength(100)]
        public string? Nome { get; set; }

        [MaxLength(15)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Celular { get; set; }

        [MaxLength(100)]
        public string Profissao { get; set; }

        public string QuantidadedePost {  get; set; }


    }
}