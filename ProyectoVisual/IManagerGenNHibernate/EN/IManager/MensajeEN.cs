
using System;
// Definición clase MensajeEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class MensajeEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo remitente
 */
private IManagerGenNHibernate.EN.IManager.UsuarioEN remitente;



/**
 *	Atributo destinatario
 */
private IManagerGenNHibernate.EN.IManager.UsuarioEN destinatario;



/**
 *	Atributo asunto
 */
private string asunto;



/**
 *	Atributo contenido
 */
private string contenido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.UsuarioEN Remitente {
        get { return remitente; } set { remitente = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.UsuarioEN Destinatario {
        get { return destinatario; } set { destinatario = value;  }
}



public virtual string Asunto {
        get { return asunto; } set { asunto = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}





public MensajeEN()
{
}



public MensajeEN(int id, IManagerGenNHibernate.EN.IManager.UsuarioEN remitente, IManagerGenNHibernate.EN.IManager.UsuarioEN destinatario, string asunto, string contenido
                 )
{
        this.init (Id, remitente, destinatario, asunto, contenido);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (Id, mensaje.Remitente, mensaje.Destinatario, mensaje.Asunto, mensaje.Contenido);
}

private void init (int id, IManagerGenNHibernate.EN.IManager.UsuarioEN remitente, IManagerGenNHibernate.EN.IManager.UsuarioEN destinatario, string asunto, string contenido)
{
        this.Id = id;


        this.Remitente = remitente;

        this.Destinatario = destinatario;

        this.Asunto = asunto;

        this.Contenido = contenido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
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
