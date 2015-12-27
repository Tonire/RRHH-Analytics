using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using MVCApp.Models;
using EjemploProyectoCP.CPs;
using Newtonsoft.Json.Linq;
namespace MVCApp.Controllers
{
    public class PedidosController : Controller
    {
        //
        // GET: /Pedido/

        public ActionResult Index()
        {

            PedidoCEN pedidoCEN = new PedidoCEN();
            
            return View(pedidoCEN.DameTodos(0,-1).ToList());
        }

        //
        // GET: /Pedido/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Pedido/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pedido/Create

        [HttpPost]
        public string Create(string data)
        {
            string data1 = data.Replace("\\", "");
            PedidoModels pedidos = new PedidoModels();
            try
            {
                bool pedir = true;
                IList<LineaPedidoEN> lineas = new List<LineaPedidoEN>();
                ProductoCEN productoCEN = new ProductoCEN();
                
                ProductoEN producto = new ProductoEN();
                PedidoCEN pedidoCEN = new PedidoCEN();

                JArray jarray = JArray.Parse(data1);
                foreach (JObject objeto in jarray) {
                    LineaPedidosModels lineaPedidoModels = new LineaPedidosModels();
                    JToken token = objeto.GetValue("referencia");
                    lineaPedidoModels.referencia = Int32.Parse(token.ToString());
                    token = objeto.GetValue("cantidad");
                    lineaPedidoModels.cantidad = Int32.Parse(token.ToString());
                    pedidos.lineas.Add(lineaPedidoModels);
                }
                
                for(int i=0;i<pedidos.lineas.Count();i++){
                    LineaPedidoEN linea = new LineaPedidoEN();
                    linea.Producto = productoCEN.GetProducto(pedidos.lineas[i].referencia);
                    if (linea.Producto != null) {
                        linea.Cantidad = pedidos.lineas[i].cantidad;
                        lineas.Add(linea);
                    } else {
                        //No se hace la venta - El producto es null
                        pedir = false;
                        break;
                    }
                }
                if (pedir) {
                    /*CREAR PEDIDO*/
                    pedidoCEN.CrearPedido(IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente,DateTime.Now,User.Identity.Name,lineas);
                    TempData["Creado"] = true;
                } else {
                    return "ERROR Producto nulo";
                }
                
                return "Ok";
            } catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //
        // POST: /Pedido/Cancelar/5
        [Authorize]
        [HttpPost]
        public ActionResult Cancelar()
        {
            try
            {
                // TODO: Add delete logic here
                string id = Request["id"];
                PedidoCEN pedidoCEN = new PedidoCEN();
                PedidoEN pedidoEN=pedidoCEN.GetPedidoById(Int32.Parse(id));
                pedidoCEN.Modify(pedidoEN.Id,IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.rechazado,pedidoEN.FechaRealizacion,null,DateTime.Now);
                TempData["Cancelado"] = true;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //
        // POST: /Pedido/Confirmar/5
        [Authorize]
        [HttpPost]
        public ActionResult Confirmar() {
            try {
                // TODO: Add delete logic here
                string id = Request["id"];
                PedidoCP pedidoCP = new PedidoCP();
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento(Int32.Parse(id),DateTime.Now);
                TempData["Confirmado"] = true;
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
