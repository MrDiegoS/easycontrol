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
                    _html = _html + "       <div class='accordion' id='acordDivida'>";
                $.each(dataInadim, function (i, value) {
                    _html = _html + "           <div class='card' >";
                    _html = _html + "             <div class='card - header' id='acordTitulo" + i + "'>";
                    _html = _html + "                  <h2 class='mb-0'>";
                    _html = _html + "                       <button class='btn btn-block ' type='button' data-toggle='collapse' data-target='#acordParcelas" + i + "' aria-expanded='true' aria-controls='collapseOne'>";
                    _html = _html + "                           <table class='table table-dark'>";
                    _html = _html + "                                <thead>";
                    _html = _html + "                                        <tr>";
                    _html = _html + "                                        <th scope='col'>#</th>";
                    _html = _html + "                                        <th scope='col'>Nome</th>";
                    _html = _html + "                                        <th scope='col'>Valor Original</th>";
                    _html = _html + "                                        <th scope='col'>Dias de atraso</th>";
                    _html = _html + "                                        <th scope='col'>Valor do juros</th>";
                    _html = _html + "                                        <th scope='col'>Valor final</th>";
                    _html = _html + "                                        <th scope='col'>Valor de cada parcela</th>";
                    _html = _html + "                                        <th scope='col'>Data vencimento</th>";
                    _html = _html + "                                        </tr >";
                    _html = _html + "                                    </thead>";
                    _html = _html + "                                <tbody>";
                    _html = _html + "                                   </tr>";
                    _html = _html + "                                       <td>" + (i + 1) + "</td>";
                    _html = _html + "                                       <td>" + value.USUARIO.NOME + "</td>";
                    _html = _html + "                                       <td> R$ " + parseFloat(value.INADIMPLENCIA.VALOR_ORIGINAL).toFixed(2).replace(".", ",") + "</td>";
                    _html = _html + "                                       <td>" + value.INADIMPLENCIA.ATRASODIAS + "</td>";
                    _html = _html + "                                       <td> R$ " + parseFloat(value.INADIMPLENCIA.VALOR_JUROS).toFixed(2).replace(".", ",") + "</td>";
                    _html = _html + "                                       <td> R$ " + parseFloat(value.INADIMPLENCIA.VALOR_CALCULADO).toFixed(2).replace(".", ",") + "</td>";
                    _html = _html + "                                       <td> R$ " + parseFloat(value.PARCELAS[0].VALOR).toFixed(2).replace(".", ",") + "</td>";
                    _html = _html + "                                       <td>" + moment(value.INADIMPLENCIA.DT_VENCIMENTO).format('DD/MM/YYYY')+ "</td>";
                    _html = _html + "                                   </tr>";
                    _html = _html + "                               </tbody>";
                    _html = _html + "                           </table>";
                    _html = _html + "                       </button>";
                    _html = _html + "                  </h2>";
                    _html = _html + "              </div>";
                    _html = _html + "              <div id='acordParcelas" + i + "' class='collapse show' aria-labelledby='acordTitulo" + i + "' data-parent='#acordDivida'>";
                    _html = _html + "                  <div class='card-body'>";
                    _html = _html + "                   <table class='table table-dark'>";
                    _html = _html + "                       <thead>";
                    _html = _html + "                           <tr>";
                    _html = _html + "                             <th scope='col'>Parcela Nº</th>";
                    _html = _html + "                             <th scope='col'>Valor</th>";
                    _html = _html + "                             <th scope='col'>Vencimento</th>";
                    _html = _html + "                           </tr>";
                    _html = _html + "                       </thead>";
                    _html = _html + "                       <tbody>";
                    $.each(value.PARCELAS, function (j, values) {
                        _html = _html + "                       <tr>";
                        _html = _html + "                           <td>" + (j + 1) + "</td>";
                        _html = _html + "                           <td> R$ " + parseFloat(values.VALOR).toFixed(2).replace(".", ",") + " </td>";
                        _html = _html + "                           <td>" + moment(values.DT_VENCIMENTO).format('DD/MM/YYYY') + " </td>";
                        _html = _html + "                       </tr>";
                    });
                    _html = _html + "                       </tbody>";
                    _html = _html + "                   </table>";
                    _html = _html + "                  </div>";
                    _html = _html + "              </div>";
                    _html = _html + "           </div>";
                    _html = _html + "       </div>";
                });
                _html = _html + "       </div>";
            };
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