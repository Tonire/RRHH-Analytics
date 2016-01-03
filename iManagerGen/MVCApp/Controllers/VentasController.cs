using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MVCApp.Models;
using System.Text.RegularExpressions;
using EjemploProyectoCP.CPs;
namespace MVCApp.Controllers
{
    public class VentasController : Controller
    {
        //
        // GET: /Ventas/
        [Authorize]
        public ActionResult Index()
        {
            ProductoCEN productoCEN = new ProductoCEN();
            VentasModels ventasModels = new VentasModels();
            ventasModels.productos = productoCEN.GetAllProductos(0, -1).ToList();
            return View(ventasModels);
        }

        //
        // POST: /Ventas/Create
        [Authorize]
        [HttpPost]
        public string Create(string data)
        {
            //data = Regex.Replace(data, @"\", "",RegexOptions.None, TimeSpan.FromSeconds(1.5));
            //data = limpiarString(data);
            string data1 = data.Replace("\\", "");
            VentasModels ventas=new VentasModels();
            try
            {
                bool vender = true;
                IList<LineaVentaEN> lineas = new List<LineaVentaEN>();
                ProductoCEN productoCEN = new ProductoCEN();
                
                ProductoEN producto = new ProductoEN();
                VentaCEN ventaCEN = new VentaCEN();

                JArray jarray = JArray.Parse(data1);
                foreach (JObject objeto in jarray) {
                    LineaVentasModels lineaVentaModel = new LineaVentasModels();
                    JToken token = objeto.GetValue("referencia");
                    lineaVentaModel.referencia = token.ToString();
                    token = objeto.GetValue("cantidad");
                    lineaVentaModel.cantidad = Int32.Parse(token.ToString());
                   // lineaVentaModel.cantidad = Int32.Parse();
                    ventas.lineas.Add(lineaVentaModel);
                }
                
                for(int i=0;i<ventas.lineas.Count();i++){
                    LineaVentaEN linea = new LineaVentaEN();
                    linea.Producto=productoCEN.GetProducto (ventas.lineas[i].referencia);
                    if (linea.Producto != null) {
                        linea.Cantidad = ventas.lineas[i].cantidad;
                        lineas.Add(linea);
                    } else {
                        //No se hace la venta - El producto es null
                        vender = false;
                        break;
                    }
                }
                if (vender) {
                    /*CREAR EMOVIMIENTO*/
                    VentaCP ventaCP = new VentaCP();
                    ventaCP.RestarStockCrearVentaHacerMovimiento(User.Identity.Name,DateTime.Now,lineas);
                    TempData["Creado"] = true;
                } else {
                    return "ERROR Producto nulo";
                }
                
                return "Ok";
            } catch (Exception ex)
            {
                return  ex.Message;
            }
        }
    }
}
