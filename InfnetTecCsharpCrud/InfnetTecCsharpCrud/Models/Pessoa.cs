using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfnetTecCsharpCrud.Models
{
    public class Pessoa
    {
        [Key]
        public int CodigoPessoa { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
    }
}