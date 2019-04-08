using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfnetTecCsharpCrud.Models
{
    public class PessoaFisica : Pessoa
    {
        [Key]
        public int CodigoPF { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
    }
}