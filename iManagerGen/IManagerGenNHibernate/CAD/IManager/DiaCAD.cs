
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



public DiaEN ReadOIDDefault (int id)
{
        DiaEN diaEN = null;

        try
        {
                SessionInitializeTransaction ();
                diaEN = (DiaEN)session.Get (typeof(DiaEN), id);
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

public int CrearDia (DiaEN dia)
{
        try
        {
                SessionInitializeTransaction ();
                if (dia.Turno != null) {
                        // Argumento OID y no colección.
                        dia.Turno = (IManagerGenNHibernate.EN.IManager.TurnoEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.TurnoEN), dia.Turno.Id);

                        dia.Turno.Fecha
                        .Add (dia);
                }
                if (dia.Horario != null) {
                        // Argumento OID y no colección.
                        dia.Horario = (IManagerGenNHibernate.EN.IManager.HorarioEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.HorarioEN), dia.Horario.Titulo);

                        dia.Horario.Dia
                        .Add (dia);
                }

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

        return dia.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                DiaEN diaEN = (DiaEN)session.Load (typeof(DiaEN), id);
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

public void AsignarTurno (int p_Dia_OID, int p_turno_OID)
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

public System.Collections.Generic.IList<DiaEN> GetAllDias (int first, int size)
{
        System.Collections.Generic.IList<DiaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(DiaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<DiaEN>();
                else
                        result = session.CreateCriteria (typeof(DiaEN)).List<DiaEN>();
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

        return result;
}

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.DiaEN> GetDiasByHorario (string p_horario)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.DiaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM DiaEN self where select dia FROM DiaEN as dia inner join dia.Horario as hor where hor.Titulo=:p_horario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("DiaENgetDiasByHorarioHQL");
                query.SetParameter ("p_horario", p_horario);

                result = query.List<IManagerGenNHibernate.EN.IManager.DiaEN>();
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

        return result;
}
}
}
