
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
 * Clase Gastos:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class GastosCAD : BasicCAD, IGastosCAD
{
public GastosCAD() : base ()
{
}

public GastosCAD(ISession sessionAux) : base (sessionAux)
{
}



public GastosEN ReadOIDDefault (IManagerGenNHibernate.EN.IManager.GastosEN_OID gastosEN_OID)
{
        GastosEN gastosEN = null;

        try
        {
                SessionInitializeTransaction ();
                gastosEN = (GastosEN)session.Get (typeof(GastosEN), gastosEN_OID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in GastosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return gastosEN;
}

public System.Collections.Generic.IList<GastosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<GastosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GastosEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GastosEN>();
                        else
                                result = session.CreateCriteria (typeof(GastosEN)).List<GastosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in GastosCAD.", ex);
        }

        return result;
}

public IManagerGenNHibernate.EN.IManager.GastosEN_OID CrearGasto (GastosEN gastos)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (gastos);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in GastosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return gastos.GastosOID;
}
}
}
