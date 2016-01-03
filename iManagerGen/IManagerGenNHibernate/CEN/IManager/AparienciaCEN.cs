

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
 *      Definition of the class AparienciaCEN
 *
 */
public partial class AparienciaCEN
{
private IAparienciaCAD _IAparienciaCAD;

public AparienciaCEN()
{
        this._IAparienciaCAD = new AparienciaCAD ();
}

public AparienciaCEN(IAparienciaCAD _IAparienciaCAD)
{
        this._IAparienciaCAD = _IAparienciaCAD;
}

public IAparienciaCAD get_IAparienciaCAD ()
{
        return this._IAparienciaCAD;
}

public string CrearApariencia (string p_nombre, string p_logo, string p_superAdmin, string p_admin, string p_empleado)
{
        AparienciaEN aparienciaEN = null;
        string oid;

        //Initialized AparienciaEN
        aparienciaEN = new AparienciaEN ();
        aparienciaEN.Nombre = p_nombre;

        aparienciaEN.Logo = p_logo;

        aparienciaEN.SuperAdmin = p_superAdmin;

        aparienciaEN.Admin = p_admin;

        aparienciaEN.Empleado = p_empleado;

        //Call to AparienciaCAD

        oid = _IAparienciaCAD.CrearApariencia (aparienciaEN);
        return oid;
}

public System.Collections.Generic.IList<AparienciaEN> GetApariencia (int first, int size)
{
        System.Collections.Generic.IList<AparienciaEN> list = null;

        list = _IAparienciaCAD.GetApariencia (first, size);
        return list;
}
public void Modify (string p_Apariencia_OID, string p_logo, string p_superAdmin, string p_admin, string p_empleado)
{
        AparienciaEN aparienciaEN = null;

        //Initialized AparienciaEN
        aparienciaEN = new AparienciaEN ();
        aparienciaEN.Nombre = p_Apariencia_OID;
        aparienciaEN.Logo = p_logo;
        aparienciaEN.SuperAdmin = p_superAdmin;
        aparienciaEN.Admin = p_admin;
        aparienciaEN.Empleado = p_empleado;
        //Call to AparienciaCAD

        _IAparienciaCAD.Modify (aparienciaEN);
}

public void Destroy (string nombre)
{
        _IAparienciaCAD.Destroy (nombre);
}
}
}
