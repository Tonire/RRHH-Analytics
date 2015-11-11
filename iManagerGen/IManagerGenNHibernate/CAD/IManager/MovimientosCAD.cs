
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
                if (movimientos.Pedido != null) {
                        // Argumento OID y no colección.
                        movimientos.Pedido = (IManagerGenNHibernate.EN.IManager.PedidoEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.PedidoEN), movimientos.Pedido.Id);

                        movimientos.Pedido.Movimientos
                        .Add (movimientos);
                }
                if (movimientos.Venta != null) {
                        // Argumento OID y no colección.
                        movimientos.Venta = (IManagerGenNHibernate.EN.IManager.VentaEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.VentaEN), movimientos.Venta.Id);

                        movimientos.Venta.Movimientos
                        .Add (movimientos);
                }

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
}
}
