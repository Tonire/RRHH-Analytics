
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface ILineaPedidoCAD
{
LineaPedidoEN ReadOIDDefault (int id);

int CrearLineaPedido (LineaPedidoEN lineaPedido);

void RelationerLineaPedido (int p_LineaPedido_OID, int p_pedido_OID);

System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> GetLineasPedidoByPedido (int p_pedido);
}
}
