﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using MVCApp.Models;
using EjemploProyectoCP.CPs;
using Newtonsoft.Json.Linq;
namespace MVCApp.Controllers
{
    public class PedidosController : BasicController
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
            try {
                SessionInitialize();
                LineaPedidoCAD lineaCAD = new LineaPedidoCAD(session);
                LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN(lineaCAD);
                IEnumerable<LineaPedidosModels> lineaPedidoModels = new AssemblerLineaPedidos().ConvertListENToModel(lineaPedidoCEN.GetLineasPedidoByPedido(id)).ToList();
                SessionClose();
                return View(lineaPedidoModels);
            } catch {
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /Pedido/Create

        public ActionResult Create()
        {
            ProductoCEN productoCEN = new ProductoCEN();
            ProductoModels productoModels = new ProductoModels();
            productoModels.productos = productoCEN.GetAllProductos(0,-1).ToList();
            return View(productoModels);
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
                    lineaPedidoModels.referencia = token.ToString();
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
                PedidoEN pedidoEN = null;
                if (id != null) {
                    pedidoEN = pedidoCEN.GetPedidoById(Int32.Parse(id));
                }
                if(pedidoEN != null && pedidoEN.Estado!=IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.confirmado){
                    pedidoCEN.Modify(pedidoEN.Id, IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.rechazado, pedidoEN.FechaRealizacion, null, DateTime.Now);
                    TempData["Cancelado"] = true;
                    return RedirectToAction("Index");
                } else {
                    TempData["ErrorCancelado"] = true;
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Index");
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
                if (id != null) {
                    pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento(Int32.Parse(id), DateTime.Now);
                    TempData["Confirmado"] = true;
                }
                return RedirectToAction("Index");
            } catch {
                TempData["ErrorConfirmado"] = true;
                return RedirectToAction("Index");
            }
        }
    }
}
