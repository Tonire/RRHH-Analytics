
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface ILineaPedidoCAD
{
LineaPedidoEN ReadOIDDefault (int id);

int CrearLineaPedido (LineaPedidoEN lineaPedido);

void RelationerLinea (int p_LineaPedido_OID, int p_pedido_OID);
}
}
