using TreinamentoWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinamentoWeb.Models
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public Situacao SituacaoAluno { get; set; }
        public string Cpf { get; set; }
        public string NomeMae { get; set; }
        public Curso CursoAluno { get; set; }
        public DateTime DataNascimento { get; set; } = new DateTime();
        public string Observacoes { get; set; }
    }    
}