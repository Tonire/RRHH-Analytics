
using System;
// Definición clase FechaEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class FechaEN
{
/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo horario
 */
private IManagerGenNHibernate.EN.IManager.HorarioEN horario;



/**
 *	Atributo turno
 */
private IManagerGenNHibernate.EN.IManager.TurnoEN turno;






public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.HorarioEN Horario {
        get { return horario; } set { horario = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.TurnoEN Turno {
        get { return turno; } set { turno = value;  }
}





public FechaEN()
{
}



public FechaEN(Nullable<DateTime> fecha, IManagerGenNHibernate.EN.IManager.HorarioEN horario, IManagerGenNHibernate.EN.IManager.TurnoEN turno
               )
{
        this.init (Fecha, horario, turno);
}


public FechaEN(FechaEN fecha)
{
        this.init (Fecha, fecha.Horario, fecha.Turno);
}

private void init (Nullable<DateTime> fecha, IManagerGenNHibernate.EN.IManager.HorarioEN horario, IManagerGenNHibernate.EN.IManager.TurnoEN turno)
{
        this.Fecha = fecha;


        this.Horario = horario;

        this.Turno = turno;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FechaEN t = obj as FechaEN;
        if (t == null)
                return false;
        if (Fecha.Equals (t.Fecha))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Fecha.GetHashCode ();
        return hash;
}
}
}
