

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
 *      Definition of the class GastosCEN
 *
 */
public partial class GastosCEN
{
private IGastosCAD _IGastosCAD;

public GastosCEN()
{
        this._IGastosCAD = new GastosCAD ();
}

public GastosCEN(IGastosCAD _IGastosCAD)
{
        this._IGastosCAD = _IGastosCAD;
}

public IGastosCAD get_IGastosCAD ()
{
        return this._IGastosCAD;
}

public IManagerGenNHibernate.EN.IManager.GastosEN_OID CrearGasto (string p_anyo, string p_mes, float p_gastos)
{
        GastosEN gastosEN = null;

        IManagerGenNHibernate.EN.IManager.GastosEN_OID oid;
        //Initialized GastosEN
        gastosEN = new GastosEN ();
        gastosEN.GastosOID = new IManagerGenNHibernate.EN.IManager.GastosEN_OID ();
        gastosEN.GastosOID.Anyo = p_anyo;

        gastosEN.GastosOID.Mes = p_mes;

        gastosEN.Gastos = p_gastos;

        //Call to GastosCAD

        oid = _IGastosCAD.CrearGasto (gastosEN);
        return oid;
}
}
}
