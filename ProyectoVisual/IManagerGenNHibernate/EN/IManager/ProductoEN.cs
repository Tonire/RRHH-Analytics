
using System;
// Definición clase ProductoEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class ProductoEN
{
/**
 *	Atributo referencia
 */
private int referencia;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo marca
 */
private string marca;



/**
 *	Atributo precioCompra
 */
private int precioCompra;



/**
 *	Atributo precioVenta
 */
private int precioVenta;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> lineaPedido;



/**
 *	Atributo proveedor
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> proveedor;



/**
 *	Atributo ventas
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentasEN> ventas;






public virtual int Referencia {
        get { return referencia; } set { referencia = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Marca {
        get { return marca; } set { marca = value;  }
}



public virtual int PrecioCompra {
        get { return precioCompra; } set { precioCompra = value;  }
}



public virtual int PrecioVenta {
        get { return precioVenta; } set { precioVenta = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> Proveedor {
        get { return proveedor; } set { proveedor = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentasEN> Ventas {
        get { return ventas; } set { ventas = value;  }
}





public ProductoEN()
{
        lineaPedido = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.LineaPedidoEN>();
        proveedor = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.ProveedorEN>();
        ventas = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.VentasEN>();
}



public ProductoEN(int referencia, string nombre, string marca, int precioCompra, int precioVenta, int stock, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> proveedor, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentasEN> ventas
                  )
{
        this.init (Referencia, nombre, marca, precioCompra, precioVenta, stock, lineaPedido, proveedor, ventas);
}


public ProductoEN(ProductoEN producto)
{
        this.init (Referencia, producto.Nombre, producto.Marca, producto.PrecioCompra, producto.PrecioVenta, producto.Stock, producto.LineaPedido, producto.Proveedor, producto.Ventas);
}

private void init (int referencia, string nombre, string marca, int precioCompra, int precioVenta, int stock, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProveedorEN> proveedor, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.VentasEN> ventas)
{
        this.Referencia = referencia;


        this.Nombre = nombre;

        this.Marca = marca;

        this.PrecioCompra = precioCompra;

        this.PrecioVenta = precioVenta;

        this.Stock = stock;

        this.LineaPedido = lineaPedido;

        this.Proveedor = proveedor;

        this.Ventas = ventas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
        if (t == null)
                return false;
        if (Referencia.Equals (t.Referencia))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Referencia.GetHashCode ();
        return hash;
}
}
}
