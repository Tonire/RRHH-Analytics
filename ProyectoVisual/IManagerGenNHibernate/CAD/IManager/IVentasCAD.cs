
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IVentasCAD
{
VentasEN ReadOIDDefault (int id);

int NuevaVenta (VentasEN ventas);

void Destroy (int id);


void Modify (VentasEN ventas);
}
}
