
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

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientosByAnyoMes (string tipoMovimiento, int anyoMovimiento, int mesMovimiento)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MovimientosEN self where FROM Movimientos WHERE mes=:MesMovimiento AND anyo=:AnyoMovimiento AND tipo=:TipoMovimiento";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MovimientosENgetMovimientosByAnyoMesHQL");
                query.SetParameter ("TipoMovimiento", TipoMovimiento);
                query.SetParameter ("AnyoMovimiento", AnyoMovimiento);
                query.SetParameter ("MesMovimiento", MesMovimiento);

                result = query.List<IManagerGenNHibernate.EN.IManager.MovimientosEN>();
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

        return result;
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientosByAnyo (string tipoMovimiento, int anyoMovimiento)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MovimientosEN self where FROM Movimientos WHERE anyo=:AnyoMovimiento AND tipo=:TipoMovimiento";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MovimientosENgetMovimientosByAnyoHQL");
                query.SetParameter ("TipoMovimiento", TipoMovimiento);
                query.SetParameter ("AnyoMovimiento", AnyoMovimiento);

                result = query.List<IManagerGenNHibernate.EN.IManager.MovimientosEN>();
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

        return result;
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetBalanceByMesAnyo (string arg0, string arg1)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MovimientosEN self where FROM MovimientosEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MovimientosENgetBalanceByMesAnyoHQL");
                query.SetParameter ("arg0", arg0);
                query.SetParameter ("arg1", arg1);

                result = query.List<IManagerGenNHibernate.EN.IManager.MovimientosEN>();
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

        return result;
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetBalanceByAnyo (string arg0)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MovimientosEN self where FROM MovimientosEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MovimientosENgetBalanceByAnyoHQL");
                query.SetParameter ("arg0", arg0);

                result = query.List<IManagerGenNHibernate.EN.IManager.MovimientosEN>();
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

        return result;
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientoTotalMesAnyo (int mesMovimiento, int anyoMovimiento, string tipoMovimiento)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MovimientosEN self where FROM Movimientos WHERE tipo=:TipoMovimiento AND mes=:MesMovimiento AND anyo=:AnyoMovimiento AND sum(cantidad)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MovimientosENgetMovimientoTotalMesAnyoHQL");
                query.SetParameter ("MesMovimiento", MesMovimiento);
                query.SetParameter ("AnyoMovimiento", AnyoMovimiento);
                query.SetParameter ("TipoMovimiento", TipoMovimiento);

                result = query.List<IManagerGenNHibernate.EN.IManager.MovimientosEN>();
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

        return result;
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> GetMovimientoTotalAnyo (string tipoMovimiento, int anyoMovimiento)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MovimientosEN self where FROM Movimientos WHERE tipo=:TipoMovimiento AND anyo=:AnyoMovimiento AND sum(cantidad)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MovimientosENgetMovimientoTotalAnyoHQL");
                query.SetParameter ("TipoMovimiento", TipoMovimiento);
                query.SetParameter ("AnyoMovimiento", AnyoMovimiento);

                result = query.List<IManagerGenNHibernate.EN.IManager.MovimientosEN>();
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

        return result;
}
}
}
