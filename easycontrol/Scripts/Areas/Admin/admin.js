$(document).ready(function () {
    
    if (sessionStorage.getItem("adminKey") != "true") {
        window.location.href = '/Home/';
    }

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

    $("#lcadIna").on('click', function (event) {
        event.stopPropagation();
        window.location.href = '/Admin/Divida/';
    });

    $("#lconsDivida").on('click', function (event) {
        event.stopPropagation();
        window.location.href = '/Admin/Divida/Dividas';
    });
});



//Realizar log off
function logOff() {
    window.location.href = '/Home/';
}