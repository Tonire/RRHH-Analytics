
using System;
using System.Text;
using IManagerGenNHibernate.CEN.IManager;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.Exceptions;

/*
 * Clase Balance:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class BalanceCAD : BasicCAD, IBalanceCAD
{
public BalanceCAD() : base ()
{
}

public BalanceCAD(ISession sessionAux) : base (sessionAux)
{
}



public BalanceEN ReadOIDDefault (int anyo)
{
        BalanceEN balanceEN = null;

        try
        {
                SessionInitializeTransaction ();
                balanceEN = (BalanceEN)session.Get (typeof(BalanceEN), anyo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in BalanceCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return balanceEN;
}

public System.Collections.Generic.IList<BalanceEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<BalanceEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(BalanceEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<BalanceEN>();
                        else
                                result = session.CreateCriteria (typeof(BalanceEN)).List<BalanceEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in BalanceCAD.", ex);
        }

        return result;
}

public int CrearBalance (BalanceEN balance)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (balance);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in BalanceCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return balance.Anyo;
}

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.BalanceEN> GetBalancesPorAnyo ()
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.BalanceEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM BalanceEN self where FROM BalanceEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("BalanceENgetBalancesPorAnyoHQL");

                result = query.List<IManagerGenNHibernate.EN.IManager.BalanceEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in BalanceCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
