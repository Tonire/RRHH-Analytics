

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
 *      Definition of the class VentasCEN
 *
 */
public partial class VentasCEN
{
private IVentasCAD _IVentasCAD;

public VentasCEN()
{
        this._IVentasCAD = new VentasCAD ();
}

public VentasCEN(IVentasCAD _IVentasCAD)
{
        this._IVentasCAD = _IVentasCAD;
}

public IVentasCAD get_IVentasCAD ()
{
        return this._IVentasCAD;
}

public int NuevaVenta (string p_usuario, int p_producto)
{
        VentasEN ventasEN = null;
        int oid;

        //Initialized VentasEN
        ventasEN = new VentasEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                ventasEN.Usuario = new IManagerGenNHibernate.EN.IManager.UsuarioEN ();
                ventasEN.Usuario.Email = p_usuario;
        }


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                ventasEN.Producto = new IManagerGenNHibernate.EN.IManager.ProductoEN ();
                ventasEN.Producto.Referencia = p_producto;
        }

        //Call to VentasCAD

        oid = _IVentasCAD.NuevaVenta (ventasEN);
        return oid;
}

public void Destroy (int id)
{
        _IVentasCAD.Destroy (id);
}

public void Modify (int p_Ventas_OID)
{
        VentasEN ventasEN = null;

        //Initialized VentasEN
        ventasEN = new VentasEN ();
        ventasEN.Id = p_Ventas_OID;
        //Call to VentasCAD

        _IVentasCAD.Modify (ventasEN);
}
}
}
