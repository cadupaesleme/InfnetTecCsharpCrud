using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfnetTecCsharpCrud.Models
{
    public class PessoaJuridica : Pessoa
    {
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CNPJ { get; set; }

        [DisplayName("Ativo")]
        public bool Ativa { get; set; }

        [ForeignKey("CodigoComprador")]
        public virtual ICollection<Pedido> Pedidos { get; set; }

        [ForeignKey("CodigoFornecedor")]
        public virtual ICollection<Produto> Produtos { get; set; }

    }
}