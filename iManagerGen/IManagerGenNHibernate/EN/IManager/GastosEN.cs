
using System;
// Definición clase GastosEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class GastosEN
{
protected IManagerGenNHibernate.EN.IManager.GastosEN_OID gastosEN_OID;
public virtual GastosEN_OID GastosOID {
        get { return gastosEN_OID; } set { gastosEN_OID = value;  }
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
 *	Atributo gastos
 */
private float gastos;










public virtual float Gastos {
        get { return gastos; } set { gastos = value;  }
}





public GastosEN()
{
        gastosEN_OID = new IManagerGenNHibernate.EN.IManager.GastosEN_OID ();
}



public GastosEN(IManagerGenNHibernate.EN.IManager.GastosEN_OID gastosEN_OID, float gastos
                )
{
        this.init (GastosOID, gastos);
}


public GastosEN(GastosEN gastos)
{
        this.init (GastosOID, gastos.Gastos);
}

private void init (IManagerGenNHibernate.EN.IManager.GastosEN_OID gastosEN_OID, float gastos)
{
        this.GastosOID = gastosEN_OID;


        this.Gastos = gastos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GastosEN t = obj as GastosEN;
        if (t == null)
                return false;
        if (GastosOID.Equals (t.GastosOID))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.GastosOID.GetHashCode ();
        return hash;
}
}
}
