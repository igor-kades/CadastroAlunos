Europa.Controllers.Exercicio = {};

$(function () {
    Europa.Controllers.Exercicio.GetAluno();
});

Europa.Controllers.Exercicio.GetAluno = function () {
    $.get(Europa.Controllers.Exercicio.UrlGetAluno, { id: 1 }, function (res) {
        console.log(res.Objeto)
        $("#form-aluno").html(res.Objeto);
    });
};