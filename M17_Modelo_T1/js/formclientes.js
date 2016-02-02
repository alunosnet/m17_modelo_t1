$(document).ready(function () {
    //quando a página estiver totalmente carregada
    $("#form1").submit(function (evento) {
        var nome = $("#tbNome").val();
        
        if (nome == "") {
            alert('Tem de inserir um nome');
            $("#Label1").text("Tem de inserir um nome");
            evento.preventDefault();
        }
    });
});