using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfnetTecCsharpCrud.Models
{
    [DisplayName("Pessoa Física")]
    public class PessoaFisica : Pessoa
    {
        public string CPF { get; set; }
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

    }
}