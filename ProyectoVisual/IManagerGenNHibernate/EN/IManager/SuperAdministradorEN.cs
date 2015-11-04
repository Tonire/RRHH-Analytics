
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
                            string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> envía, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> recibe, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> proveedor, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentasEN> ventas
                            )
{
        this.init (Email, dNI, password, envía, recibe, horario, pedido, proveedor, ventas);
}


public SuperAdministradorEN(SuperAdministradorEN superAdministrador)
{
        this.init (Email, superAdministrador.DNI, superAdministrador.Password, superAdministrador.Envía, superAdministrador.Recibe, superAdministrador.Horario, superAdministrador.Pedido, superAdministrador.Proveedor, superAdministrador.Ventas);
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
