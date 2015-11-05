
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
 * Clase Producto:
 *
 */

namespace IManagerGenNHibernate.CAD.IManager
{
public partial class ProductoCAD : BasicCAD, IProductoCAD
{
public ProductoCAD() : base ()
{
}

public ProductoCAD(ISession sessionAux) : base (sessionAux)
{
}



public ProductoEN ReadOIDDefault (int referencia)
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoEN), referencia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProductoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                        else
                                result = session.CreateCriteria (typeof(ProductoEN)).List<ProductoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }

        return result;
}

public int CrearProducto (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (producto);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return producto.Referencia;
}

public void Modify (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoEN productoEN = (ProductoEN)session.Load (typeof(ProductoEN), producto.Referencia);

                productoEN.Nombre = producto.Nombre;


                productoEN.Marca = producto.Marca;


                productoEN.PrecioCompra = producto.PrecioCompra;


                productoEN.PrecioVenta = producto.PrecioVenta;


                productoEN.Stock = producto.Stock;

                session.Update (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int referencia)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoEN productoEN = (ProductoEN)session.Load (typeof(ProductoEN), referencia);
                session.Delete (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ProductoEN> GetAllProductos (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProductoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                else
                        result = session.CreateCriteria (typeof(ProductoEN)).List<ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: GetProducto
//Con e: ProductoEN
public ProductoEN GetProducto (int referencia)
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoEN), referencia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public void AsignarProveedor (int p_Producto_OID, System.Collections.Generic.IList<string> p_proveedor_OIDs)
{
        IManagerGenNHibernate.EN.IManager.ProductoEN productoEN = null;
        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Load (typeof(ProductoEN), p_Producto_OID);
                IManagerGenNHibernate.EN.IManager.ProveedorEN proveedorENAux = null;
                if (productoEN.Proveedor == null) {
                        productoEN.Proveedor = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.ProveedorEN>();
                }

                foreach (string item in p_proveedor_OIDs) {
                        proveedorENAux = new IManagerGenNHibernate.EN.IManager.ProveedorEN ();
                        proveedorENAux = (IManagerGenNHibernate.EN.IManager.ProveedorEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.ProveedorEN), item);
                        proveedorENAux.Producto.Add (productoEN);

                        productoEN.Proveedor.Add (proveedorENAux);
                }


                session.Update (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarProveedor (int p_Producto_OID, System.Collections.Generic.IList<string> p_proveedor_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                IManagerGenNHibernate.EN.IManager.ProductoEN productoEN = null;
                productoEN = (ProductoEN)session.Load (typeof(ProductoEN), p_Producto_OID);

                IManagerGenNHibernate.EN.IManager.ProveedorEN proveedorENAux = null;
                if (productoEN.Proveedor != null) {
                        foreach (string item in p_proveedor_OIDs) {
                                proveedorENAux = (IManagerGenNHibernate.EN.IManager.ProveedorEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.ProveedorEN), item);
                                if (productoEN.Proveedor.Contains (proveedorENAux) == true) {
                                        productoEN.Proveedor.Remove (proveedorENAux);
                                        proveedorENAux.Producto.Remove (productoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_proveedor_OIDs you are trying to unrelationer, doesn't exist in ProductoEN");
                        }
                }

                session.Update (productoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is IManagerGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new IManagerGenNHibernate.Exceptions.DataLayerException ("Error in ProductoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
