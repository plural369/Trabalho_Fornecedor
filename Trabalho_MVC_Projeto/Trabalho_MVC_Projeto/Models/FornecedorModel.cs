using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trabalho_MVC_Projeto.Models
{
    public class FornecedorModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Coloque um nome.")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Coloque o cnpj.")]
        public String Cnpj { get; set; }

        [Required(ErrorMessage = "Coloque o Telefone.")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Coloque um produto.")]
        public String Produto { get; set; }

        public virtual ICollection<ProdutoModel> Produtos { get; set; }
    }
}