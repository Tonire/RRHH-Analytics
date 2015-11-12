
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
public IManagerGenNHibernate.EN.IManager.UsuarioEN IniciarSesion (string p_oid, string pass)
{
        /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_Usuario_iniciarSesion) ENABLED START*/

        UsuarioEN usuarioEN = null;
        bool login = false;

        if (p_oid != null && pass != null) {
                usuarioEN = _IUsuarioCAD.GetUsuarioByEmail (p_oid);
                if (usuarioEN != null) {
                        if (usuarioEN.Password.CompareTo (Utils.Util.GetEncondeMD5 (pass)) == 0) {
                                login = true;
                        }
                }
        }
        if (!login) {
                usuarioEN = null;
        }
        //return login;
        return usuarioEN;
        /*PROTECTED REGION END*/
}
}
}
