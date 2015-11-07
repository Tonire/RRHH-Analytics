
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



public HorarioEN ReadOIDDefault (string titulo)
{
        HorarioEN horarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                horarioEN = (HorarioEN)session.Get (typeof(HorarioEN), titulo);
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
                HorarioEN horarioEN = (HorarioEN)session.Load (typeof(HorarioEN), horario.Titulo);

                horarioEN.Anyo = horario.Anyo;

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
public void Destroy (string titulo)
{
        try
        {
                SessionInitializeTransaction ();
                HorarioEN horarioEN = (HorarioEN)session.Load (typeof(HorarioEN), titulo);
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

public string CreaHorario (HorarioEN horario)
{
        try
        {
                SessionInitializeTransaction ();
                if (horario.Usuario != null) {
                        for (int i = 0; i < horario.Usuario.Count; i++) {
                                horario.Usuario [i] = (IManagerGenNHibernate.EN.IManager.UsuarioEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.UsuarioEN), horario.Usuario [i].Email);
                                horario.Usuario [i].Horario.Add (horario);
                        }
                }
                if (horario.Turno != null) {
                        foreach (IManagerGenNHibernate.EN.IManager.TurnoEN item in horario.Turno) {
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

        return horario.Titulo;
}

public void AsignarDias (string p_Horario_OID, System.Collections.Generic.IList<int> p_dia_OIDs)
{
        IManagerGenNHibernate.EN.IManager.HorarioEN horarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                horarioEN = (HorarioEN)session.Load (typeof(HorarioEN), p_Horario_OID);
                IManagerGenNHibernate.EN.IManager.DiaEN diaENAux = null;
                if (horarioEN.Dia == null) {
                        horarioEN.Dia = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.DiaEN>();
                }

                foreach (int item in p_dia_OIDs) {
                        diaENAux = new IManagerGenNHibernate.EN.IManager.DiaEN ();
                        diaENAux = (IManagerGenNHibernate.EN.IManager.DiaEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.DiaEN), item);
                        diaENAux.Horario = horarioEN;

                        horarioEN.Dia.Add (diaENAux);
                }


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

public IManagerGenNHibernate.EN.IManager.HorarioEN GetHorarioByUsuario (string p_usuario)
{
        IManagerGenNHibernate.EN.IManager.HorarioEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM HorarioEN self where FROM HorarioEN where usuario.Email=:p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("HorarioENgetHorarioByUsuarioHQL");
                query.SetParameter ("p_usuario", p_usuario);


                result = query.UniqueResult<IManagerGenNHibernate.EN.IManager.HorarioEN>();
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

        return result;
}
}
}
