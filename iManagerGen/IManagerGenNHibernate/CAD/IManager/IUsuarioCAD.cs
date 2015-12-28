
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string email);


void Modify (UsuarioEN usuario);


void Destroy (string email);


UsuarioEN GetUsuarioByEmail (string email);


System.Collections.Generic.IList<UsuarioEN> DameTodos (int first, int size);


string Registrar (UsuarioEN usuario);

int ContarUsuarios ();
}
}
