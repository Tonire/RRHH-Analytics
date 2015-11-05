
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
 *	Atributo producto
 */
private IManagerGenNHibernate.EN.IManager.ProductoEN producto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public VentaEN()
{
}



public VentaEN(int id, IManagerGenNHibernate.EN.IManager.UsuarioEN usuario, IManagerGenNHibernate.EN.IManager.ProductoEN producto
               )
{
        this.init (Id, usuario, producto);
}


public VentaEN(VentaEN venta)
{
        this.init (Id, venta.Usuario, venta.Producto);
}

private void init (int id, IManagerGenNHibernate.EN.IManager.UsuarioEN usuario, IManagerGenNHibernate.EN.IManager.ProductoEN producto)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Producto = producto;
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
