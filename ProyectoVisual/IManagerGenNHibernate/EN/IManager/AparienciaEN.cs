
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
 *	Atributo css
 */
private string css;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Logo {
        get { return logo; } set { logo = value;  }
}



public virtual string Css {
        get { return css; } set { css = value;  }
}





public AparienciaEN()
{
}



public AparienciaEN(string nombre, string logo, string css
                    )
{
        this.init (Nombre, logo, css);
}


public AparienciaEN(AparienciaEN apariencia)
{
        this.init (Nombre, apariencia.Logo, apariencia.Css);
}

private void init (string nombre, string logo, string css)
{
        this.Nombre = nombre;


        this.Logo = logo;

        this.Css = css;
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
