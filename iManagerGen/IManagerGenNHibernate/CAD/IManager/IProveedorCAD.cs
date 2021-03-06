
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


void AddProducto (string p_Proveedor_OID, System.Collections.Generic.IList<string> p_producto_OIDs);

void QuitarProducto (string p_Proveedor_OID, System.Collections.Generic.IList<string> p_producto_OIDs);

System.Collections.Generic.IList<ProveedorEN> DameTodos (int first, int size);


ProveedorEN GetProveedor (string email);


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> GetProveedoresByProducto (string p_producto);
}
}
