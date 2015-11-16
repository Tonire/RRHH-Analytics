
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IMovimientosCAD
{
MovimientosEN ReadOIDDefault (int id);

int CrearMovimiento (MovimientosEN movimientos);

void RelationerPedido (int p_Movimientos_OID, int p_pedido_OID);

void RelationerVenta (int p_Movimientos_OID, int p_venta_OID);

System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientosByAnyoMes (string p_tipomovimiento, int p_anyomovimiento, int p_mesmovimiento);


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientosByAnyo (string p_tipomovimiento, int p_anyomovimiento);


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetBalanceByMesAnyo ();


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetBalanceByAnyo ();


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientoTotalMesAnyo (int p_mesmovimiento, int p_anyomovimiento, string p_tipomovimiento);


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientoTotalAnyo (string p_tipomovimiento, int p_anyomovimiento);
}
}
