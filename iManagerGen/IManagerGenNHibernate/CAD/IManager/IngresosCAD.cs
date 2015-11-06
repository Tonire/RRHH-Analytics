
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
 * Clase Ingresos:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class IngresosCAD : BasicCAD, IIngresosCAD
{
public IngresosCAD() : base ()
{
}

public IngresosCAD(ISession sessionAux) : base (sessionAux)
{
}



public IngresosEN ReadOIDDefault (IManagerGenNHibernate.EN.IManager.IngresosEN_OID ingresosEN_OID)
{
        IngresosEN ingresosEN = null;

        try
        {
                SessionInitializeTransaction ();
                ingresosEN = (IngresosEN)session.Get (typeof(IngresosEN), ingresosEN_OID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in IngresosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ingresosEN;
}

public System.Collections.Generic.IList<IngresosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<IngresosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(IngresosEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<IngresosEN>();
                        else
                                result = session.CreateCriteria (typeof(IngresosEN)).List<IngresosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in IngresosCAD.", ex);
        }

        return result;
}

public IManagerGenNHibernate.EN.IManager.IngresosEN_OID CrearIngreso (IngresosEN ingresos)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (ingresos);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in IngresosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ingresos.IngresosOID;
}
}
}
