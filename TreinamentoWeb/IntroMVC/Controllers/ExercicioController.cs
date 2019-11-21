﻿using TreinamentoWeb.Models;
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
            var aluno = Alunos.FirstOrDefault(x => x.Matricula == mat);

            var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/_FormularioAluno.cshtml", aluno, false);

            if(aluno == null)
            {
                var json = new JsonResponse
                {
                    Campos = new List<string>() { " " },
                    Objeto = alunoHtml,
                    Sucesso = true
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            } else
            {
                var json = new JsonResponse
                {
                    Campos = new List<string>() { aluno.Nome },
                    Objeto = alunoHtml,
                    Sucesso = true
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
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
                Campos = new List<string>() { nome },
                Objeto = alunoHtml,
                Sucesso = true
            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNextAluno(string mat)
        {
            int index = Alunos.FindIndex(x => x.Matricula == mat);
            Aluno aluno;

            if (index < (Alunos.Count - 1))
            {
                aluno = Alunos[++index];
            }
            else
            {
                aluno = Alunos.FirstOrDefault(x => x.Matricula == mat);
            }

            var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/_FormularioAluno.cshtml", aluno, false);

            if (aluno == null)
            {
                var json = new JsonResponse
                {
                    Campos = new List<string>() { " " },
                    Objeto = alunoHtml,
                    Sucesso = true
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var json = new JsonResponse
                {
                    Campos = new List<string>() { aluno.Nome },
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
            Aluno aluno;

            if (index > 0)
            {
                aluno = Alunos[--index];
            }
            else
            {
                aluno = Alunos.FirstOrDefault(x => x.Matricula == mat);                
            }

            var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/_FormularioAluno.cshtml", aluno, false);

            if (aluno == null)
            {
                var json = new JsonResponse
                {
                    Campos = new List<string>() { " " },
                    Objeto = alunoHtml,
                    Sucesso = true
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var json = new JsonResponse
                {
                    Campos = new List<string>() { aluno.Nome },
                    Objeto = alunoHtml,
                    Sucesso = true
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteAluno(string mat)
        {
            int index = Alunos.FindIndex(x => x.Matricula == mat);
            var alunoDelete = Alunos.FirstOrDefault(x => x.Matricula == mat);
            bool deletado = false;
            Aluno aluno;
            
            if (index == 0)
            {
                if(Alunos.Count > 1)
                {
                    aluno = Alunos[1];
                    deletado = true;
                }
                else
                {
                    aluno = null;
                    deletado = true;
                }                
            }
            else 
            {
                if(Alunos.Count == 0)
                {
                    aluno = null;
                    alunoDelete = new Aluno();
                    alunoDelete.Nome = " ";
                }
                else
                {
                    aluno = Alunos[--index];
                    deletado = true;
                }
                
            }

            var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/_FormularioAluno.cshtml", aluno, false);
            Alunos.RemoveAll(x => x.Matricula == mat);

            var json = new JsonResponse
            {
                Campos = new List<string>() { alunoDelete.Nome },
                Objeto = alunoHtml,
                Sucesso = deletado
            };
            return Json(json, JsonRequestBehavior.AllowGet);
            
        }
    }
}