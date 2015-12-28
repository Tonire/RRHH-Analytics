
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



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo localidad
 */
private string localidad;



/**
 *	Atributo pais
 */
private string pais;



/**
 *	Atributo cIF
 */
private string cIF;






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



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Localidad {
        get { return localidad; } set { localidad = value;  }
}



public virtual string Pais {
        get { return pais; } set { pais = value;  }
}



public virtual string CIF {
        get { return cIF; } set { cIF = value;  }
}





public ProveedorEN()
{
        producto = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.ProductoEN>();
}



public ProveedorEN(string email, string nombre, string telefono, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProductoEN> producto, string direccion, string localidad, string pais, string cIF
                   )
{
        this.init (Email, nombre, telefono, producto, direccion, localidad, pais, cIF);
}


public ProveedorEN(ProveedorEN proveedor)
{
        this.init (Email, proveedor.Nombre, proveedor.Telefono, proveedor.Producto, proveedor.Direccion, proveedor.Localidad, proveedor.Pais, proveedor.CIF);
}

private void init (string email, string nombre, string telefono, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.ProductoEN> producto, string direccion, string localidad, string pais, string cIF)
{
        this.Email = email;


        this.Nombre = nombre;

        this.Telefono = telefono;

        this.Producto = producto;

        this.Direccion = direccion;

        this.Localidad = localidad;

        this.Pais = pais;

        this.CIF = cIF;
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
