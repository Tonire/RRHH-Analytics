
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface ISuperAdministradorCAD
{
SuperAdministradorEN ReadOIDDefault (string email);

string New_ (SuperAdministradorEN superAdministrador);
}
}
