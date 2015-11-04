
using System;
// Definición clase VentasEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class VentasEN
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





public VentasEN()
{
}



public VentasEN(int id, IManagerGenNHibernate.EN.IManager.UsuarioEN usuario, IManagerGenNHibernate.EN.IManager.ProductoEN producto
                )
{
        this.init (Id, usuario, producto);
}


public VentasEN(VentasEN ventas)
{
        this.init (Id, ventas.Usuario, ventas.Producto);
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
        VentasEN t = obj as VentasEN;
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
