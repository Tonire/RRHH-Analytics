
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




System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetGastosByAnyo (Nullable<DateTime> fechaPedido);
}
}
