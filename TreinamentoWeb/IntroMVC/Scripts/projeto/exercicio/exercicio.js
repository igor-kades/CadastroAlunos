Europa.Controllers.Exercicio = {};

$(function () {
    Europa.Controllers.Exercicio.GetAluno();

    SetMask()

    $("#submit").click(function () {
        Europa.Controllers.Exercicio.CadastrarAluno()
    })

    $("#nextAluno").click(function () {
        Europa.Controllers.Exercicio.NextAluno()
    })

    $("#previousAluno").click(function () {
        Europa.Controllers.Exercicio.PreviousAluno()
    })
});

Europa.Controllers.Exercicio.GetAluno = function () {
    $.get(Europa.Controllers.Exercicio.UrlGetAluno, function (res) {
        $("#form-aluno").html(res.Objeto);
    });
};

Europa.Controllers.Exercicio.CadastrarAluno = function () {
    data = {
        nome: $("#nomeAluno").val(),
        mat: $("#matriculaAluno").val(),
        situacao: $("#situacaoAluno").children("option:selected").val(),
        cpf: $("#cpfAluno").val(),
        nomeMae: $("#nomeMae").val(),
        curso: $("#cursoAluno").children("option:selected").val(),
        dataNascimento: $("#dataNascAluno").val(),
        obs: $("#observacoes").val()
    }

    $.post(Europa.Controllers.Exercicio.UrlCadastrarAluno, data, function (res) {
        $("#form-aluno").html(res.Objeto);
    })
}

Europa.Controllers.Exercicio.NextAluno = function () {
    $.get(Europa.Controllers.Exercicio.UrlNextAluno, { mat: $("#matriculaAluno").val() }, function (res) {
        console.log(res.Objeto)
        $("#form-aluno").html(res.Objeto);
    })
}

Europa.Controllers.Exercicio.PreviousAluno = function () {
    $.get(Europa.Controllers.Exercicio.UrlPreviousAluno, { mat: $("#matriculaAluno").val() } , function (res) {
        $("#form-aluno").html(res.Objeto);
    })
}

function SetMask() {
    $('#cpfAluno').mask('000.000.000-00')
    $('#dataNascAluno').mask('00/00/0000')
}
