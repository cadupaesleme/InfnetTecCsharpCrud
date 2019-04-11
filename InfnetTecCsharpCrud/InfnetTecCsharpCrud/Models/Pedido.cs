﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfnetTecCsharpCrud.Models
{
    public class Pedido
    {
        [Key]
        [DisplayName("Código Pedido")]
        public int CodigoPedido { get; set; }

        [DisplayName("Data Pedido")]
        public DateTime DataPedido { get; set; }

        [ForeignKey("Comprador")]
        [DisplayName("Cliente")]
        public int CodigoComprador { get; set; }
        public virtual PessoaFisica Comprador { get; set; }

        [ForeignKey("Vendedor")]
        [DisplayName("Fornecedor")]
        public int CodigoVendedor { get; set; }
        public virtual PessoaJuridica Vendedor { get; set; }
    }
}