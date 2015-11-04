

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
 *      Definition of the class BalanceCEN
 *
 */
public partial class BalanceCEN
{
private IBalanceCAD _IBalanceCAD;

public BalanceCEN()
{
        this._IBalanceCAD = new BalanceCAD ();
}

public BalanceCEN(IBalanceCAD _IBalanceCAD)
{
        this._IBalanceCAD = _IBalanceCAD;
}

public IBalanceCAD get_IBalanceCAD ()
{
        return this._IBalanceCAD;
}

public int CrearBalance (int p_anyo, int p_mes, double p_gastos, double p_ingresos)
{
        BalanceEN balanceEN = null;
        int oid;

        //Initialized BalanceEN
        balanceEN = new BalanceEN ();
        balanceEN.Anyo = p_anyo;

        balanceEN.Mes = p_mes;

        balanceEN.Gastos = p_gastos;

        balanceEN.Ingresos = p_ingresos;

        //Call to BalanceCAD

        oid = _IBalanceCAD.CrearBalance (balanceEN);
        return oid;
}

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.BalanceEN> GetBalancesPorAnyo ()
{
        return _IBalanceCAD.GetBalancesPorAnyo ();
}
}
}
