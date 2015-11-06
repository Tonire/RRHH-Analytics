

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
 *      Definition of the class ProveedorCEN
 *
 */
public partial class ProveedorCEN
{
private IProveedorCAD _IProveedorCAD;

public ProveedorCEN()
{
        this._IProveedorCAD = new ProveedorCAD ();
}

public ProveedorCEN(IProveedorCAD _IProveedorCAD)
{
        this._IProveedorCAD = _IProveedorCAD;
}

public IProveedorCAD get_IProveedorCAD ()
{
        return this._IProveedorCAD;
}

public string CrearProveedor (string p_email, string p_nombre, string p_telefono, System.Collections.Generic.IList<int> p_producto)
{
        ProveedorEN proveedorEN = null;
        string oid;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Email = p_email;

        proveedorEN.Nombre = p_nombre;

        proveedorEN.Telefono = p_telefono;


        proveedorEN.Producto = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.ProductoEN>();
        if (p_producto != null) {
                foreach (int item in p_producto) {
                        IManagerGenNHibernate.EN.IManager.ProductoEN en = new IManagerGenNHibernate.EN.IManager.ProductoEN ();
                        en.Referencia = item;
                        proveedorEN.Producto.Add (en);
                }
        }

        else{
                proveedorEN.Producto = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.ProductoEN>();
        }

        //Call to ProveedorCAD

        oid = _IProveedorCAD.CrearProveedor (proveedorEN);
        return oid;
}

public void Modify (string p_Proveedor_OID, string p_nombre, string p_telefono)
{
        ProveedorEN proveedorEN = null;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Email = p_Proveedor_OID;
        proveedorEN.Nombre = p_nombre;
        proveedorEN.Telefono = p_telefono;
        //Call to ProveedorCAD

        _IProveedorCAD.Modify (proveedorEN);
}

public void Destroy (string email)
{
        _IProveedorCAD.Destroy (email);
}

public void AddProducto (string p_Proveedor_OID, System.Collections.Generic.IList<int> p_producto_OIDs)
{
        //Call to ProveedorCAD

        _IProveedorCAD.AddProducto (p_Proveedor_OID, p_producto_OIDs);
}
public void QuitarProducto (string p_Proveedor_OID, System.Collections.Generic.IList<int> p_producto_OIDs)
{
        //Call to ProveedorCAD

        _IProveedorCAD.QuitarProducto (p_Proveedor_OID, p_producto_OIDs);
}
}
}
