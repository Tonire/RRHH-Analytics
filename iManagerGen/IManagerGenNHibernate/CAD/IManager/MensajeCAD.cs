
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
 * Clase Mensaje:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class MensajeCAD : BasicCAD, IMensajeCAD
{
public MensajeCAD() : base ()
{
}

public MensajeCAD(ISession sessionAux) : base (sessionAux)
{
}



public MensajeEN ReadOIDDefault (int id)
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MensajeEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MensajeEN>();
                        else
                                result = session.CreateCriteria (typeof(MensajeEN)).List<MensajeEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }

        return result;
}

public int CreaMensaje (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                if (mensaje.Remitente != null) {
                        // Argumento OID y no colección.
                        mensaje.Remitente = (IManagerGenNHibernate.EN.IManager.UsuarioEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.UsuarioEN), mensaje.Remitente.Email);

                        mensaje.Remitente.MensajesEnviados
                        .Add (mensaje);
                }
                if (mensaje.Destinatario != null) {
                        // Argumento OID y no colección.
                        mensaje.Destinatario = (IManagerGenNHibernate.EN.IManager.UsuarioEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.UsuarioEN), mensaje.Destinatario.Email);

                        mensaje.Destinatario.MensajesRecibidos
                        .Add (mensaje);
                }

                session.Save (mensaje);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensaje.Id;
}

//Sin e: GetMensaje
//Con e: MensajeEN
public MensajeEN GetMensaje (int id)
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensajeEN;
}

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> GetMensajesByRemitente (string p_email)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN where Remitente.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENgetMensajesByRemitenteHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<IManagerGenNHibernate.EN.IManager.MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> GetMensajesByDestinatario (string p_email, int first, int size)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN where Destinatario.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENgetMensajesByDestinatarioHQL");
                query.SetParameter ("p_email", p_email);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<IManagerGenNHibernate.EN.IManager.MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Modify (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeEN mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), mensaje.Id);

                mensajeEN.Asunto = mensaje.Asunto;


                mensajeEN.Contenido = mensaje.Contenido;


                mensajeEN.Leido = mensaje.Leido;


                mensajeEN.Fecha = mensaje.Fecha;


                mensajeEN.Borrado = mensaje.Borrado;

                session.Update (mensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public long ContarMensajesNoLeidosByDestinatario (string p_email)
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where select count(*) FROM MensajeEN where Destinatario.Email=:p_email and leido=false";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENcontarMensajesNoLeidosByDestinatarioHQL");
                query.SetParameter ("p_email", p_email);


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeEN mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), id);
                session.Delete (mensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
