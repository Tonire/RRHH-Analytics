
using System;
// Definición clase HorarioEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class HorarioEN
{
/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo anyo
 */
private int anyo;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.UsuarioEN> usuario;



/**
 *	Atributo dia
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.DiaEN> dia;



/**
 *	Atributo turno
 */
private System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.TurnoEN> turno;






public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual int Anyo {
        get { return anyo; } set { anyo = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.DiaEN> Dia {
        get { return dia; } set { dia = value;  }
}



public virtual System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.TurnoEN> Turno {
        get { return turno; } set { turno = value;  }
}





public HorarioEN()
{
        usuario = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.UsuarioEN>();
        dia = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.DiaEN>();
        turno = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.TurnoEN>();
}



public HorarioEN(string titulo, int anyo, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.UsuarioEN> usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.DiaEN> dia, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.TurnoEN> turno
                 )
{
        this.init (Titulo, anyo, usuario, dia, turno);
}


public HorarioEN(HorarioEN horario)
{
        this.init (Titulo, horario.Anyo, horario.Usuario, horario.Dia, horario.Turno);
}

private void init (string titulo, int anyo, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.UsuarioEN> usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.DiaEN> dia, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.TurnoEN> turno)
{
        this.Titulo = titulo;


        this.Anyo = anyo;

        this.Usuario = usuario;

        this.Dia = dia;

        this.Turno = turno;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        HorarioEN t = obj as HorarioEN;
        if (t == null)
                return false;
        if (Titulo.Equals (t.Titulo))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Titulo.GetHashCode ();
        return hash;
}
}
}
