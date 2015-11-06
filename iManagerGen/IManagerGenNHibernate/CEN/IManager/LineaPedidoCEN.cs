

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
 *      Definition of the class LineaPedidoCEN
 *
 */
public partial class LineaPedidoCEN
{
private ILineaPedidoCAD _ILineaPedidoCAD;

public LineaPedidoCEN()
{
        this._ILineaPedidoCAD = new LineaPedidoCAD ();
}

public LineaPedidoCEN(ILineaPedidoCAD _ILineaPedidoCAD)
{
        this._ILineaPedidoCAD = _ILineaPedidoCAD;
}

public ILineaPedidoCAD get_ILineaPedidoCAD ()
{
        return this._ILineaPedidoCAD;
}

public int CrearLineaPedido (int p_cantidad, int p_producto)
{
        LineaPedidoEN lineaPedidoEN = null;
        int oid;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();
        lineaPedidoEN.Cantidad = p_cantidad;


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids id
                lineaPedidoEN.Producto = new IManagerGenNHibernate.EN.IManager.ProductoEN ();
                lineaPedidoEN.Producto.Referencia = p_producto;
        }

        //Call to LineaPedidoCAD

        oid = _ILineaPedidoCAD.CrearLineaPedido (lineaPedidoEN);
        return oid;
}

public void RelationerLinea (int p_LineaPedido_OID, int p_pedido_OID)
{
        //Call to LineaPedidoCAD

        _ILineaPedidoCAD.RelationerLinea (p_LineaPedido_OID, p_pedido_OID);
}
}
}
