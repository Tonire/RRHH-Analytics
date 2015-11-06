using System;
using System.Collections.Generic;
namespace IManagerGenNHibernate.EN.IManager
{
public class IngresosEN_OID
{
private string anyo;
public virtual string Anyo {
        get { return anyo; } set { anyo = value;  }
}




private string mes;
public virtual string Mes {
        get { return mes; } set { mes = value;  }
}






public IngresosEN_OID()
{
}
public IngresosEN_OID(string anyo, string mes)
{
        this.anyo = anyo;
        this.mes = mes;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        IngresosEN_OID t = obj as IngresosEN_OID;
        if (t == null)
                return false;


        if (this.anyo == t.Anyo && this.mes == t.Mes)

                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        // Su tipo es String
        hash = hash +
               (null == anyo                                                     ? 0 : this.anyo.GetHashCode ());
        // Su tipo es String
        hash = hash +
               (null == mes                                                      ? 0 : this.mes.GetHashCode ());
        return hash;
}
}
}
