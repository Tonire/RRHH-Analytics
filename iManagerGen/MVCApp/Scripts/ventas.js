$('#crearVenta').on("click", function () {
    //var json = '[{"idProducto":"' + $('#idProducto').val + '"},{"cantidad":"' + $('#cantidad').val + '"}]';
    $.post("/Ventas/Create/", { idProducto: $('#idProducto').val(), cantidad: $('#cantidad').val() }, function (data) {
        alert(data);
    });
});