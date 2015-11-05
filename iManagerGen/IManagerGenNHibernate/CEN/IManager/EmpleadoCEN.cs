

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
 *      Definition of the class EmpleadoCEN
 *
 */
public partial class EmpleadoCEN
{
private IEmpleadoCAD _IEmpleadoCAD;

public EmpleadoCEN()
{
        this._IEmpleadoCAD = new EmpleadoCAD ();
}

public EmpleadoCEN(IEmpleadoCAD _IEmpleadoCAD)
{
        this._IEmpleadoCAD = _IEmpleadoCAD;
}

public IEmpleadoCAD get_IEmpleadoCAD ()
{
        return this._IEmpleadoCAD;
}

public string New_ (string p_email, string p_DNI, String p_password)
{
        EmpleadoEN empleadoEN = null;
        string oid;

        //Initialized EmpleadoEN
        empleadoEN = new EmpleadoEN ();
        empleadoEN.Email = p_email;

        empleadoEN.DNI = p_DNI;

        empleadoEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        //Call to EmpleadoCAD

        oid = _IEmpleadoCAD.New_ (empleadoEN);
        return oid;
}
}
}
