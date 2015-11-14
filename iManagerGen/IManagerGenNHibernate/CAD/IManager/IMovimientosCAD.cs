
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

System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientosByAnyoMes (string tipoMovimiento, int anyoMovimiento, int mesMovimiento);


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientosByAnyo (string tipoMovimiento, int anyoMovimiento);


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetBalanceByMesAnyo (string arg0, string arg1);


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetBalanceByAnyo (string arg0);


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientoTotalMesAnyo (int mesMovimiento, int anyoMovimiento, string tipoMovimiento);


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientoTotalAnyo (string tipoMovimiento, int anyoMovimiento);
}
}
