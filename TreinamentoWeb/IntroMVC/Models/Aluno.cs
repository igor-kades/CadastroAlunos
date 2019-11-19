using TreinamentoWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinamentoWeb.Models
{
    public class Aluno
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public Situacao Situacao { get; set; }
        public string Cpf { get; set; }
        public string NomeMae { get; set; }
        public Curso Curso { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Observacoes { get; set; }
    }    
}