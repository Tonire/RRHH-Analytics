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
    public class UsuariosController : BasicController
    {
        //
        // GET: /Usuarios/

        public ActionResult Index()
        {

            UsuarioCEN cen = new UsuarioCEN();
            IList<UsuarioEN> list = cen.DameTodos(0, -1).ToList();
            IEnumerable<UsuarioModels> listUsu = new AssemblerUsuarios().ConvertListENToModel(list).ToList();
            
            return View(listUsu);
        }

        //
        // GET: /Usuarios/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Usuarios/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuarios/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuarios/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Usuarios/Edit/5

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
        // GET: /Usuarios/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Usuarios/Delete/5

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
