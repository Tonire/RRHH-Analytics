
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
 * Clase Turno:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class TurnoCAD : BasicCAD, ITurnoCAD
{
public TurnoCAD() : base ()
{
}

public TurnoCAD(ISession sessionAux) : base (sessionAux)
{
}



public TurnoEN ReadOIDDefault (int id)
{
        TurnoEN turnoEN = null;

        try
        {
                SessionInitializeTransaction ();
                turnoEN = (TurnoEN)session.Get (typeof(TurnoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in TurnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return turnoEN;
}

public System.Collections.Generic.IList<TurnoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TurnoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TurnoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TurnoEN>();
                        else
                                result = session.CreateCriteria (typeof(TurnoEN)).List<TurnoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in TurnoCAD.", ex);
        }

        return result;
}

public int CrearTurno (TurnoEN turno)
{
        try
        {
                SessionInitializeTransaction ();
                if (turno.Horario != null) {
                        // Argumento OID y no colección.
                        turno.Horario = (IManagerGenNHibernate.EN.IManager.HorarioEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.HorarioEN), turno.Horario.Titulo);

                        turno.Horario.Turno
                        .Add (turno);
                }

                session.Save (turno);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in TurnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return turno.Id;
}

public void Modify (TurnoEN turno)
{
        try
        {
                SessionInitializeTransaction ();
                TurnoEN turnoEN = (TurnoEN)session.Load (typeof(TurnoEN), turno.Id);

                turnoEN.Nombre = turno.Nombre;


                turnoEN.Desde = turno.Desde;


                turnoEN.Hasta = turno.Hasta;

                session.Update (turnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in TurnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                TurnoEN turnoEN = (TurnoEN)session.Load (typeof(TurnoEN), id);
                session.Delete (turnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in TurnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.TurnoEN> GetTurnosByHorario (string p_horario)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.TurnoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TurnoEN self where select turn FROM TurnoEN as turn inner join turn.Horario as hor where hor.Titulo=:p_horario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TurnoENgetTurnosByHorarioHQL");
                query.SetParameter ("p_horario", p_horario);

                result = query.List<IManagerGenNHibernate.EN.IManager.TurnoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in TurnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
