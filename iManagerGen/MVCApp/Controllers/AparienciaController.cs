using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApp.Models;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using System.IO;
namespace MVCApp.Controllers {
    public class AparienciaController : Controller {
        //
        // GET: /Apariencia/

        public ActionResult Index() {
            InstalacionModel instalacionModels = new InstalacionModel();
            AparienciaCEN aparienciaCEN = new AparienciaCEN();
            AparienciaEN aparienciaEN = aparienciaCEN.GetApariencia(0, -1)[0];
            instalacionModels.SiteName = aparienciaEN.Nombre;
            instalacionModels.SiteLogo = aparienciaEN.Logo;
            instalacionModels.SuperColor = aparienciaEN.SuperAdmin;
            instalacionModels.AdminColor = aparienciaEN.Admin;
            instalacionModels.EmplColor = aparienciaEN.Empleado;

            return View(instalacionModels);
        }

        //
        // POST: /Apariencia/Create

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstalacionModel model, HttpPostedFileBase file) {
            try {
                //Guardamos la foto
                string fileName = "", path = "";
                // Verify that the user selected a file
                if (file != null && file.ContentLength > 0) {
                    // extract only the fielname
                    fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/Images/uploads folder
                    path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                    //string pathDef = path.Replace(@"\\", @"\");
                    file.SaveAs(path);
                } 
                fileName = "/Images/Uploads/" + fileName;
                AparienciaCEN aparienciaCEN = new AparienciaCEN();
                AparienciaEN aparienciaEN = new AparienciaEN();
                aparienciaEN=aparienciaCEN.GetApariencia(0, -1)[0];
                string name = aparienciaEN.Nombre;
                string logo = aparienciaEN.Logo;
                if(file==null){
                    fileName = logo;
                }
                if(name.CompareTo(model.SiteName)==0){
                    aparienciaCEN.Modify(name, fileName, model.SuperColor, model.AdminColor, model.EmplColor);
                } else {
                    
                }
                
                Skins skin = new Skins();
                HttpContext.Application["colorSuper"] = skin.getSkin(Int32.Parse(model.SuperColor));
                HttpContext.Application["colorAdmin"] = skin.getSkin(Int32.Parse(model.AdminColor));
                HttpContext.Application["colorEmpleado"] = skin.getSkin(Int32.Parse(model.EmplColor));
                TempData["AparienciaCambiada"] = true;
                return RedirectToAction("Index", "Apariencia");
            } catch {
                return RedirectToAction("Index", "Apariencia",model);
            }
        }


    }
}
