

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

public string CrearProveedor (string p_email, string p_nombre, string p_telefono, string p_direccion, string p_localidad, string p_pais, string p_CIF)
{
        ProveedorEN proveedorEN = null;
        string oid;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Email = p_email;

        proveedorEN.Nombre = p_nombre;

        proveedorEN.Telefono = p_telefono;

        proveedorEN.Direccion = p_direccion;

        proveedorEN.Localidad = p_localidad;

        proveedorEN.Pais = p_pais;

        proveedorEN.CIF = p_CIF;

        //Call to ProveedorCAD

        oid = _IProveedorCAD.CrearProveedor (proveedorEN);
        return oid;
}

public void Modify (string p_Proveedor_OID, string p_nombre, string p_telefono, string p_direccion, string p_localidad, string p_pais, string p_CIF)
{
        ProveedorEN proveedorEN = null;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Email = p_Proveedor_OID;
        proveedorEN.Nombre = p_nombre;
        proveedorEN.Telefono = p_telefono;
        proveedorEN.Direccion = p_direccion;
        proveedorEN.Localidad = p_localidad;
        proveedorEN.Pais = p_pais;
        proveedorEN.CIF = p_CIF;
        //Call to ProveedorCAD

        _IProveedorCAD.Modify (proveedorEN);
}

public void Destroy (string email)
{
        _IProveedorCAD.Destroy (email);
}

public void AddProducto (string p_Proveedor_OID, System.Collections.Generic.IList<string> p_producto_OIDs)
{
        //Call to ProveedorCAD

        _IProveedorCAD.AddProducto (p_Proveedor_OID, p_producto_OIDs);
}
public void QuitarProducto (string p_Proveedor_OID, System.Collections.Generic.IList<string> p_producto_OIDs)
{
        //Call to ProveedorCAD

        _IProveedorCAD.QuitarProducto (p_Proveedor_OID, p_producto_OIDs);
}
public System.Collections.Generic.IList<ProveedorEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ProveedorEN> list = null;

        list = _IProveedorCAD.DameTodos (first, size);
        return list;
}
public ProveedorEN GetProveedor (string email)
{
        ProveedorEN proveedorEN = null;

        proveedorEN = _IProveedorCAD.GetProveedor (email);
        return proveedorEN;
}

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> GetProveedoresByProducto (string p_producto)
{
        return _IProveedorCAD.GetProveedoresByProducto (p_producto);
}
}
}
