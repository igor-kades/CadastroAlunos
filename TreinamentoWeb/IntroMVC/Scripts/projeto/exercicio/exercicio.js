/*
 * Define o namespace para objetos e funções JavaScript da tela Home.
 */
Europa.Controllers.Exercicio = {};


$(function () {
    // As funções abaixo são executadas ao carregar a página.
    Europa.Controllers.Exercicio.GetAluno();
});


Europa.Controllers.Exercicio.GetAluno = function () {
    $.get(Europa.Controllers.Exercicio.UrlGetAluno, { id: 1 }, function (res) {
        console.log(res.Objeto)
        $("#form-aluno").html(res.Objeto);
    });
};