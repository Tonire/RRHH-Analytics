

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
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string Registrar (string p_email, string p_DNI, String p_password)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_email;

        usuarioEN.DNI = p_DNI;

        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.Registrar (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, string p_DNI, String p_password)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.DNI = p_DNI;
        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string email)
{
        _IUsuarioCAD.Destroy (email);
}

public void AddVenta (string p_Usuario_OID, System.Collections.Generic.IList<int> p_ventas_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AddVenta (p_Usuario_OID, p_ventas_OIDs);
}
public void QuitarVenta (string p_Usuario_OID, System.Collections.Generic.IList<int> p_ventas_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.QuitarVenta (p_Usuario_OID, p_ventas_OIDs);
}
}
}
