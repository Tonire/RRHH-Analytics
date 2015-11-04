
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
 * Clase Ventas:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class VentasCAD : BasicCAD, IVentasCAD
{
public VentasCAD() : base ()
{
}

public VentasCAD(ISession sessionAux) : base (sessionAux)
{
}



public VentasEN ReadOIDDefault (int id)
{
        VentasEN ventasEN = null;

        try
        {
                SessionInitializeTransaction ();
                ventasEN = (VentasEN)session.Get (typeof(VentasEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ventasEN;
}

public System.Collections.Generic.IList<VentasEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<VentasEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(VentasEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<VentasEN>();
                        else
                                result = session.CreateCriteria (typeof(VentasEN)).List<VentasEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentasCAD.", ex);
        }

        return result;
}

public int NuevaVenta (VentasEN ventas)
{
        try
        {
                SessionInitializeTransaction ();
                if (ventas.Usuario != null) {
                        // Argumento OID y no colección.
                        ventas.Usuario = (IManagerGenNHibernate.EN.IManager.UsuarioEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.UsuarioEN), ventas.Usuario.Email);

                        ventas.Usuario.Ventas
                        .Add (ventas);
                }
                if (ventas.Producto != null) {
                        // Argumento OID y no colección.
                        ventas.Producto = (IManagerGenNHibernate.EN.IManager.ProductoEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.ProductoEN), ventas.Producto.Referencia);

                        ventas.Producto.Ventas
                        .Add (ventas);
                }

                session.Save (ventas);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ventas.Id;
}

public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                VentasEN ventasEN = (VentasEN)session.Load (typeof(VentasEN), id);
                session.Delete (ventasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modify (VentasEN ventas)
{
        try
        {
                SessionInitializeTransaction ();
                VentasEN ventasEN = (VentasEN)session.Load (typeof(VentasEN), ventas.Id);
                session.Update (ventasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in VentasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
