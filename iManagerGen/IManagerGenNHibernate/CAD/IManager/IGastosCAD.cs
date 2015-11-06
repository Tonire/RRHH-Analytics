
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IGastosCAD
{
GastosEN ReadOIDDefault (IManagerGenNHibernate.EN.IManager.GastosEN_OID gastosEN_OID);

IManagerGenNHibernate.EN.IManager.GastosEN_OID CrearGasto (GastosEN gastos);
}
}
