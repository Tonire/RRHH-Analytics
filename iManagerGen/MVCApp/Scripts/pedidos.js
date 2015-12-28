var array = new Array();
var lastCode = "";
$('#pedir').on("click", function () {
    if (array.length >= 1) {
        var json = JSON.stringify(array);
        $.ajax(
       {
           method: "POST",
           url: '/Pedidos/Create',
           success: function (data) {
               //alert(data);
               if (data === "Ok") {
                   //Venta realizada
                   $('#success').attr("style", "display:block");
                   limpiarTabla();
               } else {
                   //Error
                   $('#error').attr("style", "display:block");
                   $('#div-error').append(data);
               }
           },
           data: {
               'data': json
           }
       })
    }
});

function add() {
    if ($('#cantidad').val() != "" && parseInt($('#cantidad').val()) > 0) {
        var objeto = { referencia: $('#idProducto').val(), cantidad: $('#cantidad').val() };
        array.push(objeto);
        var stringHTML = "<tr><td>" + $('#idProducto').val() + "</td><td>" + $('#idProducto').find(":selected").text() + "</td><td>" + $('#cantidad').val() + "</td><td><a href='#' onClick='return quitar(this)' class='fa fa-remove' id='" + array.length + "'></a></td></tr>";
        $('#tbody').append(stringHTML);
    }
}

$('#add').on("click", function () {
    if ($('#cantidad').val() != "" && parseInt($('#cantidad').val()) > 0) {
        var objeto = { referencia: $('#idProducto').val(), cantidad: $('#cantidad').val() };
        array.push(objeto);
        var stringHTML = "<tr><td>" + $('#idProducto').val() + "</td><td>" + $('#idProducto').find(":selected").text() + "</td><td>" + $('#cantidad').val() + "</td><td><a href='#' onClick='return quitar(this)' class='fa fa-remove' id='" + array.length + "'></a></td></tr>";
        $('#tbody').append(stringHTML);
    }
});

function quitar(elemento) {
    var quitar = $(elemento).attr('id');
    var arrayAux = new Array();
    for (var i = 0; i < array.length; i++) {
        if (i == parseInt(quitar) - 1) {
            arrayAux[i] = "@";
        } else {
            arrayAux[i] = array[i];
        }
    }
    arrayAux = $.grep(arrayAux, function (value) {
        return value != "@";
    });
    array = arrayAux;
    $(elemento).parent().parent().remove();
    lastCode = "";
}

function limpiarTabla() {
    $('#tbody').empty();
    $('#idProducto').val("");
    $('#cantidad').val("");
}