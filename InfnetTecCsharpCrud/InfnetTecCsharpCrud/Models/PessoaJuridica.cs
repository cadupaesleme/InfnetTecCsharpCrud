using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfnetTecCsharpCrud.Models
{
    public class PessoaJuridica : Pessoa
    {
        [Key]
        public int CodigoPJ { get; set; }
        public string CNPJ { get; set; }
        public bool Ativa { get; set; }
    }
}