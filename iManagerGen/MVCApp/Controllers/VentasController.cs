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
namespace MVCApp.Controllers
{
    public class VentasController : Controller
    {
        //
        // GET: /Ventas/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Ventas/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Ventas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Ventas/Create

        [HttpPost]
        public int Create(string jsonDatos)
        {
            try
            {
                LineaVentaCEN lineaVentaCEN = new LineaVentaCEN();
               //Esta mierda siempre es null, porque no se pasar las cosas por POST XD
                if (jsonDatos != null) {
                    JArray jArray = JArray.Parse(jsonDatos);
                    JObject jObject = JObject.Parse(jsonDatos);
                    int idProducto;
                    int cantidad;
                    JToken token = jObject.GetValue("idProducto");
                    idProducto = Int32.Parse(token.ToString());
                    token = jObject.GetValue("cantidad");
                    cantidad = Int32.Parse(token.ToString());
                    lineaVentaCEN.CrearLineaVenta(cantidad, idProducto);
                    return 1;
                } else {
                    return 0;
                }

                
            }
            catch
            {
                return 0;
            }
        }

        //
        // GET: /Ventas/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Ventas/Edit/5

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
        // GET: /Ventas/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Ventas/Delete/5

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
