$(document).ready(function () {

    $("#lHome").on('click', function (event) {
        event.stopPropagation();
        window.location.href = '/Home/';
    });

    $("#ldoCalc").on('click', function (event) {
        event.stopPropagation();
        window.location.href = '/Admin/Fator/';
    });

    $("#XABLAU").on('click', function (event) {
        event.stopPropagation();
        window.location.href = '/Fator/';
        listFatorCalculo();
    });

});