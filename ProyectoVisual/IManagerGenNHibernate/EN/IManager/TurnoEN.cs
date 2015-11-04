
using System;
// Definición clase TurnoEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class TurnoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo desde
 */
private string desde;



/**
 *	Atributo hasta
 */
private string hasta;



/**
 *	Atributo fecha
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.FechaEN> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Desde {
        get { return desde; } set { desde = value;  }
}



public virtual string Hasta {
        get { return hasta; } set { hasta = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.FechaEN> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public TurnoEN()
{
        fecha = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.FechaEN>();
}



public TurnoEN(int id, string nombre, string desde, string hasta, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.FechaEN> fecha
               )
{
        this.init (Id, nombre, desde, hasta, fecha);
}


public TurnoEN(TurnoEN turno)
{
        this.init (Id, turno.Nombre, turno.Desde, turno.Hasta, turno.Fecha);
}

private void init (int id, string nombre, string desde, string hasta, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.FechaEN> fecha)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Desde = desde;

        this.Hasta = hasta;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TurnoEN t = obj as TurnoEN;
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
