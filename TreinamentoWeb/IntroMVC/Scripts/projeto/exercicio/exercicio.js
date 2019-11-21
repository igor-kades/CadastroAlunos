Europa.Controllers.Exercicio = {};

$(function () {
    Europa.Controllers.Exercicio.GetAluno();

    SetMask()

    $("#submit").click(function () {
        var fill = true

        $(".formItem").each(function () {

            if ($(this).is("select")) {
                if ($(this).find(":selected").text() == "") {
                    fill = false
                    $(this).parentsUntil('div.row', ".col-input").addClass('has-error')
                } else {
                    if ($(this).parentsUntil('div.row', ".col-input").hasClass('has-error')) {
                        $(this).parentsUntil('div.row', ".col-input").removeClass('has-error')
                    }
                }
            } else if (EmptyElement($(this))) {
                fill = false
                $(this).parentsUntil('div.row', ".col-input").addClass('has-error')
            } else {
                if ($(this).parentsUntil('div.row', ".col-input").hasClass('has-error')) {
                    $(this).parentsUntil('div.row', ".col-input").removeClass('has-error')
                }
            }
        })

        if (!fill) {
            if (!$("p").hasClass('text-danger')) {
                $(".modal-body").append(`<div class="row alert-fill"><p class="text-danger col-md-offset-1"></p></div>`)
                $(".text-danger").append(`Todos os campos devem ser preenchidos`)
            }
        } else {
            Europa.Controllers.Exercicio.CadastrarAluno()
            Clear()
        }
    })

    $("#cancel").click(function () {
        Clear()
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
        $("#modalCadastroAluno").modal("hide")
        $("#modal-confirm .col-md-22").empty()
        $("#modal-confirm .col-md-22").append(`O aluno <strong>${}</strong> foi salvo com sucesso.`)
        $("#modal-confirm").modal('show')
        $("#form-aluno").html(res.Objeto);
    })
}

Europa.Controllers.Exercicio.NextAluno = function () {
    $.get(Europa.Controllers.Exercicio.UrlNextAluno, { mat: $("#Matricula").val() }, function (res) {
        console.log(res.Objeto)
        $("#form-aluno").html(res.Objeto);
    })
}

Europa.Controllers.Exercicio.PreviousAluno = function () {
    $.get(Europa.Controllers.Exercicio.UrlPreviousAluno, { mat: $("#Matricula").val() } , function (res) {
        $("#form-aluno").html(res.Objeto);
    })
}

function SetMask() {
    $('#cpfAluno').mask('000.000.000-00')
    $('#dataNascAluno').mask('00/00/0000')
}

function EmptyElement(obj) {
    if (obj.val() === '') {
        return true
    }
    if (obj.val() === null) {
        return true
    }
    return false
}

function Clear() {
    $("form").trigger("reset")

    $('.text-danger').parentsUntil(".modal-body", ".alert-fill").remove()

    $('.formItem').each(function () {
        if ($(this).parentsUntil('div.row', ".col-input").hasClass('has-error')) {
            $(this).parentsUntil('div.row', ".col-input").removeClass('has-error')
        }
    })
}