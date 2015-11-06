
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
 * Clase Dia:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class DiaCAD : BasicCAD, IDiaCAD
{
public DiaCAD() : base ()
{
}

public DiaCAD(ISession sessionAux) : base (sessionAux)
{
}



public DiaEN ReadOIDDefault (IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum dia)
{
        DiaEN diaEN = null;

        try
        {
                SessionInitializeTransaction ();
                diaEN = (DiaEN)session.Get (typeof(DiaEN), dia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in DiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return diaEN;
}

public System.Collections.Generic.IList<DiaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DiaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DiaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<DiaEN>();
                        else
                                result = session.CreateCriteria (typeof(DiaEN)).List<DiaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in DiaCAD.", ex);
        }

        return result;
}

public IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum CrearDia (DiaEN dia)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (dia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in DiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return dia.Dia;
}

public void Destroy (IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum dia)
{
        try
        {
                SessionInitializeTransaction ();
                DiaEN diaEN = (DiaEN)session.Load (typeof(DiaEN), dia);
                session.Delete (diaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in DiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarTurno (IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum p_Dia_OID, int p_turno_OID)
{
        IManagerGenNHibernate.EN.IManager.DiaEN diaEN = null;
        try
        {
                SessionInitializeTransaction ();
                diaEN = (DiaEN)session.Load (typeof(DiaEN), p_Dia_OID);
                diaEN.Turno = (IManagerGenNHibernate.EN.IManager.TurnoEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.TurnoEN), p_turno_OID);

                diaEN.Turno.Fecha.Add (diaEN);



                session.Update (diaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in DiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
