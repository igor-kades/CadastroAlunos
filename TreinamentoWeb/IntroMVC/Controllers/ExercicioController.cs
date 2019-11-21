using TreinamentoWeb.Models;
using TreinamentoWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreinamentoWeb.Controllers
{
    public class ExercicioController : BaseController
    {
        public static List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public ExercicioController()
        {            
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetAluno(string mat)
        {
            // Obtendo a entidade da lista usando LINQ e Lambda
            var aluno = Alunos.FirstOrDefault(x => x.Matricula == mat);

            var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/_FormularioAluno.cshtml", aluno, false);

            var json = new JsonResponse
            {
                Objeto = alunoHtml,
                Sucesso = true
            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CadastrarAluno(string nome, string mat, int situacao, string cpf, string nomeMae, int curso, string dataNascimento, string obs)
        {

            var aluno = new Aluno
            {
                Nome = nome,
                Matricula = mat,
                SituacaoAluno = (Situacao)situacao,
                Cpf = cpf,
                NomeMae = nomeMae,
                CursoAluno = (Curso)curso,
                DataNascimento = DateTime.Parse(dataNascimento),
                Observacoes = obs          
            };
            Alunos.Add(aluno);
            var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/_FormularioAluno.cshtml", aluno, false);            

            var json = new JsonResponse
            {
                Objeto = alunoHtml,
                Sucesso = true
            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNextAluno(string mat)
        {
            int index = Alunos.FindIndex(x => x.Matricula == mat);
            
            
            
            if(index < (Alunos.Count - 1))
            {
                var aluno = Alunos[++index];
                var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/_FormularioAluno.cshtml", aluno, false);

                var json = new JsonResponse
                {
                    Objeto = alunoHtml,
                    Sucesso = true
                };

                return Json(json, JsonRequestBehavior.AllowGet);

            } else
            {
                var alunoAtual = Alunos.FirstOrDefault(x => x.Matricula == mat);
                var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/_FormularioAluno.cshtml", alunoAtual, false);

                var json = new JsonResponse
                {
                    Objeto = alunoHtml,
                    Sucesso = true
                };

                return Json(json, JsonRequestBehavior.AllowGet);
            }

            

            
        }

        [HttpGet]
        public JsonResult GetPreviousAluno(string mat)
        {
            int index = Alunos.FindIndex(x => x.Matricula == mat);



            if (index > 0)
            {
                var aluno = Alunos[--index];
                var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/_FormularioAluno.cshtml", aluno, false);

                var json = new JsonResponse
                {
                    Objeto = alunoHtml,
                    Sucesso = true
                };

                return Json(json, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var alunoAtual = Alunos.FirstOrDefault(x => x.Matricula == mat);
                var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/_FormularioAluno.cshtml", alunoAtual, false);

                var json = new JsonResponse
                {
                    Objeto = alunoHtml,
                    Sucesso = true
                };

                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
    }
}