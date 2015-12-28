
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


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> GetVentasByUsuario (string p_usuario);


VentaEN GetVentaById (int id);


int ContarVentas ();
}
}
