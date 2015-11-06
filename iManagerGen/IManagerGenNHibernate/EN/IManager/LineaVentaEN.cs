
using System;
// Definición clase LineaVentaEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class LineaVentaEN
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
 *	Atributo venta
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> venta;



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



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> Venta {
        get { return venta; } set { venta = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public LineaVentaEN()
{
        venta = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.VentaEN>();
}



public LineaVentaEN(int id, int cantidad, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> venta, IManagerGenNHibernate.EN.IManager.ProductoEN producto
                    )
{
        this.init (Id, cantidad, venta, producto);
}


public LineaVentaEN(LineaVentaEN lineaVenta)
{
        this.init (Id, lineaVenta.Cantidad, lineaVenta.Venta, lineaVenta.Producto);
}

private void init (int id, int cantidad, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentaEN> venta, IManagerGenNHibernate.EN.IManager.ProductoEN producto)
{
        this.Id = id;


        this.Cantidad = cantidad;

        this.Venta = venta;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaVentaEN t = obj as LineaVentaEN;
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
