
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
}
}
