using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfnetTecCsharpCrud.Models
{
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ { get; set; }
        [DisplayName("Ativo")]
        public bool Ativa { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

    }
}