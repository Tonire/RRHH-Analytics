
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string email);

string New_ (AdministradorEN administrador);
}
}
