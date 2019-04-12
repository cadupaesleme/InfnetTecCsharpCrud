using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfnetTecCsharpCrud.Models
{
    public class Produto
    {
        [Key]
        public int CodigoProduto { get; set; }
        public string Nome { get; set; }

        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [ForeignKey("Fornecedor")]
        [DisplayName("Fornecedor")]
        public int CodigoFornecedor { get; set; }
        public virtual PessoaJuridica Fornecedor { get; set; }

        public virtual ICollection<Item> Itens { get; set; }

    }
}