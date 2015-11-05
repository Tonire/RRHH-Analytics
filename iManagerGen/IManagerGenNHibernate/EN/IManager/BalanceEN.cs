
using System;
// Definición clase BalanceEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class BalanceEN
{
/**
 *	Atributo anyo
 */
private int anyo;



/**
 *	Atributo mes
 */
private int mes;



/**
 *	Atributo gastos
 */
private double gastos;



/**
 *	Atributo ingresos
 */
private double ingresos;






public virtual int Anyo {
        get { return anyo; } set { anyo = value;  }
}



public virtual int Mes {
        get { return mes; } set { mes = value;  }
}



public virtual double Gastos {
        get { return gastos; } set { gastos = value;  }
}



public virtual double Ingresos {
        get { return ingresos; } set { ingresos = value;  }
}





public BalanceEN()
{
}



public BalanceEN(int anyo, int mes, double gastos, double ingresos
                 )
{
        this.init (Anyo, mes, gastos, ingresos);
}


public BalanceEN(BalanceEN balance)
{
        this.init (Anyo, balance.Mes, balance.Gastos, balance.Ingresos);
}

private void init (int anyo, int mes, double gastos, double ingresos)
{
        this.Anyo = anyo;


        this.Mes = mes;

        this.Gastos = gastos;

        this.Ingresos = ingresos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        BalanceEN t = obj as BalanceEN;
        if (t == null)
                return false;
        if (Anyo.Equals (t.Anyo))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Anyo.GetHashCode ();
        return hash;
}
}
}
