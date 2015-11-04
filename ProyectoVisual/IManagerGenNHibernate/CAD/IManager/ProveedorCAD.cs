
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
 * Clase Proveedor:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class ProveedorCAD : BasicCAD, IProveedorCAD
{
public ProveedorCAD() : base ()
{
}

public ProveedorCAD(ISession sessionAux) : base (sessionAux)
{
}



public ProveedorEN ReadOIDDefault (string email)
{
        ProveedorEN proveedorEN = null;

        try
        {
                SessionInitializeTransaction ();
                proveedorEN = (ProveedorEN)session.Get (typeof(ProveedorEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proveedorEN;
}

public System.Collections.Generic.IList<ProveedorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProveedorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProveedorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProveedorEN>();
                        else
                                result = session.CreateCriteria (typeof(ProveedorEN)).List<ProveedorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }

        return result;
}

public string CrearProveedor (ProveedorEN proveedor)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (proveedor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proveedor.Email;
}

public void Modify (ProveedorEN proveedor)
{
        try
        {
                SessionInitializeTransaction ();
                ProveedorEN proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorEN), proveedor.Email);

                proveedorEN.Nombre = proveedor.Nombre;


                proveedorEN.Telefono = proveedor.Telefono;

                session.Update (proveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string email)
{
        try
        {
                SessionInitializeTransaction ();
                ProveedorEN proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorEN), email);
                session.Delete (proveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AddProducto (string p_Proveedor_OID, System.Collections.Generic.IList<int> p_producto_OIDs)
{
        IManagerGenNHibernate.EN.IManager.ProveedorEN proveedorEN = null;
        try
        {
                SessionInitializeTransaction ();
                proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorEN), p_Proveedor_OID);
                IManagerGenNHibernate.EN.IManager.ProductoEN productoENAux = null;
                if (proveedorEN.Producto == null) {
                        proveedorEN.Producto = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.ProductoEN>();
                }

                foreach (int item in p_producto_OIDs) {
                        productoENAux = new IManagerGenNHibernate.EN.IManager.ProductoEN ();
                        productoENAux = (IManagerGenNHibernate.EN.IManager.ProductoEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.ProductoEN), item);
                        productoENAux.Proveedor.Add (proveedorEN);

                        proveedorEN.Producto.Add (productoENAux);
                }


                session.Update (proveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarProducto (string p_Proveedor_OID, System.Collections.Generic.IList<int> p_producto_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                IManagerGenNHibernate.EN.IManager.ProveedorEN proveedorEN = null;
                proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorEN), p_Proveedor_OID);

                IManagerGenNHibernate.EN.IManager.ProductoEN productoENAux = null;
                if (proveedorEN.Producto != null) {
                        foreach (int item in p_producto_OIDs) {
                                productoENAux = (IManagerGenNHibernate.EN.IManager.ProductoEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.ProductoEN), item);
                                if (proveedorEN.Producto.Contains (productoENAux) == true) {
                                        proveedorEN.Producto.Remove (productoENAux);
                                        productoENAux.Proveedor.Remove (proveedorEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_producto_OIDs you are trying to unrelationer, doesn't exist in ProveedorEN");
                        }
                }

                session.Update (proveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
