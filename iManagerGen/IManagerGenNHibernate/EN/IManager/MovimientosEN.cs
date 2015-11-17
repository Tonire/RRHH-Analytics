
using System;
// Definición clase MovimientosEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class MovimientosEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo anyo
 */
private int anyo;



/**
 *	Atributo mes
 */
private int mes;



/**
 *	Atributo tipo
 */
private IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum tipo;



/**
 *	Atributo cantidad
 */
private double cantidad;



/**
 *	Atributo pedido
 */
private IManagerGenNHibernate.EN.IManager.PedidoEN pedido;



/**
 *	Atributo venta
 */
private IManagerGenNHibernate.EN.IManager.VentaEN venta;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Anyo {
        get { return anyo; } set { anyo = value;  }
}



public virtual int Mes {
        get { return mes; } set { mes = value;  }
}



public virtual IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual double Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.VentaEN Venta {
        get { return venta; } set { venta = value;  }
}





public MovimientosEN()
{
}



public MovimientosEN(int id, int anyo, int mes, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum tipo, double cantidad, IManagerGenNHibernate.EN.IManager.PedidoEN pedido, IManagerGenNHibernate.EN.IManager.VentaEN venta
                     )
{
        this.init (Id, anyo, mes, tipo, cantidad, pedido, venta);
}


public MovimientosEN(MovimientosEN movimientos)
{
        this.init (Id, movimientos.Anyo, movimientos.Mes, movimientos.Tipo, movimientos.Cantidad, movimientos.Pedido, movimientos.Venta);
}

private void init (int id, int anyo, int mes, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum tipo, double cantidad, IManagerGenNHibernate.EN.IManager.PedidoEN pedido, IManagerGenNHibernate.EN.IManager.VentaEN venta)
{
        this.Id = id;


        this.Anyo = anyo;

        this.Mes = mes;

        this.Tipo = tipo;

        this.Cantidad = cantidad;

        this.Pedido = pedido;

        this.Venta = venta;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MovimientosEN t = obj as MovimientosEN;
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
