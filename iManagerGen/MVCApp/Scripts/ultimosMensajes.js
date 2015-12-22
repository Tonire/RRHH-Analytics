
$.get("/Mensajes/getUltimosMensajes/", function (json) {
    
    //alert(json);
    var listaMensajes = JSON.parse(json);
    var i = 0;
    var asunto, remitente, rol;
    var html = "";
    var rutaFoto = "";
    for (i = 0; i < listaMensajes.length ; i++) {
        
        asunto = listaMensajes[i].Asunto;
        remitente = listaMensajes[i].Remitente;
        rol = listaMensajes[i].Rol;
        switch (rol) {
            case "SuperAdministradorEN":
                rutaFoto = "/Images/SuperAdminLogo.png";
                break;
            case "AdministradorEN":
                rutaFoto = "/Images/AdminLogo.png";
                break;
            case "EmpleadoEN":
                rutaFoto = "/Images/EmpleadoLogo.png";
                break;
        }
        html = "<li><a href='#'><div class='pull-left'><img src='"+rutaFoto+"' class='img-circle' alt='User Image'></div><h4>" + remitente + " <small><i class='fa fa-clock-o'></i> 5 mins</small></h4><p>" + asunto + "</p></a></li>";
        //alert("Asunto: " + asunto + "\nRemitente: " + remitente + "\nRol: " + rol);
        $("#menu-ultimos-mensajes").append(html);
    }
    
});