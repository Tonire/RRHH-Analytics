
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string email);

string Registrar (UsuarioEN usuario);


void Modify (UsuarioEN usuario);


void Destroy (string email);


void AddVenta (string p_Usuario_OID, System.Collections.Generic.IList<int> p_ventas_OIDs);

void QuitarVenta (string p_Usuario_OID, System.Collections.Generic.IList<int> p_ventas_OIDs);
}
}
