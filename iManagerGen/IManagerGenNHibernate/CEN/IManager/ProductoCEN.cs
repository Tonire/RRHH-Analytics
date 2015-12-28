

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;

namespace IManagerGenNHibernate.CEN.IManager
{
/*
 *      Definition of the class ProductoCEN
 *
 */
public partial class ProductoCEN
{
private IProductoCAD _IProductoCAD;

public ProductoCEN()
{
        this._IProductoCAD = new ProductoCAD ();
}

public ProductoCEN(IProductoCAD _IProductoCAD)
{
        this._IProductoCAD = _IProductoCAD;
}

public IProductoCAD get_IProductoCAD ()
{
        return this._IProductoCAD;
}

public int CrearProducto (int p_referencia, string p_nombre, string p_marca, float p_precioCompra, float p_precioVenta, int p_stock, System.Collections.Generic.IList<string> p_proveedor)
{
        ProductoEN productoEN = null;
        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Referencia = p_referencia;

        productoEN.Nombre = p_nombre;

        productoEN.Marca = p_marca;

        productoEN.PrecioCompra = p_precioCompra;

        productoEN.PrecioVenta = p_precioVenta;

        productoEN.Stock = p_stock;


        productoEN.Proveedor = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.ProveedorEN>();
        if (p_proveedor != null) {
                foreach (string item in p_proveedor) {
                        IManagerGenNHibernate.EN.IManager.ProveedorEN en = new IManagerGenNHibernate.EN.IManager.ProveedorEN ();
                        en.Email = item;
                        productoEN.Proveedor.Add (en);
                }
        }

        else{
                productoEN.Proveedor = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.ProveedorEN>();
        }

        //Call to ProductoCAD

        oid = _IProductoCAD.CrearProducto (productoEN);
        return oid;
}

public void Modify (int p_Producto_OID, string p_nombre, string p_marca, float p_precioCompra, float p_precioVenta, int p_stock)
{
        ProductoEN productoEN = null;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Referencia = p_Producto_OID;
        productoEN.Nombre = p_nombre;
        productoEN.Marca = p_marca;
        productoEN.PrecioCompra = p_precioCompra;
        productoEN.PrecioVenta = p_precioVenta;
        productoEN.Stock = p_stock;
        //Call to ProductoCAD

        _IProductoCAD.Modify (productoEN);
}

public void Destroy (int referencia)
{
        _IProductoCAD.Destroy (referencia);
}

public System.Collections.Generic.IList<ProductoEN> GetAllProductos (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> list = null;

        list = _IProductoCAD.GetAllProductos (first, size);
        return list;
}
public ProductoEN GetProducto (int referencia)
{
        ProductoEN productoEN = null;

        productoEN = _IProductoCAD.GetProducto (referencia);
        return productoEN;
}

public void AsignarProveedor (int p_Producto_OID, System.Collections.Generic.IList<string> p_proveedor_OIDs)
{
        //Call to ProductoCAD

        _IProductoCAD.AsignarProveedor (p_Producto_OID, p_proveedor_OIDs);
}
public void QuitarProveedor (int p_Producto_OID, System.Collections.Generic.IList<string> p_proveedor_OIDs)
{
        //Call to ProductoCAD

        _IProductoCAD.QuitarProveedor (p_Producto_OID, p_proveedor_OIDs);
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProductoEN> GetProductosByProveedor (string p_proveedor)
{
        return _IProductoCAD.GetProductosByProveedor (p_proveedor);
}
}
}
