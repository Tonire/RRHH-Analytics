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
using System.Globalization;

namespace MVCApp.Controllers {
    public class ProductosController : BasicController {
        //
        // GET: /Productos/

        public ActionResult Index() {
            ProductoCEN productoCEN = new ProductoCEN();
            IEnumerable<ProductoEN> listaProductos = productoCEN.GetAllProductos(0, -1).ToList();
            return View(listaProductos);
        }

        //
        // GET: /Productos/Details/5

        public ActionResult Details(int id) {
            ProveedorCEN proveedorCEN = new ProveedorCEN();
            ProductoModels productoModels= new ProductoModels();
            ProductoCEN productoCEN = new ProductoCEN();
            ProductoEN productoEN = productoCEN.GetProducto(id);
            productoModels.Nombre = productoEN.Nombre;
            productoModels.Referencia = id;
            productoModels.proveedor = new AssemblerProveedores().ConvertListENToModel(proveedorCEN.GetProveedoresByProducto(id)).ToList();

            return View(productoModels);
        }

        //
        // GET: /Productos/Create

        public ActionResult Create() {
            ProveedorCEN proveedorCEN = new ProveedorCEN();
            ProductoModels productoModelo = new ProductoModels();
            IList<ProveedorEN> todosProveedores = proveedorCEN.DameTodos(0, -1);
            IEnumerable<ProveedorModels> modelosProveedores = new AssemblerProveedores().ConvertListENToModel(todosProveedores).ToList();
            productoModelo.proveedor = modelosProveedores;
            return View(productoModelo);
        }

        //
        // POST: /Productos/Create
        [Authorize(Roles = "SuperAdministrador, Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoModels model) {
            if (ModelState.IsValid) {
                try {
                    ProductoCEN productoCEN = new ProductoCEN();
                    IList<string> proveedores = new List<string>();
                    for (int i = 0; i < model.SelectedItems.ToList().Count; i++) {
                        proveedores.Add(model.SelectedItems.ToList()[i]);
                    }
                    productoCEN.CrearProducto(model.Referencia, model.Nombre, model.Marca, float.Parse(model.PrecioCompra, CultureInfo.InvariantCulture.NumberFormat), float.Parse(model.PrecioVenta, CultureInfo.InvariantCulture.NumberFormat), 0, proveedores);
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

        public ActionResult Edit(int id) {
            ProductoModels productoModels = new ProductoModels();
            ProductoCEN productoCEN = new ProductoCEN();
            ProductoEN productoEN = productoCEN.GetProducto(id);
            ProveedorCEN proveedorCEN = new ProveedorCEN();
            productoModels.Referencia = productoEN.Referencia;
            productoModels.Nombre = productoEN.Nombre;
            productoModels.Marca = productoEN.Marca;
            productoModels.PrecioCompra = productoEN.PrecioCompra.ToString();
            productoModels.PrecioVenta = productoEN.PrecioVenta.ToString();
            productoModels.proveedor = new AssemblerProveedores().ConvertListENToModel(proveedorCEN.DameTodos(0,-1)).ToList();
            
            return View(productoModels);
        }

        //
        // POST: /Productos/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(ProductoModels productoModels) {
            try {
                // TODO: Add update logic here
                ProductoCEN productoCEN = new ProductoCEN();
                ProveedorCEN proveedorCEN= new ProveedorCEN();
                int stock = productoCEN.GetProducto(productoModels.Referencia).Stock;
                productoCEN.Modify(productoModels.Referencia, productoModels.Nombre, productoModels.Marca, float.Parse(productoModels.PrecioCompra, CultureInfo.InvariantCulture.NumberFormat), float.Parse(productoModels.PrecioVenta, CultureInfo.InvariantCulture.NumberFormat), stock);
                IList<string> proveedoresIDS = new List<string>();
                foreach(ProveedorEN proveedor in proveedorCEN.GetProveedoresByProducto(productoModels.Referencia)){
                    proveedoresIDS.Add(proveedor.Email);
                }
                productoCEN.QuitarProveedor(productoModels.Referencia,proveedoresIDS);
                productoCEN.AsignarProveedor(productoModels.Referencia,productoModels.SelectedItems.ToList());
                TempData["Modificado"] = true;
                return RedirectToAction("Index");
            } catch {
                return RedirectToAction("Edit",new{id=productoModels.Referencia});
            }
        }

        //
        // GET: /Productos/Delete/5
        [Authorize]
        public ActionResult Delete(int id) {
            try {

                ProductoCEN productoCEN = new ProductoCEN();
                bool conflicto = false;
                ProductoEN productoEN = new ProductoEN();
                IList<PedidoEN> pedidosList = new List<PedidoEN>();
                productoEN = productoCEN.GetProducto(id);
                MensajeCEN mensajeCEN = new MensajeCEN();
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                SessionInitialize();
                PedidoCAD pedidoCAD = new PedidoCAD(session);
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);
                //Cancelamos los pedidos que tenían este producto
                IList<PedidoEN> pedidosP = pedidoCEN.GetPedidosPendientes();
                foreach (PedidoEN pedido in pedidosP) {
                    foreach (LineaPedidoEN lp in pedido.LineaPedido) {
                        if (lp.Producto.Referencia == productoEN.Referencia) {
                            pedidosList.Add(pedido);
                            conflicto = true;
                            break;
                        }
                    }
                }
                SessionClose();
                productoCEN.Destroy(id);
                PedidoCEN pedidoCEN2 = new PedidoCEN();
                if (conflicto) {
                    foreach (PedidoEN pedido in pedidosList) {
                        pedidoCEN2.Modify(pedido.Id, IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.rechazado, pedido.FechaRealizacion, null, DateTime.Now);
                    }

                    foreach (UsuarioEN usuarioEN in usuarioCEN.DameTodos(0, -1)) {
                        mensajeCEN.CreaMensaje(User.Identity.Name, usuarioEN.Email, "Pedido Cancelado", "El Producto con referencia " + id + " ha sido eliminado. También han sido cancelados todos los pedidos pendientes donde aparecía este producto", false, DateTime.Now, false);
                    }
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
        public ActionResult Delete() {
            try {
                string id = Request["referencia"];
                ProductoCEN productoCEN = new ProductoCEN();
                productoCEN.Destroy(Int32.Parse(id));
                return RedirectToAction("Index");
            } catch (Exception ex) {
                return RedirectToAction("Index");
            }
        }
    }
}
