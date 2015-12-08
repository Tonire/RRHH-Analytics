
using System;
// Definición clase AparienciaEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class AparienciaEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo logo
 */
private string logo;



/**
 *	Atributo superAdmin
 */
private string superAdmin;



/**
 *	Atributo admin
 */
private string admin;



/**
 *	Atributo empleado
 */
private string empleado;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Logo {
        get { return logo; } set { logo = value;  }
}



public virtual string SuperAdmin {
        get { return superAdmin; } set { superAdmin = value;  }
}



public virtual string Admin {
        get { return admin; } set { admin = value;  }
}



public virtual string Empleado {
        get { return empleado; } set { empleado = value;  }
}





public AparienciaEN()
{
}



public AparienciaEN(string nombre, string logo, string superAdmin, string admin, string empleado
                    )
{
        this.init (Nombre, logo, superAdmin, admin, empleado);
}


public AparienciaEN(AparienciaEN apariencia)
{
        this.init (Nombre, apariencia.Logo, apariencia.SuperAdmin, apariencia.Admin, apariencia.Empleado);
}

private void init (string nombre, string logo, string superAdmin, string admin, string empleado)
{
        this.Nombre = nombre;


        this.Logo = logo;

        this.SuperAdmin = superAdmin;

        this.Admin = admin;

        this.Empleado = empleado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AparienciaEN t = obj as AparienciaEN;
        if (t == null)
                return false;
        if (Nombre.Equals (t.Nombre))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nombre.GetHashCode ();
        return hash;
}
}
}
