

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;

namespace IManagerGenNHibernate.CEN.IManager
{
/*
 *      Definition of the class SuperAdministradorCEN
 *
 */
public partial class SuperAdministradorCEN
{
private ISuperAdministradorCAD _ISuperAdministradorCAD;

public SuperAdministradorCEN()
{
        this._ISuperAdministradorCAD = new SuperAdministradorCAD ();
}

public SuperAdministradorCEN(ISuperAdministradorCAD _ISuperAdministradorCAD)
{
        this._ISuperAdministradorCAD = _ISuperAdministradorCAD;
}

public ISuperAdministradorCAD get_ISuperAdministradorCAD ()
{
        return this._ISuperAdministradorCAD;
}
}
}
