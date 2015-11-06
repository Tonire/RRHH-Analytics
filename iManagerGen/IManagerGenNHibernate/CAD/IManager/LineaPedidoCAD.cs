
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
 * Clase LineaPedido:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class LineaPedidoCAD : BasicCAD, ILineaPedidoCAD
{
public LineaPedidoCAD() : base ()
{
}

public LineaPedidoCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaPedidoEN ReadOIDDefault (int id)
{
        LineaPedidoEN lineaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Get (typeof(LineaPedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaPedidoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaPedidoEN)).List<LineaPedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }

        return result;
}

public int CrearLineaPedido (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaPedido.Producto != null) {
                        // Argumento OID y no colección.
                        lineaPedido.Producto = (IManagerGenNHibernate.EN.IManager.ProductoEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.ProductoEN), lineaPedido.Producto.Referencia);

                        lineaPedido.Producto.LineaPedido
                        .Add (lineaPedido);
                }

                session.Save (lineaPedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedido.Id;
}

public void RelationerLinea (int p_LineaPedido_OID, int p_pedido_OID)
{
        IManagerGenNHibernate.EN.IManager.LineaPedidoEN lineaPedidoEN = null;
        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Load (typeof(LineaPedidoEN), p_LineaPedido_OID);
                lineaPedidoEN.Pedido = (IManagerGenNHibernate.EN.IManager.PedidoEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.PedidoEN), p_pedido_OID);

                lineaPedidoEN.Pedido.LineaPedido.Add (lineaPedidoEN);



                session.Update (lineaPedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
