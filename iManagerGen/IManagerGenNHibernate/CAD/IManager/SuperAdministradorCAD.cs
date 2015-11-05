
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
 * Clase SuperAdministrador:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class SuperAdministradorCAD : BasicCAD, ISuperAdministradorCAD
{
public SuperAdministradorCAD() : base ()
{
}

public SuperAdministradorCAD(ISession sessionAux) : base (sessionAux)
{
}



public SuperAdministradorEN ReadOIDDefault (string email)
{
        SuperAdministradorEN superAdministradorEN = null;

        try
        {
                SessionInitializeTransaction ();
                superAdministradorEN = (SuperAdministradorEN)session.Get (typeof(SuperAdministradorEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in SuperAdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return superAdministradorEN;
}

public System.Collections.Generic.IList<SuperAdministradorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SuperAdministradorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SuperAdministradorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SuperAdministradorEN>();
                        else
                                result = session.CreateCriteria (typeof(SuperAdministradorEN)).List<SuperAdministradorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in SuperAdministradorCAD.", ex);
        }

        return result;
}

public string New_ (SuperAdministradorEN superAdministrador)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (superAdministrador);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in SuperAdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return superAdministrador.Email;
}
}
}
