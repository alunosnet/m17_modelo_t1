$(document).ready(function () {
    
    $("#form1").submit(function (evento) {
        var nome = $("#tbNome").val();
        if (nome == "") {
            alert("Tem de indicar um nome");
            $("#tbNome").focus();
            evento.preventDefault();
        }
    });
});