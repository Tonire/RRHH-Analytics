

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

public void Destroy (string email)
{
        _IUsuarioCAD.Destroy (email);
}

public UsuarioEN GetUsuarioByEmail (string email)
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.GetUsuarioByEmail (email);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.DameTodos (first, size);
        return list;
}
public long ContarUsuarios ()
{
        return _IUsuarioCAD.ContarUsuarios ();
}
}
}
