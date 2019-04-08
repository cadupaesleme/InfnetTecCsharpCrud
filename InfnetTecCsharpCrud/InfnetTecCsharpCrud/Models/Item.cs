using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfnetTecCsharpCrud.Models
{
    public class Item
    {
        [Key]
        public int CodigoItem { get; set; }
        public int Qtd { get; set; }
        public decimal ValorUnitario { get; set; }

        [ForeignKey("Pedido")]
        public int CodigoPedido { get; set; }
        public virtual Pedido Pedido { get; set; }

        [ForeignKey("Produto")]
        public int CodigoProduto { get; set; }
        public virtual Produto Produto { get; set; }

    }
}