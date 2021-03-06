

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
 *      Definition of the class TurnoCEN
 *
 */
public partial class TurnoCEN
{
private ITurnoCAD _ITurnoCAD;

public TurnoCEN()
{
        this._ITurnoCAD = new TurnoCAD ();
}

public TurnoCEN(ITurnoCAD _ITurnoCAD)
{
        this._ITurnoCAD = _ITurnoCAD;
}

public ITurnoCAD get_ITurnoCAD ()
{
        return this._ITurnoCAD;
}

public int CrearTurno (string p_nombre, string p_desde, string p_hasta, string p_horario)
{
        TurnoEN turnoEN = null;
        int oid;

        //Initialized TurnoEN
        turnoEN = new TurnoEN ();
        turnoEN.Nombre = p_nombre;

        turnoEN.Desde = p_desde;

        turnoEN.Hasta = p_hasta;


        if (p_horario != null) {
                // El argumento p_horario -> Property horario es oid = false
                // Lista de oids id
                turnoEN.Horario = new IManagerGenNHibernate.EN.IManager.HorarioEN ();
                turnoEN.Horario.Titulo = p_horario;
        }

        //Call to TurnoCAD

        oid = _ITurnoCAD.CrearTurno (turnoEN);
        return oid;
}

public void Modify (int p_Turno_OID, string p_nombre, string p_desde, string p_hasta)
{
        TurnoEN turnoEN = null;

        //Initialized TurnoEN
        turnoEN = new TurnoEN ();
        turnoEN.Id = p_Turno_OID;
        turnoEN.Nombre = p_nombre;
        turnoEN.Desde = p_desde;
        turnoEN.Hasta = p_hasta;
        //Call to TurnoCAD

        _ITurnoCAD.Modify (turnoEN);
}

public void Destroy (int id)
{
        _ITurnoCAD.Destroy (id);
}

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.TurnoEN> GetTurnosByHorario (string p_horario)
{
        return _ITurnoCAD.GetTurnosByHorario (p_horario);
}
}
}
