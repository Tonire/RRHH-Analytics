
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IEmpleadoCAD
{
EmpleadoEN ReadOIDDefault (string email);

string New_ (EmpleadoEN empleado);
}
}
