using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_MVC_Projeto.Models
{
    public class ProdutoModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Coloque o nome")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Coloque o Valor")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Tipo Do Produto.")]
        public String Tipo_de_Produto { get; set; }

        [Required(ErrorMessage = "Coloque o peso.")]
        public double Peso { get; set; }

        public int? FornecedorID { get; set; }

        public FornecedorModel Fornecedor { get; set; }
    }
}