using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using MVCApp.Filters;
using MVCApp.Models;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using MVCApp.Controllers;
namespace MVCApp.App_Start {
    public class CargarColores {
        public static void cargarColores() {
            HttpContext contexto = HttpContext.Current;
            AparienciaCEN aparienciaCEN = new AparienciaCEN();
            IList<AparienciaEN> listaApariencias = aparienciaCEN.GetApariencia(0,-1);
            if (listaApariencias.Any()) {
                Skins skin = new Skins();
                contexto.Application["colorSuper"] = skin.getSkin(Int32.Parse(listaApariencias[0].SuperAdmin));
                contexto.Application["colorAdmin"] = skin.getSkin(Int32.Parse(listaApariencias[0].Admin));
                contexto.Application["colorEmpleado"] = skin.getSkin(Int32.Parse(listaApariencias[0].Empleado));
            }
        }
    }
}