using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using MVCApp.Models;
namespace MVCApp.Controllers
{
    public class ProveedoresController : Controller
    {
        //
        // GET: /Proveedores/
        [Authorize(Roles = "SuperAdministrador, Administrador")]
        public ActionResult Index()
        {
            ProveedorCEN proveedorCEN= new ProveedorCEN();
            IEnumerable<ProveedorModels> proveedores = new AssemblerProveedores().ConvertListENToModel(proveedorCEN.DameTodos(0,-1)).ToList();
            return View(proveedores);
        }

        //
        // GET: /Proveedores/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Proveedores/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Proveedores/Create

        [HttpPost]
        public ActionResult Create(ProveedorModels proveedorModels)
        {
            try
            {
                // TODO: Add insert logic here
                ProveedorCEN proveedorCEN = new ProveedorCEN();
                proveedorCEN.CrearProveedor(proveedorModels.Email,proveedorModels.Nombre,proveedorModels.Telefono,proveedorModels.Direccion,proveedorModels.Localidad,proveedorModels.Pais,proveedorModels.CIF);
                TempData["Creado"] = true;
                return RedirectToAction("Index");
            }
            catch(IManagerGenNHibernate.Exceptions.DataLayerException ex)
            {
                ModelState.AddModelError("","Error el email del proveedor ya existe en la base de datos.");
                return View(proveedorModels);
            }
        }

        //
        // GET: /Proveedores/Edit/5

        public ActionResult Edit()
        {
            string id=Request["email"];
            ProveedorModels proveedorModels = new ProveedorModels();
            ProveedorCEN proveedorCEN = new ProveedorCEN();
            ProveedorEN proveedorEN = null;
            if (id != null) {
                proveedorEN = proveedorCEN.GetProveedor(id);
            }
            if (proveedorEN != null) {
                proveedorModels.Email = proveedorEN.Email;
                proveedorModels.CIF = proveedorEN.CIF;
                proveedorModels.Nombre = proveedorEN.Nombre;
                proveedorModels.Telefono = proveedorEN.Telefono;
                proveedorModels.Direccion = proveedorEN.Direccion;
                proveedorModels.Localidad = proveedorEN.Localidad;
                proveedorModels.Pais = proveedorEN.Pais;
            } else {
                return RedirectToAction("Index");
            }
            return View(proveedorModels);
        }

        //
        // POST: /Proveedores/Edit/5

        [HttpPost]
        public ActionResult Edit(ProveedorModels proveedorModels)
        {
            try
            {
                // TODO: Add update logic here
                ProveedorCEN proveedorCEN = new ProveedorCEN();
                proveedorCEN.Modify(proveedorModels.Email,proveedorModels.Nombre,proveedorModels.Telefono,proveedorModels.Direccion,proveedorModels.Localidad,proveedorModels.Pais,proveedorModels.CIF);
                TempData["Modificado"]=true;
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("","Error modificando el proveedor.");
                return View(proveedorModels);
            }
        }

        //
        // POST: /Proveedores/Delete/5

        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                ProveedorCEN proveedorCEN = new ProveedorCEN();
                proveedorCEN.Destroy(id);
                TempData["Borrado"] = true;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
