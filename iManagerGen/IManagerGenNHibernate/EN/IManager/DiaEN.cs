
using System;
// Definición clase DiaEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class DiaEN
{
/**
 *	Atributo dia
 */
private IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum dia;



/**
 *	Atributo turno
 */
private IManagerGenNHibernate.EN.IManager.TurnoEN turno;



/**
 *	Atributo horario
 */
private IManagerGenNHibernate.EN.IManager.HorarioEN horario;






public virtual IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum Dia {
        get { return dia; } set { dia = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.TurnoEN Turno {
        get { return turno; } set { turno = value;  }
}



public virtual IManagerGenNHibernate.EN.IManager.HorarioEN Horario {
        get { return horario; } set { horario = value;  }
}





public DiaEN()
{
}



public DiaEN(IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum dia, IManagerGenNHibernate.EN.IManager.TurnoEN turno, IManagerGenNHibernate.EN.IManager.HorarioEN horario
             )
{
        this.init (Dia, turno, horario);
}


public DiaEN(DiaEN dia)
{
        this.init (Dia, dia.Turno, dia.Horario);
}

private void init (IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum dia, IManagerGenNHibernate.EN.IManager.TurnoEN turno, IManagerGenNHibernate.EN.IManager.HorarioEN horario)
{
        this.Dia = dia;


        this.Turno = turno;

        this.Horario = horario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DiaEN t = obj as DiaEN;
        if (t == null)
                return false;
        if (Dia.Equals (t.Dia))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Dia.GetHashCode ();
        return hash;
}
}
}
