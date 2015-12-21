using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class MensajesController : Controller
    {
        //
        // GET: /Mensajes/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Mensajes/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Mensajes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Mensajes/Create

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
        // GET: /Mensajes/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Mensajes/Edit/5

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
        // GET: /Mensajes/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Mensajes/Delete/5

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
