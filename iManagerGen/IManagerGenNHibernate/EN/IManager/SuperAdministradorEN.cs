
using System;
// Definición clase SuperAdministradorEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class SuperAdministradorEN                                                                   : IManagerGenNHibernate.EN.IManager.UsuarioEN


{
public SuperAdministradorEN() : base ()
{
}



public SuperAdministradorEN(string email,
                            string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> ventas, string nombre, string apellidos, Nullable<DateTime> fechaRegistro
                            )
{
        this.init (Email, dNI, password, mensajesEnviados, mensajesRecibidos, horario, pedido, ventas, nombre, apellidos, fechaRegistro);
}


public SuperAdministradorEN(SuperAdministradorEN superAdministrador)
{
        this.init (Email, superAdministrador.DNI, superAdministrador.Password, superAdministrador.MensajesEnviados, superAdministrador.MensajesRecibidos, superAdministrador.Horario, superAdministrador.Pedido, superAdministrador.Ventas, superAdministrador.Nombre, superAdministrador.Apellidos, superAdministrador.FechaRegistro);
}

private void init (string email, string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> ventas, string nombre, string apellidos, Nullable<DateTime> fechaRegistro)
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

        this.FechaRegistro = fechaRegistro;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SuperAdministradorEN t = obj as SuperAdministradorEN;
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
