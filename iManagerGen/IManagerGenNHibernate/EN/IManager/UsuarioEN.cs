
using System;
// Definición clase UsuarioEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class UsuarioEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo dNI
 */
private string dNI;



/**
 *	Atributo password
 */
private String password;



/**
 *	Atributo mensajesEnviados
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesEnviados;



/**
 *	Atributo mensajesRecibidos
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesRecibidos;



/**
 *	Atributo horario
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido;



/**
 *	Atributo ventas
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> ventas;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string DNI {
        get { return dNI; } set { dNI = value;  }
}



public virtual String Password {
        get { return password; } set { password = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> MensajesEnviados {
        get { return mensajesEnviados; } set { mensajesEnviados = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> MensajesRecibidos {
        get { return mensajesRecibidos; } set { mensajesRecibidos = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> Horario {
        get { return horario; } set { horario = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> Ventas {
        get { return ventas; } set { ventas = value;  }
}





public UsuarioEN()
{
        MensajesEnviados = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.MensajeEN>();
        MensajesRecibidos = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.MensajeEN>();
        horario = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.HorarioEN>();
        pedido = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.PedidoEN>();
        ventas = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.VentaEN>();
}



public UsuarioEN(string email, string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> ventas
                 )
{
        this.init (Email, dNI, password, mensajesEnviados, mensajesRecibidos, horario, pedido, ventas);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Email, usuario.DNI, usuario.Password, usuario.MensajesEnviados, usuario.MensajesRecibidos, usuario.Horario, usuario.Pedido, usuario.Ventas);
}

private void init (string email, string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> ventas)
{
        this.Email = email;


        this.DNI = dNI;

        this.Password = password;

        this.MensajesEnviados = mensajesEnviados;

        this.MensajesRecibidos = mensajesRecibidos;

        this.Horario = horario;

        this.Pedido = pedido;

        this.Ventas = ventas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
