

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
 *      Definition of the class VentaCEN
 *
 */
public partial class VentaCEN
{
private IVentaCAD _IVentaCAD;

public VentaCEN()
{
        this._IVentaCAD = new VentaCAD ();
}

public VentaCEN(IVentaCAD _IVentaCAD)
{
        this._IVentaCAD = _IVentaCAD;
}

public IVentaCAD get_IVentaCAD ()
{
        return this._IVentaCAD;
}

public int NuevaVenta (string p_usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaVentaEN> p_lineaVenta, Nullable<DateTime> p_fechaVenta)
{
        VentaEN ventaEN = null;
        int oid;

        //Initialized VentaEN
        ventaEN = new VentaEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                ventaEN.Usuario = new IManagerGenNHibernate.EN.IManager.UsuarioEN ();
                ventaEN.Usuario.Email = p_usuario;
        }

        ventaEN.LineaVenta = p_lineaVenta;

        ventaEN.FechaVenta = p_fechaVenta;

        //Call to VentaCAD

        oid = _IVentaCAD.NuevaVenta (ventaEN);
        return oid;
}

public void Destroy (int id)
{
        _IVentaCAD.Destroy (id);
}

public void Modify (int p_Venta_OID, Nullable<DateTime> p_fechaVenta)
{
        VentaEN ventaEN = null;

        //Initialized VentaEN
        ventaEN = new VentaEN ();
        ventaEN.Id = p_Venta_OID;
        ventaEN.FechaVenta = p_fechaVenta;
        //Call to VentaCAD

        _IVentaCAD.Modify (ventaEN);
}
}
}
