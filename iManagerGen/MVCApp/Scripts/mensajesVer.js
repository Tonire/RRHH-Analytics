$("#borrar1").on("click", function () {
    $.ajax({
        url: '/Mensajes/Delete/' + $('#idMensaje').val(),
        type: 'GET',
        success: function (result) {
            window.location.replace("/Mensajes");
        }
    });
});
$('#borrar2').on("click", function () {
    $.ajax({
        url: '/Mensajes/Delete/' + $('#idMensaje').val(),
        type: 'GET',
        success: function (result) {
            window.location.replace("/Mensajes");
        }
    });

});