
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IProveedorCAD
{
ProveedorEN ReadOIDDefault (string email);

string CrearProveedor (ProveedorEN proveedor);

void Modify (ProveedorEN proveedor);


void Destroy (string email);


void AddProducto (string p_Proveedor_OID, System.Collections.Generic.IList<int> p_producto_OIDs);

void QuitarProducto (string p_Proveedor_OID, System.Collections.Generic.IList<int> p_producto_OIDs);
}
}
