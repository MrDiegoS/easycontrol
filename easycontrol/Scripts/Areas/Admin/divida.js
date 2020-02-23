$(document).ready(function () {
    carregarComboFator();
})


//Carrega o compo Fator Calculo
function carregarComboFator() {
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

                    _html = _html + "     <option value=" + value.ID + "> Fator de Calulo - ID " + value.ID + "</option>";
                });
            };

            $("#selFator").html("");
            $("#selFator").append(_html);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });

}

//Busca o usuário
function buscarUser() {

    if ($("#buscaUser").val().replace(" ", "") != "") {
        var _user = new Object();
        _user.ID = 0;
        _user.USER = $("#buscaUser").val();

        $.ajax({
            type: "POST",
            data: JSON.stringify(_user),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Usuario/CarregaUsuario",
            success: function (response) {
                var dataUser = JSON.parse(JSON.stringify(response));

                if (dataUser != false) {
                    $("#userID").val(dataUser["ID"]);
                    $("#selUser").val(dataUser["NOME"]);
                } else {
                    $("#userID").val("");
                    $("#selUser").val("");
                    alert("Não foi possível carregar as informações");
                };
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                $("#userID").val("");
                $("#selUser").val("");
                alert("Não foi encontrado nenhum usuário com o User fornecido");
            }
        });
    } else {
        alert("É necessário digitar o User para pesquisar");
    };
}

//Calcula a inadimplência
function calcularInadimplencia() {

    if (validaCampos()) {
        var _inadim = new Object();
        _inadim.VALOR_ORIGINAL = parseFloat($("#vlOriginal").val());
        _inadim.DT_VENCIMENTO = $("#dtVencimento").val();
        _inadim.QTD_PARCELAS = $("#qtdParcelas").val();
        _inadim.USERID = $("#userID").val();
        _inadim.FATORID = $("#selFator").val();

        $.ajax({
            type: "POST",
            data: JSON.stringify(_inadim),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Divida/CalcularDivida",
            success: function (response) {
                var dataInadim = JSON.parse(JSON.stringify(response));

                if (dataInadim != false) {
                    alert(response);
                } else {
                    alert("Não foi possível cadastrar a dívida, tente novamente mais tarde");
                }

            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                $("#userID").val("");
                $("#selUser").val("");
                alert("Não foi possível cadastrar a dívida, tente novamente mais tarde");
            }
        });
    } else {
        alert("Todos os campos são obrigatórios");
    }
}

//Valida campos nulos
function validaCampos() {
    return $("#vlOriginal").val() != "" && $("#dtVencimento").val() != "" && $("#qtdParcelas").val() != "" && $("#userID").val() != "" && $("#selUser").val() != "" && $("#selFator").val() != ""

}