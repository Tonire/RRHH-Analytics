
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
 *	Atributo envía
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> envía;



/**
 *	Atributo recibe
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> recibe;



/**
 *	Atributo horario
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido;



/**
 *	Atributo proveedor
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> proveedor;



/**
 *	Atributo ventas
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentasEN> ventas;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string DNI {
        get { return dNI; } set { dNI = value;  }
}



public virtual String Password {
        get { return password; } set { password = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> Envía {
        get { return envía; } set { envía = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> Recibe {
        get { return recibe; } set { recibe = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> Horario {
        get { return horario; } set { horario = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> Proveedor {
        get { return proveedor; } set { proveedor = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentasEN> Ventas {
        get { return ventas; } set { ventas = value;  }
}





public UsuarioEN()
{
        Envía = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.MensajeEN>();
        Recibe = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.MensajeEN>();
        horario = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.HorarioEN>();
        pedido = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.PedidoEN>();
        proveedor = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.ProveedorEN>();
        ventas = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.VentasEN>();
}



public UsuarioEN(string email, string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> envía, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> recibe, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> proveedor, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentasEN> ventas
                 )
{
        this.init (Email, dNI, password, envía, recibe, horario, pedido, proveedor, ventas);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Email, usuario.DNI, usuario.Password, usuario.Envía, usuario.Recibe, usuario.Horario, usuario.Pedido, usuario.Proveedor, usuario.Ventas);
}

private void init (string email, string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> envía, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> recibe, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> proveedor, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentasEN> ventas)
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
