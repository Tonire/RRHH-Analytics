
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


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> GetPedidosPendientes ();


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> GetPedidosConfirmados ();


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> GetPedidosCancelados ();


PedidoEN GetPedidoById (int id);


System.Collections.Generic.IList<PedidoEN> DameTodos (int first, int size);


long ContarPedidosPendientes ();


long ContarPedidos ();
}
}
