

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

public int NuevaVenta (string p_usuario, int p_producto)
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


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                ventaEN.Producto = new IManagerGenNHibernate.EN.IManager.ProductoEN ();
                ventaEN.Producto.Referencia = p_producto;
        }

        //Call to VentaCAD

        oid = _IVentaCAD.NuevaVenta (ventaEN);
        return oid;
}

public void Destroy (int id)
{
        _IVentaCAD.Destroy (id);
}

public void Modify (int p_Venta_OID)
{
        VentaEN ventaEN = null;

        //Initialized VentaEN
        ventaEN = new VentaEN ();
        ventaEN.Id = p_Venta_OID;
        //Call to VentaCAD

        _IVentaCAD.Modify (ventaEN);
}
}
}
