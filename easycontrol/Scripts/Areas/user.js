

$(document).ready(function () {
    var idUser = 0;
    idUser = sessionStorage.getItem('user');

    if (idUser > 0) {
        listaInadim(idUser);
    } else {
        window.location.href = '/Home/';
    }
})


//Lista inadimplencia do usuario logado
function listaInadim(id) {

    if (id != "") {
        var _html = "";
        var _userDivi = new Object();

        _userDivi._uerID = id;

        $.ajax({
            type: "POST",
            data: JSON.stringify(_userDivi),
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
                        _html = _html + "                       <button class='btn' type='button' data-toggle='collapse' data-target='#acordParcelas" + i + "' aria-expanded='true' aria-controls='collapseOne'>";
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
                        _html = _html + "                                       <td> R$ " + parseFloat(value.INADIMPLENCIA.VALOR_ORIGINAL).toFixed(2) + "</td>";
                        _html = _html + "                                       <td>" + value.INADIMPLENCIA.ATRASODIAS + "</td>";
                        _html = _html + "                                       <td> R$ " + parseFloat(value.INADIMPLENCIA.VALOR_JUROS).toFixed(2) + "</td>";
                        _html = _html + "                                       <td> R$ " + parseFloat(value.INADIMPLENCIA.VALOR_CALCULADO).toFixed(2) + "</td>";
                        _html = _html + "                                       <td> R$ " + parseFloat(value.PARCELAS[0].VALOR).toFixed(2) + "</td>";
                        _html = _html + "                                       <td>" + moment(value.INADIMPLENCIA.DT_VENCIMENTO).format('DD/MM/YYYY') + "</td>";
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
                            _html = _html + "                           <td> R$ " + parseFloat(values.VALOR).toFixed(2) + " </td>";
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
    } else {
        alert("Não foi possível carregar as informações");
    }
}