
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IFechaCAD
{
FechaEN ReadOIDDefault (Nullable<DateTime> fecha);

Nullable<DateTime> CrearFecha (FechaEN fecha);

void Destroy (Nullable<DateTime> fecha);
}
}
