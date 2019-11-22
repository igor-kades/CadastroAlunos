Europa.Controllers.Exercicio = {}

$(function () {
    Europa.Controllers.Exercicio.GetAluno()
    SetMask()

    $("#submit").click(function () {
        var fill = true

        $(".formItem").each(function () {
            var element = $(this).parentsUntil('div.row', ".col-input")

            if ($(this).is("select")) {
                if ($(this).find(":selected").text() == "") {
                    fill = false
                    element.addClass('has-error')
                } else {
                    if (element.hasClass('has-error')) {
                        element.removeClass('has-error')
                    }
                }
            } else if (EmptyElement($(this))) {
                fill = false
                element.addClass('has-error')
            } else {
                if (element.hasClass('has-error'))
                    element.removeClass('has-error')
            }
        })

        if (!fill) {
            setTextAlert()
        } else {
            Europa.Controllers.Exercicio.CadastrarAluno()
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

    $("#deleteAluno").click(function () {
        Europa.Controllers.Exercicio.DeleteAluno()
    })
})

Europa.Controllers.Exercicio.GetAluno = function () {
    $.get(Europa.Controllers.Exercicio.UrlGetAluno, function (res) {
        setPageHeaderName(res.Objeto)
    })
}

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
        if (res.Sucesso) {
            $("#modalCadastroAluno").modal("hide")
            $("#modal-confirm .col-md-22").empty()
            $("#modal-confirm .col-md-22").append(`O aluno <strong>${res.Campos[0]}</strong> foi salvo com sucesso.`)
            $("#modal-confirm").modal('show')

            setPageHeaderName(res.Objeto)
            Clear()
        } else {
            setTextAlertDataNasc()
        }        
    })
}

Europa.Controllers.Exercicio.NextAluno = function () {
    $.get(Europa.Controllers.Exercicio.UrlNextAluno, { mat: $("#Matricula").val() }, function (res) {
        setPageHeaderName(res.Objeto)
    })
}

Europa.Controllers.Exercicio.PreviousAluno = function () {
    $.get(Europa.Controllers.Exercicio.UrlPreviousAluno, { mat: $("#Matricula").val() }, function (res) {
        setPageHeaderName(res.Objeto)
    })
}

Europa.Controllers.Exercicio.DeleteAluno = function () {
    $.post(Europa.Controllers.Exercicio.UrlDeleteAluno, { mat: $("#Matricula").val() }, function (res) {
        setPageHeaderName(res.Objeto)

        if (res.Sucesso == true) {
            $("#modal-delete .col-md-22").empty()
            $("#modal-delete .col-md-22").append(`O aluno <strong>${res.Campos[0]}</strong> foi deletado com sucesso.`)
            $("#modal-delete").modal('show')
        }               
    })
}

function setPageHeaderName(obj) {
    $("#form-aluno").html(obj)
    $(".page-title h2").empty()
    $(".page-title h2").append("Alunos - " + $("#Nome").val())
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

function setTextAlert() {
    $('.text-danger').parentsUntil(".modal-body", ".alert-fill").remove()
    $(".modal-body").append(`<div class="row alert-fill"><p class="text-danger col-md-offset-1"></p></div>`)
    $(".text-danger").append(`Todos os campos devem ser preenchidos`)
}

function setTextAlertDataNasc() {
    $('.text-danger').parentsUntil(".modal-body", ".alert-fill").remove()
    $(".modal-body").append(`<div class="row alert-fill"><p class="text-danger col-md-offset-1"></p></div>`)
    $(".text-danger").append(`Data inválida`)

    $("#dataNascAluno").parentsUntil('div.row', ".col-input").addClass('has-error')
}