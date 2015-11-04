
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
 * Clase Apariencia:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class AparienciaCAD : BasicCAD, IAparienciaCAD
{
public AparienciaCAD() : base ()
{
}

public AparienciaCAD(ISession sessionAux) : base (sessionAux)
{
}



public AparienciaEN ReadOIDDefault (string nombre)
{
        AparienciaEN aparienciaEN = null;

        try
        {
                SessionInitializeTransaction ();
                aparienciaEN = (AparienciaEN)session.Get (typeof(AparienciaEN), nombre);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in AparienciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return aparienciaEN;
}

public System.Collections.Generic.IList<AparienciaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AparienciaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AparienciaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AparienciaEN>();
                        else
                                result = session.CreateCriteria (typeof(AparienciaEN)).List<AparienciaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in AparienciaCAD.", ex);
        }

        return result;
}

public string CrearApariencia (AparienciaEN apariencia)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (apariencia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in AparienciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return apariencia.Nombre;
}

public System.Collections.Generic.IList<AparienciaEN> GetApariencia (int first, int size)
{
        System.Collections.Generic.IList<AparienciaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AparienciaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AparienciaEN>();
                else
                        result = session.CreateCriteria (typeof(AparienciaEN)).List<AparienciaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in AparienciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Modify (AparienciaEN apariencia)
{
        try
        {
                SessionInitializeTransaction ();
                AparienciaEN aparienciaEN = (AparienciaEN)session.Load (typeof(AparienciaEN), apariencia.Nombre);

                aparienciaEN.Logo = apariencia.Logo;


                aparienciaEN.Css = apariencia.Css;

                session.Update (aparienciaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in AparienciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
