using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfnetTecCsharpCrud.Models
{
    public class Pedido
    {
        [Key]
        public int CodigoPedido { get; set; }
        public DateTime DataPedido { get; set; }

        [ForeignKey("Comprador")]
        public int CodigoComprador { get; set; }
        public virtual PessoaFisica Comprador { get; set; }

        [ForeignKey("Vendedor")]
        public int CodigoVendedor { get; set; }
        public virtual PessoaJuridica Vendedor { get; set; }
    }
}