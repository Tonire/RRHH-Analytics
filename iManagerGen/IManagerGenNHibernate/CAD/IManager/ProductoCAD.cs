
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



public ProductoEN ReadOIDDefault (string referencia)
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

public string CrearProducto (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                if (producto.Proveedor != null) {
                        for (int i = 0; i < producto.Proveedor.Count; i++) {
                                producto.Proveedor [i] = (IManagerGenNHibernate.EN.IManager.ProveedorEN)session.Load (typeof(IManagerGenNHibernate.EN.IManager.ProveedorEN), producto.Proveedor [i].Email);
                                producto.Proveedor [i].Producto.Add (producto);
                        }
                }

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


                productoEN.Ventas = producto.Ventas;

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
public void Destroy (string referencia)
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
public ProductoEN GetProducto (string referencia)
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

public void AsignarProveedor (string p_Producto_OID, System.Collections.Generic.IList<string> p_proveedor_OIDs)
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

public void QuitarProveedor (string p_Producto_OID, System.Collections.Generic.IList<string> p_proveedor_OIDs)
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
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProductoEN> GetProductosByProveedor (string p_proveedor)
{
        System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoEN self where select prod FROM ProductoEN as prod inner join prod.Proveedor as prov where prov.Email=:p_proveedor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoENgetProductosByProveedorHQL");
                query.SetParameter ("p_proveedor", p_proveedor);

                result = query.List<IManagerGenNHibernate.EN.IManager.ProductoEN>();
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
public long ContarProductos ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoEN self where select count(*) FROM ProductoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoENcontarProductosHQL");


                result = query.UniqueResult<long>();
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
public long TotalVentas ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoEN self where select sum(Ventas) FROM ProductoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoENtotalVentasHQL");


                result = query.UniqueResult<long>();
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
}
}
