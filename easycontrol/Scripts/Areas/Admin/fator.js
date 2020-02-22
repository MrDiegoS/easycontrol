$(document).ready(function () {

    $("#lHome").on('click', function (event) {
        event.stopPropagation();
        window.location.href = '/Admin/Home/';
    });

    $("#ldoCalc").on('click', function (event) {
        event.stopPropagation();
        listFatorCalculo();
    });

    listFatorCalculo();

});


//Função para carregar lista de fator calculo
function listFatorCalculo() {
    var _html = "";

    $.ajax({
        type: "POST",
        data: null,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "/Fator/ListarFatorCalculo",
        success: function (response) {
            var dataFator = JSON.parse(JSON.stringify(response));

            if (dataFator != false) {

                $.each(dataFator, function (i, value) {

                    _html = _html + " <tr>";
                    _html = _html + "     <td>" + value.ID + "</td>";
                    _html = _html + "     <td>" + value.JUROS_TIPO + "</td>";
                    _html = _html + "     <td>" + value.JUROS_PER + "</td>";
                    _html = _html + "     <td>" + value.COMISSAO_PER + "</td>";
                    _html = _html + "     <td>" + value.QTD_PARCELAS + "</td>";
                    _html = _html + "     <td>" + Date(parseInt(value.DTCADASTRO.substr(6))) + "</td>";
                    _html = _html + "     <td onclick='verificaAcao(" + value.ID + ")'>Ediar</td>";
                    _html = _html + "     <td onclick='excluirFator(" + value.ID + ")'> Excluir </td>";
                    _html = _html + " </tr>";
                });
            };

            $("#fatorBody").html("");
            $("#fatorBody").append(_html);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

//Carrega as informações
function carregarModal(id) {

    var _fatoCalculo = new Object();
    _fatoCalculo.ID = id;

    $.ajax({
        type: "POST",
        data: JSON.stringify(_fatoCalculo),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "/Fator/CarregaFatorCalculo",
        success: function (response) {
            var dataFator = JSON.parse(JSON.stringify(response));

            if (dataFator != false) {
                $("#fatorID").val(dataFator["ID"]);
                $("#qtdParc").val(dataFator["QTD_PARCELAS"]);
                $("#tipoJuros").val(dataFator["JUROS_TIPO"] == "Simples" ? 1 : 2);
                $("#jurosPer").val(dataFator["JUROS_PER"]);
                $("#jurosPasch").val(dataFator["COMISSAO_PER"]);
            } else {
                alert("Não foi possível alterar, tente mais tarde");
            }
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
};

//Faz a requisição passando as informações
function fatorEditar() {


    if (validaCampos()) {
        var _fatoCalculo = new Object();
        _fatoCalculo.ID = $("#fatorID").val();
        _fatoCalculo.QTD_PARCELAS = $("#qtdParc").val();
        _fatoCalculo.JUROS_TIPO = $("#tipoJuros").val();
        _fatoCalculo.JUROS_PER = parseFloat($("#jurosPer").val());
        _fatoCalculo.COMISSAO_PER = parseFloat($("#jurosPasch").val());

        $.ajax({
            type: "POST",
            data: JSON.stringify(_fatoCalculo),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Fator/AlterarFatorCalculo",
            success: function (response) {
                var dataUser = JSON.parse(JSON.stringify(response));

                if (dataUser != false) {
                    alert("Alterado com sucesso!");
                    listFatorCalculo();
                    $('#modalAlterar').modal('toggle');
                    limpaCampos();

                } else {
                    alert("Não foi possível alterar, tente mais tarde");
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    } else {
        alert("Todos os campos são obrigatórios");
    };
};

//Adicionar novo fator calculo
function adicionarFatorCalculo() {

    if (validaCampos()) {
        var _fatoCalculo = new Object();
        _fatoCalculo.QTD_PARCELAS = $("#qtdParc").val();
        _fatoCalculo.JUROS_TIPO = $("#tipoJuros").val();
        _fatoCalculo.JUROS_PER = parseFloat($("#jurosPer").val());
        _fatoCalculo.COMISSAO_PER = parseFloat($("#jurosPasch").val());

        $.ajax({
            type: "POST",
            data: JSON.stringify(_fatoCalculo),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Fator/AdicionrFatorCalculo",
            success: function (response) {
                var dataUser = JSON.parse(JSON.stringify(response));

                if (dataUser != false) {
                    alert("Adicionado com sucesso!");
                    listFatorCalculo();
                    $('#modalAlterar').modal('toggle');
                    limpaCampos();

                } else {
                    alert("Não foi possível alterar, tente mais tarde");
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    } else {
        alert("Todos os campos são obrigatórios");
    };
}

//Excluir Fator
function excluirFator(id) {
    var _fatoCalculo = new Object();

    _fatoCalculo.ID = id;

    if (confirm("Deseja realmente excluir o Fator Calculo - " + id + " ?")) {
        $.ajax({
            type: "POST",
            data: JSON.stringify(_fatoCalculo),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Fator/ExcluirFatorCalculo",
            success: function (response) {
                var dataFator = JSON.parse(JSON.stringify(response));

                if (dataFator != false) {
                    alert("Excluido com sucesso!");
                    listFatorCalculo();
                } else {
                    alert("Não foi possível excluir, tente mais tarde");
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    };
}

//Valida campos obrigatórios
function validaCampos() {
    return $("#qtdParc").val() != 0 && $("#tipoJuros").val() != "Selecione" && $("#jurosPer").val() != 0 && $("#jurosPasch").val() != 0;
};

//limpa campos da modal
function limpaCampos() {
    $("#fatorID").val("");
    $("#qtdParc").val("");
    $("#tipoJuros").val("");
    $("#jurosPer").val("");
    $("#jurosPasch").val("");
};

//Verifica se é editar ou criar
function verificaAcao(id) {
    limpaCampos();

    if (id > 0) {
        $("#salvarEditar").html("");
        $("#salvarEditar").append("Salvar alterações");
        $("#salvarEditar").attr("onclick", "fatorEditar()");
        $('#modalAlterar').modal('toggle');
        $("#modalTitulo").html("");
        $("#modalTitulo").append("<span>Fator Calculo - " + id + "</span>");
        carregarModal(id);
    } else {
        $("#salvarEditar").html("");
        $("#salvarEditar").append("Gravar");
        $("#salvarEditar").attr("onclick", "adicionarFatorCalculo()");
    }
};