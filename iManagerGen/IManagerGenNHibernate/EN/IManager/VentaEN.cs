
using System;
// Definición clase VentaEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class VentaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private IManagerGenNHibernate.EN.IManager.UsuarioEN usuario;



/**
 *	Atributo lineaVenta
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaVentaEN> lineaVenta;



/**
 *	Atributo fechaVenta
 */
private string fechaVenta;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaVentaEN> LineaVenta {
        get { return lineaVenta; } set { lineaVenta = value;  }
}



public virtual string FechaVenta {
        get { return fechaVenta; } set { fechaVenta = value;  }
}





public VentaEN()
{
        lineaVenta = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.LineaVentaEN>();
}



public VentaEN(int id, IManagerGenNHibernate.EN.IManager.UsuarioEN usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaVentaEN> lineaVenta, string fechaVenta
               )
{
        this.init (Id, usuario, lineaVenta, fechaVenta);
}


public VentaEN(VentaEN venta)
{
        this.init (Id, venta.Usuario, venta.LineaVenta, venta.FechaVenta);
}

private void init (int id, IManagerGenNHibernate.EN.IManager.UsuarioEN usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaVentaEN> lineaVenta, string fechaVenta)
{
        this.Id = id;


        this.Usuario = usuario;

        this.LineaVenta = lineaVenta;

        this.FechaVenta = fechaVenta;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        VentaEN t = obj as VentaEN;
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
