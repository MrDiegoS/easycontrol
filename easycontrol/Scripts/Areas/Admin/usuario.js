$(document).ready(function () {

    $("#lconsUser").on('click', function (event) {
        event.stopPropagation();
        listUser();
    });

    listUser();
});


//Função para carregar lista de usuario
function listUser() {
    var _html = "";

    $.ajax({
        type: "POST",
        data: null,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "/Usuario/ListarUsuario",
        success: function (response) {
            var dataUser = JSON.parse(JSON.stringify(response));

            if (dataUser != false) {

                $.each(dataUser, function (i, value) {
                    _html = _html + " <tr>";
                    _html = _html + "     <td>" + value.ID + "</td>";
                    _html = _html + "     <td>" + value.NOME + "</td>";
                    _html = _html + "     <td>" + value.USER + "</td>";
                    _html = _html + "     <td>" + value.EMAIL + "</td>";
                    _html = _html + "     <td>" + String(value.ADMIN == true ? "Sim" : "Não") + "</td>";
                    _html = _html + "     <td>" + moment(value.DTCADASTRO).format('DD/MM/YYYY') + "</td>";
                    _html = _html + "     <td onclick='verificaAcao(" + value.ID + ")'>Ediar</td>";
                    _html = _html + "     <td onclick='excluirUsuario(" + value.ID + ")'> Excluir </td>";
                    _html = _html + " </tr>";
                });
            };

            $("#userBody").html("");
            $("#userBody").append(_html);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

//Edita um usuario
function userEditar() {

    if (validaCampos()) {
        var _user = new Object();
        _user.ID = $("#userID").val();
        _user.NOME = $("#userNome").val();
        _user.USER = $("#user").val();
        _user.EMAIL = $("#email").val();
        _user.ADMIN = $("#perfil").val() == 1 ? true : false;

        $.ajax({
            type: "POST",
            data: JSON.stringify(_user),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Usuario/AlterarUsuario",
            success: function (response) {
                var dataUser = JSON.parse(JSON.stringify(response));

                if (dataUser != false) {
                    alert("Alterado com sucesso!");
                    listUser();
                    $('#modalAlterar').modal('toggle');
                    limpaCampos();

                } else {
                    alert("Não foi possível alterar, tente novamente mais tarde");
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

//Adicina um usuario
function adcionarUser() {
    if (validaCampos() && confirmaSenha()) {
        var _user = new Object();
        _user.NOME = $("#userNome").val();
        _user.USER = $("#user").val();
        _user.EMAIL = $("#email").val();
        _user.SENHA = $("#senha").val();
        _user.ADMIN = $("#perfil").val();

        $.ajax({
            type: "POST",
            data: JSON.stringify(_user),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Usuario/AdicionarUsuario",
            success: function (response) {
                var dataUser = JSON.parse(JSON.stringify(response));

                if (dataUser != false) {
                    alert("Adicionado com sucesso!");
                    listUser();
                    $('#modalAlterar').modal('toggle');
                    limpaCampos();

                } else {
                    alert("User já cadastrado na nossa base");
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

//Excluir o usário
function excluirUsuario(id) {
    var _user = new Object();

    _user.ID = id;

    if (confirm("Deseja realmente excluir o Usuario - " + id + " ?")) {
        $.ajax({
            type: "POST",
            data: JSON.stringify(_user),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Usuario/ExcluirUsuario",
            success: function (response) {
                var dataUser = JSON.parse(JSON.stringify(response));

                if (dataUser != false) {
                    alert("Excluido com sucesso!");
                    listUser();
                } else {
                    alert("Não foi possível excluir, existem amarrações para esse usuário");
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

//Carrega informações no portal
function carregarModal(id) {
    var _user = new Object();
    _user.ID = id;
    _user.USER = "";

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
                $("#userNome").val(dataUser["NOME"]);
                $("#user").val(dataUser["USER"]);
                $("#email").val(dataUser["EMAIL"]);
                $("#perfil").val((dataUser["ADMIN"]) == true ? 1 : 0);
            } else {
                alert("Não foi possível carregar as informações");
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


//Vefica se ação se trata de edição ou alteração
function verificaAcao(id) {
    limpaCampos();

    if (id > 0) {
        $("#salvarEditar").html("");
        $("#salvarEditar").append("Salvar alterações");
        $("#salvarEditar").attr("onclick", "userEditar()");
        $('#modalAlterar').modal('toggle');
        $("#modalTitulo").html("");
        $("#divSenha").html("");
        $("#modalTitulo").append("<span>Usuário - " + id + "</span>");
        carregarModal(id);
    } else {
        $("#salvarEditar").html("");
        $("#salvarEditar").append("Gravar");
        $("#modalTitulo").html("");
        $("#divSenha").html("");
        $("#divSenha").append("  <label>Senha</label> <input type = 'password' id = 'senha' value = '' /> <label>Confirma sua senha</label>  <input type='password' id='confirmSenha' value='' />");
        $("#salvarEditar").attr("onclick", "adcionarUser()");
    };
};

//Limpa campos do modal
function limpaCampos() {
    $("#userID").val("");
    $("#userNome").val("");
    $("#user").val("");
    $("#email").val("");
    $("#senha").val("");
    $("#confirmSenha").val("");
}

//Valida campos nulos
function validaCampos() {
    return $("#userNome").val() != "" && $("#user").val() != "" && $("#email").val() != "" && $("#perfil").val() != "";
}

//Confirma se as senhas são iguais
function confirmaSenha() {
    return $("#senha").val() != "" && $("#confirmSenha").val() != "" && ($("#senha").val() == $("#confirmSenha").val());
}