using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using MVCApp.Models;
using EjemploProyectoCP.CPs;

namespace MVCApp.Controllers
{
    public class ProductosController : Controller
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

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Productos/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
