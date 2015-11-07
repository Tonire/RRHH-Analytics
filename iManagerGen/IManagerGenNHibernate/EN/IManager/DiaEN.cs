
using System;
// Definición clase DiaEN
namespace IManagerGenNHibernate.EN.IManager
{
public partial class DiaEN
{
/**
 *	Atributo id
 */
private int id;



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






public virtual int Id {
        get { return id; } set { id = value;  }
}



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



public DiaEN(int id, IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum dia, IManagerGenNHibernate.EN.IManager.TurnoEN turno, IManagerGenNHibernate.EN.IManager.HorarioEN horario
             )
{
        this.init (Id, dia, turno, horario);
}


public DiaEN(DiaEN dia)
{
        this.init (Id, dia.Dia, dia.Turno, dia.Horario);
}

private void init (int id, IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum dia, IManagerGenNHibernate.EN.IManager.TurnoEN turno, IManagerGenNHibernate.EN.IManager.HorarioEN horario)
{
        this.Id = id;


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
