

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

public int CrearMovimiento (int p_anyo, int p_mes, string p_tipo, double p_cantidad)
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
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientosByAnyoMes (string p_tipomovimiento, int p_anyomovimiento, int p_mesmovimiento)
{
        return _IMovimientosCAD.GetMovimientosByAnyoMes (p_tipomovimiento, p_anyomovimiento, p_mesmovimiento);
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientosByAnyo (string p_tipomovimiento, int p_anyomovimiento)
{
        return _IMovimientosCAD.GetMovimientosByAnyo (p_tipomovimiento, p_anyomovimiento);
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetBalanceByMesAnyo ()
{
        return _IMovimientosCAD.GetBalanceByMesAnyo ();
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetBalanceByAnyo ()
{
        return _IMovimientosCAD.GetBalanceByAnyo ();
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientoTotalMesAnyo (int p_mesmovimiento, int p_anyomovimiento, string p_tipomovimiento)
{
        return _IMovimientosCAD.GetMovimientoTotalMesAnyo (p_mesmovimiento, p_anyomovimiento, p_tipomovimiento);
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientoTotalAnyo (string p_tipomovimiento, int p_anyomovimiento)
{
        return _IMovimientosCAD.GetMovimientoTotalAnyo (p_tipomovimiento, p_anyomovimiento);
}
}
}
