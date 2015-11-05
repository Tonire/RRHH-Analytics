
using System;
// Definición clase AdministradorEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class AdministradorEN                                                                        : IManagerGenNHibernate.EN.IManager.UsuarioEN


{
public AdministradorEN() : base ()
{
}



public AdministradorEN(string email,
                       string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> envía, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> recibe, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> proveedor, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> ventas
                       )
{
        this.init (Email, dNI, password, envía, recibe, horario, pedido, proveedor, ventas);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (Email, administrador.DNI, administrador.Password, administrador.Envía, administrador.Recibe, administrador.Horario, administrador.Pedido, administrador.Proveedor, administrador.Ventas);
}

private void init (string email, string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> envía, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> recibe, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> proveedor, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> ventas)
{
        this.Email = email;


        this.DNI = dNI;

        this.Password = password;

        this.Envía = envía;

        this.Recibe = recibe;

        this.Horario = horario;

        this.Pedido = pedido;

        this.Proveedor = proveedor;

        this.Ventas = ventas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
