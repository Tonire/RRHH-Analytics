function iniciar() {

    document.getElementById('apariencia').style.display = "none";
}


function cambiar()
{    
  


    if (document.getElementById('apariencia').style.display == "none")
    {
        document.getElementById('datos').className = "register-box-body animated fadeOutRightBig";
        document.getElementById('apariencia').className = "register-box-body animated fadeInLeft";
        
        setTimeout(function () {
            document.getElementById('apariencia').style.display = "block";
            document.getElementById('datos').style.display = "none";
        },400);
            
        
        
    }
        else
        {
            document.getElementById('datos').className = "register-box-body animated fadeInRight";
            document.getElementById('apariencia').className = "register-box-body animated fadeOutLeftBig";
            setTimeout(function () {
                document.getElementById('apariencia').style.display = "none";
                document.getElementById('datos').style.display = "block";
            }, 400);

         
        }



    

    
}