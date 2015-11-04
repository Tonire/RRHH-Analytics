
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
 * Clase Empleado:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class EmpleadoCAD : BasicCAD, IEmpleadoCAD
{
public EmpleadoCAD() : base ()
{
}

public EmpleadoCAD(ISession sessionAux) : base (sessionAux)
{
}



public EmpleadoEN ReadOIDDefault (string email)
{
        EmpleadoEN empleadoEN = null;

        try
        {
                SessionInitializeTransaction ();
                empleadoEN = (EmpleadoEN)session.Get (typeof(EmpleadoEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in EmpleadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return empleadoEN;
}

public System.Collections.Generic.IList<EmpleadoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EmpleadoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EmpleadoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EmpleadoEN>();
                        else
                                result = session.CreateCriteria (typeof(EmpleadoEN)).List<EmpleadoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in EmpleadoCAD.", ex);
        }

        return result;
}

public string New_ (EmpleadoEN empleado)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (empleado);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in EmpleadoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return empleado.Email;
}
}
}
