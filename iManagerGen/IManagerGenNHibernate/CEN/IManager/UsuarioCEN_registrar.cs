
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;

namespace IManagerGenNHibernate.CEN.IManager
{
public partial class UsuarioCEN
{
public string Registrar (string p_email, string p_DNI, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fechaRegistro)
{
        /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_Usuario_registrar_customized) START*/

        UsuarioEN usuarioEN = null;

        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_email;

        usuarioEN.DNI = p_DNI;

        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.FechaRegistro = p_fechaRegistro;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.Registrar (usuarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
