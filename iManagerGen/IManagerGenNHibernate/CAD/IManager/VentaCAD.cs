
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
 * Clase Venta:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class VentaCAD : BasicCAD, IVentaCAD
{
public VentaCAD() : base ()
{
}

public VentaCAD(ISession sessionAux) : base (sessionAux)
{
}



public VentaEN ReadOIDDefault (int id)
{
        VentaEN ventaEN = null;

        try
        {
                SessionInitializeTransaction ();
                ventaEN = (VentaEN)session.Get (typeof(VentaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ventaEN;
}

public System.Collections.Generic.IList<VentaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<VentaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(VentaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<VentaEN>();
                        else
                                result = session.CreateCriteria (typeof(VentaEN)).List<VentaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentaCAD.", ex);
        }

        return result;
}

public int NuevaVenta (VentaEN venta)
{
        try
        {
                SessionInitializeTransaction ();
                if (venta.Usuario != null) {
                        // Argumento OID y no colección.
                        venta.Usuario = (IManagerGenNHibernate.EN.IManager.UsuarioEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.UsuarioEN), venta.Usuario.Email);

                        venta.Usuario.Ventas
                        .Add (venta);
                }
                if (venta.LineaVenta != null) {
                        foreach (IManagerGenNHibernate.EN.IManager.LineaVentaEN item in venta.LineaVenta) {
                                item.Venta.Add (venta);
                                session.Save (item);
                        }
                }

                session.Save (venta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return venta.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                VentaEN ventaEN = (VentaEN)session.Load (typeof(VentaEN), id);
                session.Delete (ventaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (VentaEN venta)
{
        try
        {
                SessionInitializeTransaction ();
                VentaEN ventaEN = (VentaEN)session.Load (typeof(VentaEN), venta.Id);

                ventaEN.FechaVenta = venta.FechaVenta;

                session.Update (ventaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> GetVentasByUsuario (string p_usuario)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VentaEN self where FROM VentaEN WHERE usurio=:p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VentaENgetVentasByUsuarioHQL");
                query.SetParameter ("p_usuario", p_usuario);

                result = query.List<IManagerGenNHibernate.EN.IManager.VentaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: GetVentaById
//Con e: VentaEN
public VentaEN GetVentaById (int id)
{
        VentaEN ventaEN = null;

        try
        {
                SessionInitializeTransaction ();
                ventaEN = (VentaEN)session.Get (typeof(VentaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ventaEN;
}
}
}
