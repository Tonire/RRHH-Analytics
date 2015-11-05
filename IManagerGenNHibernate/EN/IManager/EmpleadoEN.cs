
using System;
// Definición clase EmpleadoEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class EmpleadoEN                                                                     : IManagerGenNHibernate.EN.IManager.UsuarioEN


{
public EmpleadoEN() : base ()
{
}



public EmpleadoEN(string email,
                  string dNI, String password, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> envía, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> recibe, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> horario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> pedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> proveedor, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentasEN> ventas
                  )
{
        this.init (Email, dNI, password, envía, recibe, horario, pedido, proveedor, ventas);
}


public EmpleadoEN(EmpleadoEN empleado)
{
        this.init (Email, empleado.DNI, empleado.Password, empleado.Envía, empleado.Recibe, empleado.Horario, empleado.Pedido, empleado.Proveedor, empleado.Ventas);
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
        EmpleadoEN t = obj as EmpleadoEN;
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
