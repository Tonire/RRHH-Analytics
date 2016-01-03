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
            homeModel.totalAnyoGastos = new List<List<double>>();
            homeModel.totalAnyoIngresos = new List<List<double>>();
            List<double> auxGastos = new List<double>();
            List<double> auxIngresos = new List<double>();
            for (int j = 2015; j < 2018; j++ ) {
                for (int i = 1; i <= 12; i++) {
                    auxGastos.Add(Math.Round(movimientoCEN.GetMovimientoTotalMesAnyo(i, j, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto),2));
                    auxIngresos.Add(Math.Round(movimientoCEN.GetMovimientoTotalMesAnyo(i, j, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.ingreso),2));
                }
                homeModel.totalAnyoGastos.Add(auxGastos);
                homeModel.totalAnyoIngresos.Add(auxIngresos);
                auxGastos = new List<double>();
                auxIngresos = new List<double>();
            }
            
            homeModel.PedidosPendientes = pedidoCEN.GetPedidosPendientes().ToList();
            homeModel.listaProveedores = new AssemblerProveedores().ConvertListENToModel(proveedorCEN.DameTodos(0,-1)).ToList();
            homeModel.numeroUsuarios = usuarioCEN.ContarUsuarios();
            homeModel.numeroVentas = ventaCEN.ContarVentas();
            homeModel.numeroPedidiosPendientes = pedidoCEN.ContarPedidosPendientes();
            homeModel.numeroProductos = productoCEN.ContarProductos();
            for(int i = 2015; i < 2018; i++){
                homeModel.totalIngresos.Add(movimientoCEN.GetMovimientoTotalAnyo(i, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.ingreso));
                homeModel.totalGastos.Add(movimientoCEN.GetMovimientoTotalAnyo(i, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto));
                homeModel.ganancia.Add(movimientoCEN.GetMovimientoTotalAnyo(i, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.ingreso)-movimientoCEN.GetMovimientoTotalAnyo(i, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto));
            }
            IList<PedidoEN> listaUltimosPedidos = pedidoCEN.DameTodos(Int32.Parse(pedidoCEN.ContarPedidos().ToString())-7,7);
            homeModel.listaUltimosPedidos = listaUltimosPedidos.Reverse();

            IList<ProductoEN> listaUltimosProductos = productoCEN.GetAllProductos(Int32.Parse(productoCEN.ContarProductos().ToString())-5,5);
            homeModel.listaUltimosProductos = listaUltimosProductos.Reverse();

            List<ProductoEN> productosMasVendidos = (List<ProductoEN>)productoCEN.GetAllProductos(0,-1);
            var sortedList = productosMasVendidos.OrderByDescending(x => x.Ventas);
            List<ProductoEN> lista5productosMasVendidos = new List<ProductoEN>();
            homeModel.productosMasVendidos = sortedList;
            homeModel.otrosCuenta = productoCEN.TotalVentas();
            return View(homeModel);
        }

    }
}
