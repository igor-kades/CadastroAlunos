using TreinamentoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreinamentoWeb.Controllers
{
    public class ExercicioController : BaseController
    {
        public static List<Aluno> Alunos { get; set; }

        public ExercicioController()
        {
            Alunos = new List<Aluno>();

            var objeto = new Aluno
            {
                Id = 1,
                Nome = "Igor Kades",
                Cpf = "0000000000000"
            };

            Alunos.Add(objeto);
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetAluno(int id)
        {
            // Obtendo a entidade da lista usando LINQ e Lambda
            var aluno = Alunos.FirstOrDefault(x => x.Id == id);

            var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/_FormularioAluno.cshtml", aluno, false);

            var json = new JsonResponse
            {
                Objeto = alunoHtml,
                Sucesso = true
            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}