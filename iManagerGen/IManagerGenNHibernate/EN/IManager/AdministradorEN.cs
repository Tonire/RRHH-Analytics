
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
                       string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> ventas, string nombre, string apellidos
                       )
{
        this.init (Email, dNI, password, mensajesEnviados, mensajesRecibidos, horario, pedido, ventas, nombre, apellidos);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (Email, administrador.DNI, administrador.Password, administrador.MensajesEnviados, administrador.MensajesRecibidos, administrador.Horario, administrador.Pedido, administrador.Ventas, administrador.Nombre, administrador.Apellidos);
}

private void init (string email, string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> ventas, string nombre, string apellidos)
{
        this.Email = email;


        this.DNI = dNI;

        this.Password = password;

        this.MensajesEnviados = mensajesEnviados;

        this.MensajesRecibidos = mensajesRecibidos;

        this.Horario = horario;

        this.Pedido = pedido;

        this.Ventas = ventas;

        this.Nombre = nombre;

        this.Apellidos = apellidos;
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
