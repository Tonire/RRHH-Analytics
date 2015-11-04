
using System;
// Definición clase HorarioEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class HorarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo anyo
 */
private int anyo;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.UsuarioEN> usuario;



/**
 *	Atributo fecha
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.FechaEN> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Anyo {
        get { return anyo; } set { anyo = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.FechaEN> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public HorarioEN()
{
        usuario = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.UsuarioEN>();
        fecha = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.FechaEN>();
}



public HorarioEN(int id, int anyo, string titulo, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.UsuarioEN> usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.FechaEN> fecha
                 )
{
        this.init (Id, anyo, titulo, usuario, fecha);
}


public HorarioEN(HorarioEN horario)
{
        this.init (Id, horario.Anyo, horario.Titulo, horario.Usuario, horario.Fecha);
}

private void init (int id, int anyo, string titulo, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.UsuarioEN> usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.FechaEN> fecha)
{
        this.Id = id;


        this.Anyo = anyo;

        this.Titulo = titulo;

        this.Usuario = usuario;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        HorarioEN t = obj as HorarioEN;
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
