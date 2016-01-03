function borrarProducto(idProducto){
    swal({ title: "¿Estás seguro?", text: "El producto se borrará permanentemente!", type: "warning", showCancelButton: true, confirmButtonColor: "#DD6B55", confirmButtonText: "Sí, bórralo!", cancelButtonText: "Cancelar", closeOnConfirm: false }, function () { window.location = "/Productos/Delete/" + idProducto; });
}