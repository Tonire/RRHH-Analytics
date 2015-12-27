using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApp.Models;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
namespace MVCApp.Controllers
{
    public class HorarioController : Controller
    {
        //
        // GET: /Horario/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Horario/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Horario/Create

        public ActionResult Create()
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            IList<UsuarioEN> usuariosEN = usuarioCEN.DameTodos(0,-1);
            IEnumerable<UsuarioModels> usuarioModels = new AssemblerUsuarios().ConvertListENToModel(usuariosEN).ToList();
            HorarioModels horarioModels = new HorarioModels();
            horarioModels.Usuarios = usuarioModels;
            return View(horarioModels);
        }

        //
        // POST: /Horario/Create

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
        // GET: /Horario/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Horario/Edit/5

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
        // GET: /Horario/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Horario/Delete/5

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
