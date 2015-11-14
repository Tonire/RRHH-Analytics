

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

public string New_ (string p_email, string p_DNI, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fechaRegistro)
{
        SuperAdministradorEN superAdministradorEN = null;
        string oid;

        //Initialized SuperAdministradorEN
        superAdministradorEN = new SuperAdministradorEN ();
        superAdministradorEN.Email = p_email;

        superAdministradorEN.DNI = p_DNI;

        superAdministradorEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        superAdministradorEN.Nombre = p_nombre;

        superAdministradorEN.Apellidos = p_apellidos;

        superAdministradorEN.FechaRegistro = p_fechaRegistro;

        //Call to SuperAdministradorCAD

        oid = _ISuperAdministradorCAD.New_ (superAdministradorEN);
        return oid;
}
}
}
