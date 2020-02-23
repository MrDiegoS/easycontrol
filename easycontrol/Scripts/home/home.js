
$(document).ready(function () {
    sessionStorage.setItem("adminKey", "");
    sessionStorage.setItem("user", "");

   

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
                    sessionStorage.setItem("adminKey", "");
                    sessionStorage.setItem("user", dataUser["ID"]);
                    if (dataUser["ADMIN"]) {
                        sessionStorage.setItem("adminKey", dataUser["ADMIN"]);
                        window.location.href = '/Admin/Home/';
                    } else {
                        window.location.href = '/User/Home/';
                    }
                } else {
                    showMsg("Senha e/ou User estão inválidos");
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
        showMsg("Todos os campos são obrigatórios");
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
                    showMsg("E-mail enviado, favor conferir sua caixa de entrada");
                } else {
                    showMsg("Não encontramos alguma informação importante, favor entrar em contato a central");
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
        showMsg("É necessário informar o User");
    }
}


//Valida campos nulos
function ValidarCampos() {
    return $('#iUser').val().replace(" ", "") != "" && $('#iPassword').val().replace(" ", "") != "";
}

function showMsg(texto) {
    $("#avisoNulo").show();
    $("#mensagem").html("");
    $("#mensagem").append(texto);
}