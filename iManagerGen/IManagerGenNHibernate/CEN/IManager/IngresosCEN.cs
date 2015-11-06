

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
 *      Definition of the class IngresosCEN
 *
 */
public partial class IngresosCEN
{
private IIngresosCAD _IIngresosCAD;

public IngresosCEN()
{
        this._IIngresosCAD = new IngresosCAD ();
}

public IngresosCEN(IIngresosCAD _IIngresosCAD)
{
        this._IIngresosCAD = _IIngresosCAD;
}

public IIngresosCAD get_IIngresosCAD ()
{
        return this._IIngresosCAD;
}

public IManagerGenNHibernate.EN.IManager.IngresosEN_OID CrearIngreso (string p_anyo, string p_mes, float p_ingresos)
{
        IngresosEN ingresosEN = null;

        IManagerGenNHibernate.EN.IManager.IngresosEN_OID oid;
        //Initialized IngresosEN
        ingresosEN = new IngresosEN ();
        ingresosEN.IngresosOID = new IManagerGenNHibernate.EN.IManager.IngresosEN_OID ();
        ingresosEN.IngresosOID.Anyo = p_anyo;

        ingresosEN.IngresosOID.Mes = p_mes;

        ingresosEN.Ingresos = p_ingresos;

        //Call to IngresosCAD

        oid = _IIngresosCAD.CrearIngreso (ingresosEN);
        return oid;
}
}
}
