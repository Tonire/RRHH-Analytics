

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

public IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum CrearDia (IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum p_dia)
{
        DiaEN diaEN = null;

        IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum oid;
        //Initialized DiaEN
        diaEN = new DiaEN ();
        diaEN.Dia = p_dia;

        //Call to DiaCAD

        oid = _IDiaCAD.CrearDia (diaEN);
        return oid;
}

public void Destroy (IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum dia)
{
        _IDiaCAD.Destroy (dia);
}

public void AsignarTurno (IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum p_Dia_OID, int p_turno_OID)
{
        //Call to DiaCAD

        _IDiaCAD.AsignarTurno (p_Dia_OID, p_turno_OID);
}
}
}
