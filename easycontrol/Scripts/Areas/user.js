

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
                        _html = _html + "                       <button class='btn btn-lg btn-block' type='button' data-toggle='collapse' data-target='#acordParcelas" + i + "' aria-expanded='true' aria-controls='collapseOne'>";
                        _html = _html + "                          Dívida #" + (i + 1)
                        _html = _html + "                       </button>";
                        _html = _html + "                  </h2>";
                        _html = _html + "              </div>";
                        _html = _html + "              <div id='acordParcelas" + i + "' class='collapse show' aria-labelledby='acordTitulo" + i + "' data-parent='#acordDivida'>";
                        _html = _html + "                  <div class='card-body'>";
                        _html = _html + "                   <table class='table table-dark'>";
                        _html = _html + "                       <ul class='list - group'>"
                        _html = _html + "                           <li class='list - group - item'>Dia do vencimento: " + moment(value.INADIMPLENCIA.DT_VENCIMENTO).format('DD/MM/YYYY') + "</li>";
                        _html = _html + "                           <li class='list - group - item'>Dia Atraso: " + value.INADIMPLENCIA.ATRASODIAS + "</li>";
                        _html = _html + "                           <li class='list - group - item'>Valor Original: R$" + parseFloat(value.INADIMPLENCIA.VALOR_ORIGINAL).toFixed(2).replace(".", ",") + "</li>";
                        _html = _html + "                           <li class='list - group - item'>Valor Juros: R$ " + parseFloat(value.INADIMPLENCIA.VALOR_JUROS).toFixed(2).replace(".", ",") + "</li>";
                        _html = _html + "                           <li class='list - group - item'>Valor Final: R$ " + parseFloat(value.INADIMPLENCIA.VALOR_CALCULADO).toFixed(2).replace(".", ",") + "</li>";
                        $.each(value.PARCELAS, function (j, values) {
                            _html = _html + "                       <ul class='list - group'>";
                            _html = _html + "                           <li class='list - group - item'>" + (j + 1) + " - R$ " + parseFloat(values.VALOR).toFixed(2).replace(".",",") + " - Data Vencimento: " + moment(values.DT_VENCIMENTO).format('DD/MM/YYYY') + "</li>";
                            _html = _html + "                       </ul>";
                        });
                        _html = _html + "                       </ul>";
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