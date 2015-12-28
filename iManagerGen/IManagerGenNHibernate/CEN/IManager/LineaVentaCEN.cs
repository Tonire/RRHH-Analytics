

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
 *      Definition of the class LineaVentaCEN
 *
 */
public partial class LineaVentaCEN
{
private ILineaVentaCAD _ILineaVentaCAD;

public LineaVentaCEN()
{
        this._ILineaVentaCAD = new LineaVentaCAD ();
}

public LineaVentaCEN(ILineaVentaCAD _ILineaVentaCAD)
{
        this._ILineaVentaCAD = _ILineaVentaCAD;
}

public ILineaVentaCAD get_ILineaVentaCAD ()
{
        return this._ILineaVentaCAD;
}

public int CrearLineaVenta (int p_cantidad, string p_producto)
{
        LineaVentaEN lineaVentaEN = null;
        int oid;

        //Initialized LineaVentaEN
        lineaVentaEN = new LineaVentaEN ();
        lineaVentaEN.Cantidad = p_cantidad;


        if (p_producto != null) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                lineaVentaEN.Producto = new IManagerGenNHibernate.EN.IManager.ProductoEN ();
                lineaVentaEN.Producto.Referencia = p_producto;
        }

        //Call to LineaVentaCAD

        oid = _ILineaVentaCAD.CrearLineaVenta (lineaVentaEN);
        return oid;
}

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaVentaEN> GetLineasVentaByVenta (int p_venta)
{
        return _ILineaVentaCAD.GetLineasVentaByVenta (p_venta);
}
public LineaVentaEN GetLineaVentaOID (int id)
{
        LineaVentaEN lineaVentaEN = null;

        lineaVentaEN = _ILineaVentaCAD.GetLineaVentaOID (id);
        return lineaVentaEN;
}
}
}
