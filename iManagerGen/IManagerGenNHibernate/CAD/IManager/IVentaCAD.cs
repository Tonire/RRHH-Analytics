
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IVentaCAD
{
VentaEN ReadOIDDefault (int id);

int NuevaVenta (VentaEN venta);

void Destroy (int id);


void Modify (VentaEN venta);
}
}
