

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

public int CrearTurno (string p_nombre, Nullable<DateTime> p_desde, Nullable<DateTime> p_hasta)
{
        TurnoEN turnoEN = null;
        int oid;

        //Initialized TurnoEN
        turnoEN = new TurnoEN ();
        turnoEN.Nombre = p_nombre;

        turnoEN.Desde = p_desde;

        turnoEN.Hasta = p_hasta;

        //Call to TurnoCAD

        oid = _ITurnoCAD.CrearTurno (turnoEN);
        return oid;
}

public void Modify (int p_Turno_OID, string p_nombre, Nullable<DateTime> p_desde, Nullable<DateTime> p_hasta)
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
}
}
