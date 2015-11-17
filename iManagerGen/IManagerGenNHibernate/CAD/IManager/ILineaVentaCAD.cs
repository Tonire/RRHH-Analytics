
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface ILineaVentaCAD
{
LineaVentaEN ReadOIDDefault (int id);


int CrearLineaVenta (LineaVentaEN lineaVenta);

System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaVentaEN> GetLineasVentaByVenta (int p_venta);
}
}
