

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
 *      Definition of the class DiaCEN
 *
 */
public partial class DiaCEN
{
private IDiaCAD _IDiaCAD;

public DiaCEN()
{
        this._IDiaCAD = new DiaCAD ();
}

public DiaCEN(IDiaCAD _IDiaCAD)
{
        this._IDiaCAD = _IDiaCAD;
}

public IDiaCAD get_IDiaCAD ()
{
        return this._IDiaCAD;
}

public int CrearDia (IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum p_dia, int p_turno, string p_horario)
{
        DiaEN diaEN = null;
        int oid;

        //Initialized DiaEN
        diaEN = new DiaEN ();
        diaEN.Dia = p_dia;


        if (p_turno != -1) {
                // El argumento p_turno -> Property turno es oid = false
                // Lista de oids id
                diaEN.Turno = new IManagerGenNHibernate.EN.IManager.TurnoEN ();
                diaEN.Turno.Id = p_turno;
        }


        if (p_horario != null) {
                // El argumento p_horario -> Property horario es oid = false
                // Lista de oids id
                diaEN.Horario = new IManagerGenNHibernate.EN.IManager.HorarioEN ();
                diaEN.Horario.Titulo = p_horario;
        }

        //Call to DiaCAD

        oid = _IDiaCAD.CrearDia (diaEN);
        return oid;
}

public void Destroy (int id)
{
        _IDiaCAD.Destroy (id);
}

public void AsignarTurno (int p_Dia_OID, int p_turno_OID)
{
        //Call to DiaCAD

        _IDiaCAD.AsignarTurno (p_Dia_OID, p_turno_OID);
}
public System.Collections.Generic.IList<DiaEN> GetAllDias (int first, int size)
{
        System.Collections.Generic.IList<DiaEN> list = null;

        list = _IDiaCAD.GetAllDias (first, size);
        return list;
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.DiaEN> GetDiasByHorario (string p_horario)
{
        return _IDiaCAD.GetDiasByHorario (p_horario);
}
}
}
