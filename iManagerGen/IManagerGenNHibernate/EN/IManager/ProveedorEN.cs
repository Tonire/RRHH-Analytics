
using System;
// Definición clase ProveedorEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class ProveedorEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo telefono
 */
private string telefono;



/**
 *	Atributo producto
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProductoEN> producto;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProductoEN> Producto {
        get { return producto; } set { producto = value;  }
}





public ProveedorEN()
{
        producto = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.ProductoEN>();
}



public ProveedorEN(string email, string nombre, string telefono, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProductoEN> producto
                   )
{
        this.init (Email, nombre, telefono, producto);
}


public ProveedorEN(ProveedorEN proveedor)
{
        this.init (Email, proveedor.Nombre, proveedor.Telefono, proveedor.Producto);
}

private void init (string email, string nombre, string telefono, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProductoEN> producto)
{
        this.Email = email;


        this.Nombre = nombre;

        this.Telefono = telefono;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProveedorEN t = obj as ProveedorEN;
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
