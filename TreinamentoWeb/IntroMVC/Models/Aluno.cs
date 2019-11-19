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
        public enum Situacao { Ativo = 1, Suspenso = 2, Cancelado = 3 }
        public string Cpf { get; set; }
        public string NomeMae { get; set; }
        public enum Curso { SistemasDeInformação = 1, CienciaDaComputacao = 2, Medicina = 3, Direito = 4, EngenhariaCivil = 5 }
        public DateTime DataNascimento { get; set; }
        public string Observacoes { get; set; }
    }    
}