
using System;
// Definición clase PedidoEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class PedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estado
 */
private IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum estado;



/**
 *	Atributo fechaRealizacion
 */
private Nullable<DateTime> fechaRealizacion;



/**
 *	Atributo usuario
 */
private IManagerGenNHibernate.EN.IManager.UsuarioEN usuario;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> lineaPedido;



/**
 *	Atributo fechaConfirmacion
 */
private Nullable<DateTime> fechaConfirmacion;



/**
 *	Atributo fechaCancelacion
 */
private Nullable<DateTime> fechaCancelacion;



/**
 *	Atributo movimientos
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> movimientos;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual Nullable<DateTime> FechaRealizacion {
        get { return fechaRealizacion; } set { fechaRealizacion = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual Nullable<DateTime> FechaConfirmacion {
        get { return fechaConfirmacion; } set { fechaConfirmacion = value;  }
}



public virtual Nullable<DateTime> FechaCancelacion {
        get { return fechaCancelacion; } set { fechaCancelacion = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> Movimientos {
        get { return movimientos; } set { movimientos = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.LineaPedidoEN>();
        movimientos = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.MovimientosEN>();
}



public PedidoEN(int id, IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum estado, Nullable<DateTime> fechaRealizacion, IManagerGenNHibernate.EN.IManager.UsuarioEN usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> lineaPedido, Nullable<DateTime> fechaConfirmacion, Nullable<DateTime> fechaCancelacion, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> movimientos
                )
{
        this.init (Id, estado, fechaRealizacion, usuario, lineaPedido, fechaConfirmacion, fechaCancelacion, movimientos);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (Id, pedido.Estado, pedido.FechaRealizacion, pedido.Usuario, pedido.LineaPedido, pedido.FechaConfirmacion, pedido.FechaCancelacion, pedido.Movimientos);
}

private void init (int id, IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum estado, Nullable<DateTime> fechaRealizacion, IManagerGenNHibernate.EN.IManager.UsuarioEN usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> lineaPedido, Nullable<DateTime> fechaConfirmacion, Nullable<DateTime> fechaCancelacion, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MovimientosEN> movimientos)
{
        this.Id = id;


        this.Estado = estado;

        this.FechaRealizacion = fechaRealizacion;

        this.Usuario = usuario;

        this.LineaPedido = lineaPedido;

        this.FechaConfirmacion = fechaConfirmacion;

        this.FechaCancelacion = fechaCancelacion;

        this.Movimientos = movimientos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
