
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
 *	Atributo total
 */
private string total;



/**
 *	Atributo descripcion
 */
private IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum descripcion;



/**
 *	Atributo usuario
 */
private IManagerGenNHibernate.EN.IManager.UsuarioEN usuario;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> lineaPedido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Total {
        get { return total; } set { total = value;  }
}



public virtual IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.LineaPedidoEN>();
}



public PedidoEN(int id, string total, IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum descripcion, IManagerGenNHibernate.EN.IManager.UsuarioEN usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> lineaPedido
                )
{
        this.init (Id, total, descripcion, usuario, lineaPedido);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (Id, pedido.Total, pedido.Descripcion, pedido.Usuario, pedido.LineaPedido);
}

private void init (int id, string total, IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum descripcion, IManagerGenNHibernate.EN.IManager.UsuarioEN usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> lineaPedido)
{
        this.Id = id;


        this.Total = total;

        this.Descripcion = descripcion;

        this.Usuario = usuario;

        this.LineaPedido = lineaPedido;
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
