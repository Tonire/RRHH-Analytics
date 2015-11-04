
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
 * Clase Horario:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class HorarioCAD : BasicCAD, IHorarioCAD
{
public HorarioCAD() : base ()
{
}

public HorarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public HorarioEN ReadOIDDefault (int id)
{
        HorarioEN horarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                horarioEN = (HorarioEN)session.Get (typeof(HorarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in HorarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return horarioEN;
}

public System.Collections.Generic.IList<HorarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<HorarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(HorarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<HorarioEN>();
                        else
                                result = session.CreateCriteria (typeof(HorarioEN)).List<HorarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in HorarioCAD.", ex);
        }

        return result;
}

public void Modify (HorarioEN horario)
{
        try
        {
                SessionInitializeTransaction ();
                HorarioEN horarioEN = (HorarioEN)session.Load (typeof(HorarioEN), horario.Id);

                horarioEN.Anyo = horario.Anyo;


                horarioEN.Titulo = horario.Titulo;

                session.Update (horarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in HorarioCAD.", ex);
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
                HorarioEN horarioEN = (HorarioEN)session.Load (typeof(HorarioEN), id);
                session.Delete (horarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in HorarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int CreaHorario (HorarioEN horario)
{
        try
        {
                SessionInitializeTransaction ();
                if (horario.Fecha != null) {
                        foreach (IManagerGenNHibernate.EN.IManager.FechaEN item in horario.Fecha) {
                                item.Horario = horario;
                                session.Save (item);
                        }
                }

                session.Save (horario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in HorarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return horario.Id;
}
}
}
