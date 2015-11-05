
using System;
// Definición clase LineaPedidoEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class LineaPedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo pedido
 */
private IManagerGenNHibernate.EN.IManager.PedidoEN pedido;



/**
 *	Atributo producto
 */
private IManagerGenNHibernate.EN.IManager.ProductoEN producto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int id, int cantidad, IManagerGenNHibernate.EN.IManager.PedidoEN pedido, IManagerGenNHibernate.EN.IManager.ProductoEN producto
                     )
{
        this.init (Id, cantidad, pedido, producto);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (Id, lineaPedido.Cantidad, lineaPedido.Pedido, lineaPedido.Producto);
}

private void init (int id, int cantidad, IManagerGenNHibernate.EN.IManager.PedidoEN pedido, IManagerGenNHibernate.EN.IManager.ProductoEN producto)
{
        this.Id = id;


        this.Cantidad = cantidad;

        this.Pedido = pedido;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPedidoEN t = obj as LineaPedidoEN;
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
