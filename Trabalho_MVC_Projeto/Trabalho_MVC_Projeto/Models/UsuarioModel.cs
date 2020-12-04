using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_MVC_Projeto.Models
{
    public class UsuarioModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Coloque o usuario.")]
        public String Usuario { get; set; }

        [Required(ErrorMessage = "Coloque a senha.")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Minimo de 8 letras.")]
        public String Senha { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Senha), ErrorMessage = "Senha não confere.")]
        public String ConfirmaSenha { get; set; }

        [Required(ErrorMessage = "Informe o nivel A ou O")]
        public String Nivel { get; set; }
    }
}