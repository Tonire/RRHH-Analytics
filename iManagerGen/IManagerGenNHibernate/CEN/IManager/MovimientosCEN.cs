

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
 *      Definition of the class MovimientosCEN
 *
 */
public partial class MovimientosCEN
{
private IMovimientosCAD _IMovimientosCAD;

public MovimientosCEN()
{
        this._IMovimientosCAD = new MovimientosCAD ();
}

public MovimientosCEN(IMovimientosCAD _IMovimientosCAD)
{
        this._IMovimientosCAD = _IMovimientosCAD;
}

public IMovimientosCAD get_IMovimientosCAD ()
{
        return this._IMovimientosCAD;
}

public int CrearMovimiento (int p_anyo, int p_mes, string p_tipo, double p_cantidad, int p_pedido, int p_venta)
{
        MovimientosEN movimientosEN = null;
        int oid;

        //Initialized MovimientosEN
        movimientosEN = new MovimientosEN ();
        movimientosEN.Anyo = p_anyo;

        movimientosEN.Mes = p_mes;

        movimientosEN.Tipo = p_tipo;

        movimientosEN.Cantidad = p_cantidad;


        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids id
                movimientosEN.Pedido = new IManagerGenNHibernate.EN.IManager.PedidoEN ();
                movimientosEN.Pedido.Id = p_pedido;
        }


        if (p_venta != -1) {
                // El argumento p_venta -> Property venta es oid = false
                // Lista de oids id
                movimientosEN.Venta = new IManagerGenNHibernate.EN.IManager.VentaEN ();
                movimientosEN.Venta.Id = p_venta;
        }

        //Call to MovimientosCAD

        oid = _IMovimientosCAD.CrearMovimiento (movimientosEN);
        return oid;
}
}
}
