
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
 * Clase lineaVenta:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class LineaVentaCAD : BasicCAD, ILineaVentaCAD
{
public LineaVentaCAD() : base ()
{
}

public LineaVentaCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaVentaEN ReadOIDDefault (int id)
{
        LineaVentaEN lineaVentaEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaVentaEN = (LineaVentaEN)session.Get (typeof(LineaVentaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in LineaVentaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaVentaEN;
}

public System.Collections.Generic.IList<LineaVentaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaVentaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaVentaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaVentaEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaVentaEN)).List<LineaVentaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in LineaVentaCAD.", ex);
        }

        return result;
}

public int CrearLineaVenta (LineaVentaEN lineaVenta)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaVenta.Producto != null) {
                        // Argumento OID y no colección.
                        lineaVenta.Producto = (IManagerGenNHibernate.EN.IManager.ProductoEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.ProductoEN), lineaVenta.Producto.Referencia);

                        lineaVenta.Producto.LineaVenta
                        .Add (lineaVenta);
                }

                session.Save (lineaVenta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in LineaVentaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaVenta.Id;
}

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaVentaEN> GetLineasVentaByVenta (int p_venta)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaVentaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM LineaVentaEN self where select lv FROM LineaVentaEN as lv inner join lv.Venta as ve where ve.id=:p_venta";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("LineaVentaENgetLineasVentaByVentaHQL");
                query.SetParameter ("p_venta", p_venta);

                result = query.List<IManagerGenNHibernate.EN.IManager.LineaVentaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in LineaVentaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
