$(document).ready(function () {

    $("#lHome").on('click', function (event) {
        event.stopPropagation();
        window.location.href = '/Admin/Home/';
    });

    $("#ldoCalc").on('click', function (event) {
        event.stopPropagation();
        window.location.href = '/Admin/Fator/';
    });

    $("#lconsUser").on('click', function (event) {
        event.stopPropagation();
        window.location.href = '/Admin/Usuario/';
    });

});