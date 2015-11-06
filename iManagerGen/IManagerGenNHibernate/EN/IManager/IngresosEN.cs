
using System;
// Definición clase IngresosEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class IngresosEN
{
protected IManagerGenNHibernate.EN.IManager.IngresosEN_OID ingresosEN_OID;
public virtual IngresosEN_OID IngresosOID {
        get { return ingresosEN_OID; } set { ingresosEN_OID = value;  }
}




/**
 *	Atributo anyo
 */
private string anyo;



/**
 *	Atributo mes
 */
private string mes;



/**
 *	Atributo ingresos
 */
private float ingresos;










public virtual float Ingresos {
        get { return ingresos; } set { ingresos = value;  }
}





public IngresosEN()
{
        ingresosEN_OID = new IManagerGenNHibernate.EN.IManager.IngresosEN_OID ();
}



public IngresosEN(IManagerGenNHibernate.EN.IManager.IngresosEN_OID ingresosEN_OID, float ingresos
                  )
{
        this.init (IngresosOID, ingresos);
}


public IngresosEN(IngresosEN ingresos)
{
        this.init (IngresosOID, ingresos.Ingresos);
}

private void init (IManagerGenNHibernate.EN.IManager.IngresosEN_OID ingresosEN_OID, float ingresos)
{
        this.IngresosOID = ingresosEN_OID;


        this.Ingresos = ingresos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        IngresosEN t = obj as IngresosEN;
        if (t == null)
                return false;
        if (IngresosOID.Equals (t.IngresosOID))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IngresosOID.GetHashCode ();
        return hash;
}
}
}
