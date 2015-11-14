
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
 * Clase Movimientos:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class MovimientosCAD : BasicCAD, IMovimientosCAD
{
public MovimientosCAD() : base ()
{
}

public MovimientosCAD(ISession sessionAux) : base (sessionAux)
{
}



public MovimientosEN ReadOIDDefault (int id)
{
        MovimientosEN movimientosEN = null;

        try
        {
                SessionInitializeTransaction ();
                movimientosEN = (MovimientosEN)session.Get (typeof(MovimientosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MovimientosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return movimientosEN;
}

public System.Collections.Generic.IList<MovimientosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MovimientosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MovimientosEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MovimientosEN>();
                        else
                                result = session.CreateCriteria (typeof(MovimientosEN)).List<MovimientosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MovimientosCAD.", ex);
        }

        return result;
}

public int CrearMovimiento (MovimientosEN movimientos)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (movimientos);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MovimientosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return movimientos.Id;
}

public void RelationerPedido (int p_Movimientos_OID, int p_pedido_OID)
{
        IManagerGenNHibernate.EN.IManager.MovimientosEN movimientosEN = null;
        try
        {
                SessionInitializeTransaction ();
                movimientosEN = (MovimientosEN)session.Load (typeof(MovimientosEN), p_Movimientos_OID);
                movimientosEN.Pedido = (IManagerGenNHibernate.EN.IManager.PedidoEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.PedidoEN), p_pedido_OID);

                movimientosEN.Pedido.Movimientos.Add (movimientosEN);



                session.Update (movimientosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MovimientosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void RelationerVenta (int p_Movimientos_OID, int p_venta_OID)
{
        IManagerGenNHibernate.EN.IManager.MovimientosEN movimientosEN = null;
        try
        {
                SessionInitializeTransaction ();
                movimientosEN = (MovimientosEN)session.Load (typeof(MovimientosEN), p_Movimientos_OID);
                movimientosEN.Venta = (IManagerGenNHibernate.EN.IManager.VentaEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.VentaEN), p_venta_OID);

                movimientosEN.Venta.Movimientos.Add (movimientosEN);



                session.Update (movimientosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in MovimientosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
