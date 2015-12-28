
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IProductoCAD
{
ProductoEN ReadOIDDefault (string referencia);

string CrearProducto (ProductoEN producto);

void Modify (ProductoEN producto);


void Destroy (string referencia);


System.Collections.Generic.IList<ProductoEN> GetAllProductos (int first, int size);


ProductoEN GetProducto (string referencia);


void AsignarProveedor (string p_Producto_OID, System.Collections.Generic.IList<string> p_proveedor_OIDs);

void QuitarProveedor (string p_Producto_OID, System.Collections.Generic.IList<string> p_proveedor_OIDs);

System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProductoEN> GetProductosByProveedor (string p_proveedor);
}
}
