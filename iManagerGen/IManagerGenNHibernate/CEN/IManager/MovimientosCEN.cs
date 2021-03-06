

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

public int CrearMovimiento (int p_anyo, int p_mes, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum p_tipo, double p_cantidad)
{
        MovimientosEN movimientosEN = null;
        int oid;

        //Initialized MovimientosEN
        movimientosEN = new MovimientosEN ();
        movimientosEN.Anyo = p_anyo;

        movimientosEN.Mes = p_mes;

        movimientosEN.Tipo = p_tipo;

        movimientosEN.Cantidad = p_cantidad;

        //Call to MovimientosCAD

        oid = _IMovimientosCAD.CrearMovimiento (movimientosEN);
        return oid;
}

public void RelationerPedido (int p_Movimientos_OID, int p_pedido_OID)
{
        //Call to MovimientosCAD

        _IMovimientosCAD.RelationerPedido (p_Movimientos_OID, p_pedido_OID);
}
public void RelationerVenta (int p_Movimientos_OID, int p_venta_OID)
{
        //Call to MovimientosCAD

        _IMovimientosCAD.RelationerVenta (p_Movimientos_OID, p_venta_OID);
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientosByAnyo (int p_anyomovimiento, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum p_tipomovimiento)
{
        return _IMovimientosCAD.GetMovimientosByAnyo (p_anyomovimiento, p_tipomovimiento);
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientosByAnyoMes (int p_mesmovimiento, int p_anyomovimiento, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum p_tipomovimiento)
{
        return _IMovimientosCAD.GetMovimientosByAnyoMes (p_mesmovimiento, p_anyomovimiento, p_tipomovimiento);
}
}
}
