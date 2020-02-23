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
                    window.location.href = '/Admin/Divida/Dividas'
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

//Lista as dívidas
function listaDivida() {
    var _html = "";

    $.ajax({
        type: "POST",
        data: null,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "/Divida/ListarDivida",
        success: function (response) {
            var dataInadim = JSON.parse(JSON.stringify(response));

            if (dataInadim != false) {

                console.log(dataInadim);

                $.each(dataInadim, function (i, value) {
                    _html = _html + "<tr>";
                    _html = _html + "   <td>";
                    _html = _html + "       <div class='accordion' id='acordDivida" + i +"'>";
                    _html = _html + "           <div class='card' >";
                    _html = _html + "             <div class='card - header' id='acordTitulo" + i +"'>";
                    _html = _html + "                  <h2 class='mb-0'>";
                    _html = _html + "                       <button class='btn' type='button' data-toggle='collapse' data-target='#acordParcelas"+i+"' aria-expanded='true' aria-controls='collapseOne'>";
                    _html = _html + "                           <table class='table table-dark'>";
                    _html = _html + "                               <tr>";
                    _html = _html + "                               <td>" + i + "</td>";
                    _html = _html + "                               <td>" + value.USUARIO.NOME + "</td>";
                    _html = _html + "                               <td>" + value.INADIMPLENCIA.VALOR_ORIGINAL + "</td>";
                    _html = _html + "                               <td>" + value.INADIMPLENCIA.ATRASODIAS + "</td>";
                    _html = _html + "                               <td>" + value.INADIMPLENCIA.VALOR_JUROS + "</td>";
                    _html = _html + "                               <td>" + value.INADIMPLENCIA.VALOR_CALCULADO + "</td>";
                    _html = _html + "                               <td>" + value.PARCELAS[0].VALOR + "</td>";
                    _html = _html + "                               <td>" + Date(parseInt(value.INADIMPLENCIA.DT_VENCIMENTO.substr(6))) + "</td>";
                    _html = _html + "                               </tr>";
                    _html = _html + "                           </table>";
                    _html = _html + "                       </button>";
                    _html = _html + "                  </h2>";
                    _html = _html + "              </div>";
                    _html = _html + "              <div id='acordParcelas" + i + "' class='collapse show' aria-labelledby='acordTitulo" + i +"' data-parent='#acordDivida" + i +"'>";
                    _html = _html + "                  <div class='card-body'>";
                    _html = _html + "                   <table class='table table-dark'>";
                    $.each(value.PARCELAS, function (j, values) {
                        _html = _html + "                   <tr>";
                        _html = _html + "                       <td>" + j + "</td>";
                        _html = _html + "                       <td> R$" + values.VALOR + " </td>";
                        _html = _html + "                       <td>" + Date(parseInt(values.DT_VENCIMENTO.substr(6))) + " </td>";
                        _html = _html + "                   </tr>";
                    });
                    _html = _html + "                   </table>";
                    _html = _html + "                  </div>";
                    _html = _html + "              </div>";
                    _html = _html + "           </div>";
                    _html = _html + "       </div>";
                    _html = _html + "   </td>";
                    _html = _html + "</tr>";
                });
            };
            console.log(_html);
            $("#dividaBody").html("");
            $("#dividaBody").append(_html);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

//Valida campos nulos
function validaCampos() {
    return $("#vlOriginal").val() != "" && $("#dtVencimento").val() != "" && $("#qtdParcelas").val() != "" && $("#userID").val() != "" && $("#selUser").val() != "" && $("#selFator").val() != ""

}