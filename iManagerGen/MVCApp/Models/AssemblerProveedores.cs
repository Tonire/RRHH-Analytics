using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCApp.Models;
using IManagerGenNHibernate.EN.IManager;
namespace MVCApp.Models {
    public class AssemblerProveedores {

        public ProveedorModels ConvertENToModelUI(ProveedorEN en) {
            ProveedorModels proveedor = new ProveedorModels();
            proveedor.Email = en.Email;
            proveedor.Nombre = en.Nombre;
            proveedor.Telefono = en.Telefono;
            proveedor.Direccion = en.Direccion;
            proveedor.Localidad = en.Localidad;
            proveedor.Pais = en.Pais;
            proveedor.CIF = en.CIF;

            return proveedor;
        }
        public IList<ProveedorModels> ConvertListENToModel(IList<ProveedorEN> ens) {
            IList<ProveedorModels> usu = new List<ProveedorModels>();
            foreach (ProveedorEN en in ens) {
                usu.Add(ConvertENToModelUI(en));
            }
            return usu;
        }
    }
}