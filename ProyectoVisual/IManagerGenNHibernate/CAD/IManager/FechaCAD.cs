
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
 * Clase Fecha:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class FechaCAD : BasicCAD, IFechaCAD
{
public FechaCAD() : base ()
{
}

public FechaCAD(ISession sessionAux) : base (sessionAux)
{
}



public FechaEN ReadOIDDefault (Nullable<DateTime> fecha)
{
        FechaEN fechaEN = null;

        try
        {
                SessionInitializeTransaction ();
                fechaEN = (FechaEN)session.Get (typeof(FechaEN), fecha);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in FechaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return fechaEN;
}

public System.Collections.Generic.IList<FechaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FechaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FechaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<FechaEN>();
                        else
                                result = session.CreateCriteria (typeof(FechaEN)).List<FechaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in FechaCAD.", ex);
        }

        return result;
}

public Nullable<DateTime> CrearFecha (FechaEN fecha)
{
        try
        {
                SessionInitializeTransaction ();
                if (fecha.Turno != null) {
                        // Argumento OID y no colección.
                        fecha.Turno = (IManagerGenNHibernate.EN.IManager.TurnoEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.TurnoEN), fecha.Turno.Id);

                        fecha.Turno.Fecha
                        .Add (fecha);
                }

                session.Save (fecha);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in FechaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return fecha.Fecha;
}

public void Destroy (Nullable<DateTime> fecha)
{
        try
        {
                SessionInitializeTransaction ();
                FechaEN fechaEN = (FechaEN)session.Load (typeof(FechaEN), fecha);
                session.Delete (fechaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in FechaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
