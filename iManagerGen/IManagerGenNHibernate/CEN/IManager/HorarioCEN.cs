

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;

namespace IManagerGenNHibernate.CEN.IManager
{
/*
 *      Definition of the class HorarioCEN
 *
 */
public partial class HorarioCEN
{
private IHorarioCAD _IHorarioCAD;

public HorarioCEN()
{
        this._IHorarioCAD = new HorarioCAD ();
}

public HorarioCEN(IHorarioCAD _IHorarioCAD)
{
        this._IHorarioCAD = _IHorarioCAD;
}

public IHorarioCAD get_IHorarioCAD ()
{
        return this._IHorarioCAD;
}

public void Modify (int p_Horario_OID, int p_anyo, string p_titulo)
{
        HorarioEN horarioEN = null;

        //Initialized HorarioEN
        horarioEN = new HorarioEN ();
        horarioEN.Id = p_Horario_OID;
        horarioEN.Anyo = p_anyo;
        horarioEN.Titulo = p_titulo;
        //Call to HorarioCAD

        _IHorarioCAD.Modify (horarioEN);
}

public void Destroy (int id)
{
        _IHorarioCAD.Destroy (id);
}

public int CreaHorario (int p_anyo, string p_titulo, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.FechaEN> p_fecha)
{
        HorarioEN horarioEN = null;
        int oid;

        //Initialized HorarioEN
        horarioEN = new HorarioEN ();
        horarioEN.Anyo = p_anyo;

        horarioEN.Titulo = p_titulo;

        horarioEN.Fecha = p_fecha;

        //Call to HorarioCAD

        oid = _IHorarioCAD.CreaHorario (horarioEN);
        return oid;
}
}
}
