using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using MVCApp.Models;
namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //Comprobamos que aun no se ha realizado la configuración de la aplicacion
            AparienciaCEN apariencia = new AparienciaCEN();
            

            if (!apariencia.GetApariencia(0, 3).Any()) //Si se cumple es que aun no hemos insertado nada en apariencia
            {
                TempData["Instalacion"] = true;
                return RedirectToAction("Index", "Instalacion");
            }
            if (!Request.IsAuthenticated) {
                return RedirectToAction("Login", "Account"); 
            }

            MovimientosCEN movimientoCEN = new MovimientosCEN();
            PedidoCEN pedidoCEN= new PedidoCEN();
            ProveedorCEN proveedorCEN = new ProveedorCEN();
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            VentaCEN ventaCEN = new VentaCEN();
            ProductoCEN productoCEN = new ProductoCEN();

            HomeModels homeModel= new HomeModels();
            homeModel.totalAnyoGastos = new List<double>();
            homeModel.totalAnyoIngresos = new List<double>();
            for (int i = 1; i <= 12; i++) {
                homeModel.totalAnyoGastos.Add(movimientoCEN.GetMovimientoTotalMesAnyo(i,2015,IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto));
                homeModel.totalAnyoIngresos.Add(movimientoCEN.GetMovimientoTotalMesAnyo(i, 2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.ingreso));
            }
            homeModel.PedidosPendientes = pedidoCEN.GetPedidosPendientes().ToList();
            homeModel.listaProveedores = new AssemblerProveedores().ConvertListENToModel(proveedorCEN.DameTodos(0,-1)).ToList();
            homeModel.numeroUsuarios = usuarioCEN.contarUsuarios();
            homeModel.numeroVentas = ventaCEN.contarVentas();
            homeModel.numeroPedidiosPendientes = pedidoCEN.contarPedidosPendientes();
            homeModel.numeroProductos = productoCEN.contarProductos();
            return View(homeModel);
        }

    }
}
