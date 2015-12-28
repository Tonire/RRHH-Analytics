using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using MVCApp.Models;
using EjemploProyectoCP.CPs;

namespace MVCApp.Controllers
{
    public class ProductosController : BasicController
    {
        //
        // GET: /Productos/

        public ActionResult Index()
        {
            ProductoCEN productoCEN = new ProductoCEN();
            IEnumerable<ProductoEN> listaProductos = productoCEN.GetAllProductos(0,-1).ToList();
            return View(listaProductos);
        }

        //
        // GET: /Productos/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Productos/Create

        public ActionResult Create()
        {
            ProveedorCEN proveedorCEN = new ProveedorCEN();
            ProductoModels productoModelo = new ProductoModels();
            IList<ProveedorEN> todosProveedores = proveedorCEN.DameTodos(0,-1);
            IEnumerable<ProveedorModels> modelosProveedores = new AssemblerProveedores().ConvertListENToModel(todosProveedores).ToList();
            productoModelo.proveedor = modelosProveedores;
            return View(productoModelo);
        }

        //
        // POST: /Productos/Create
        [Authorize(Roles = "SuperAdministrador, Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoModels model)
        {
            if (ModelState.IsValid) {
                try {
                    ProductoCEN productoCEN = new ProductoCEN();
                    IList<string> proveedores = new List<string>();
                    for(int i=0;i<model.SelectedItems.ToList().Count;i++){
                        proveedores.Add(model.SelectedItems.ToList()[i]);
                    }
                    productoCEN.CrearProducto(model.Referencia, model.Nombre, model.Marca, model.PrecioCompra, model.PrecioVenta, 0, proveedores);
                    TempData["creado"] = true;
                    return RedirectToAction("Index");
                } catch {
                    return View(model);
                }
            }
            return View(model);
            
        }

        //
        // GET: /Productos/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Productos/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Productos/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            try {
                
                ProductoCEN productoCEN = new ProductoCEN();
                ProductoEN productoEN = new ProductoEN();
                productoEN = productoCEN.GetProducto(id);
                MensajeCEN mensajeCEN = new MensajeCEN();
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                SessionInitialize();
                PedidoCAD pedidoCAD = new PedidoCAD(session);
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);
                //Cancelamos los pedidos que tenían este producto
                IList<PedidoEN> pedidosP=pedidoCEN.GetPedidosPendientes();
                foreach(PedidoEN pedido in pedidosP){
                        foreach (LineaPedidoEN lp in pedido.LineaPedido) {
                            if (lp.Producto.Referencia == productoEN.Referencia) {
                                pedidoCEN.Modify(pedido.Id, IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.rechazado, pedido.FechaRealizacion, null, DateTime.Now);
                                break;
                            }
                        }
                }
                productoCEN.Destroy((id));
                SessionClose();
                foreach(UsuarioEN usuarioEN in usuarioCEN.DameTodos(0,-1)){
                    mensajeCEN.CreaMensaje(User.Identity.Name,usuarioEN.Email,"Producto Eliminado","El Producto con referencia "+ id + " ha sido eliminado. También han sido cancelados todos los pedidos pendientes donde aparecía este producto",false,DateTime.Now,false);    
                }
                
                return RedirectToAction("Index");
            } catch (Exception ex) {
                return RedirectToAction("Index");
            }
        }

        //
        // POST: /Productos/Delete/5

        [HttpPost]
        [Authorize]
        public ActionResult Delete()
        {
            try
            {
                string id = Request["referencia"];
                ProductoCEN productoCEN = new ProductoCEN();
                productoCEN.Destroy(Int32.Parse(id));
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
