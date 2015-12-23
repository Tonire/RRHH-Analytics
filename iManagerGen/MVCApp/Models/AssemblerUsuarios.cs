using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;

namespace MVCApp.Models {
    public class AssemblerUsuarios {
        public UsuarioModels ConvertENToModelUI(UsuarioEN en) {
            UsuarioModels us = new UsuarioModels();
            switch (en.GetType().Name) {
                case "SuperAdministradorEN":
                    us.Rol = "Super Administrador";
                    break;
                case "AdministradorEN":
                    us.Rol = "Administrador";
                    break;
                case "EmpleadoEN":
                    us.Rol = "Empleado";
                    break;
            }
            us.Email = en.Email;
            us.DNI = en.DNI;
            us.Nombre = en.Nombre;
            us.Apellidos = en.Apellidos;
            us.NombreCompleto = en.Apellidos.ToUpper() + ", " + en.Nombre.ToUpper();
            return us;
        }
        public IList<UsuarioModels> ConvertListENToModel(IList<UsuarioEN> ens) {
            IList<UsuarioModels> usu = new List<UsuarioModels>();
            foreach (UsuarioEN en in ens) {
                usu.Add(ConvertENToModelUI(en));
            }
            return usu;
        }
    }
}