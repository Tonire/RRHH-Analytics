
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IIngresosCAD
{
IngresosEN ReadOIDDefault (IManagerGenNHibernate.EN.IManager.IngresosEN_OID ingresosEN_OID);

IManagerGenNHibernate.EN.IManager.IngresosEN_OID CrearIngreso (IngresosEN ingresos);
}
}
