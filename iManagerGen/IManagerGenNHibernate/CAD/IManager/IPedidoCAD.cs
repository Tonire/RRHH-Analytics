
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IPedidoCAD
{
PedidoEN ReadOIDDefault (int id);

int CrearPedido (PedidoEN pedido);

void Modify (PedidoEN pedido);


void Destroy (int id);
}
}
