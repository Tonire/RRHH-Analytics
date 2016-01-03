function borrarUsuario(formulario){
    swal({ title: "¿Estás seguro?", text: "El usuario se borrará permanentemente!", type: "warning", showCancelButton: true, confirmButtonColor: "#DD6B55", confirmButtonText: "Sí, bórralo!",cancelButtonText:"Cancelar", closeOnConfirm: false }, function () { formulario.submit(); });
}