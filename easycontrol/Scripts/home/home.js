
$(document).ready(function () {

    $("#btnLogar").on('click', function (event) {
        event.stopPropagation();
        logar();
    });

    $("#aEsqueci").on('click', function (event) {
        event.stopPropagation();
        enviaEmail();
    });

});

//Request para realizar o login
function logar() {
    if (ValidarCampos()) {
        var _user = new Object();
        _user.user = $('#iUser').val();
        _user.password = $('#iPassword').val();

        $.ajax({
            type: "POST",
            data: JSON.stringify(_user),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Home/Logar",
            success: function (response) {
                var dataUser = JSON.parse(JSON.stringify(response));
                if (dataUser != false) {
                    if (dataUser["ADMIN"]) {
                        window.location.href = '/Admin/Home/';
                    }
                } else {
                    alert("Algo deu errado");
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
        alert("Campos nulos");
        $("#avisoNulo").show();
    }
}


//Request para enviar o e-mail de recuperação senha
function enviaEmail() {
    if ($('#iUser').val().replace(" ", "") != "") {
        var _user = new Object();
        _user.user = $('#iUser').val();

        $.ajax({
            type: "POST",
            data: JSON.stringify(_user),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Home/EsqueciSenha",
            success: function (response) {
                var dataUser = JSON.parse(JSON.stringify(response));
                if (dataUser != false) {
                    alert("E-mail enviado, favor conferir sua caixa de entrada")
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
        alert("Campos nulos");
        $("#avisoNulo").show();
    }
}


//Valida campos nulos
function ValidarCampos() {
    return $('#iUser').val().replace(" ", "") != "" && $('#iPassword').val().replace(" ", "") != "";
}