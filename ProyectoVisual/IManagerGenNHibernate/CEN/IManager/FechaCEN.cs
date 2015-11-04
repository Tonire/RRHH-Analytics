

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
 *      Definition of the class FechaCEN
 *
 */
public partial class FechaCEN
{
private IFechaCAD _IFechaCAD;

public FechaCEN()
{
        this._IFechaCAD = new FechaCAD ();
}

public FechaCEN(IFechaCAD _IFechaCAD)
{
        this._IFechaCAD = _IFechaCAD;
}

public IFechaCAD get_IFechaCAD ()
{
        return this._IFechaCAD;
}

public Nullable<DateTime> CrearFecha (Nullable<DateTime> p_fecha, int p_turno)
{
        FechaEN fechaEN = null;

        Nullable<DateTime> oid;
        //Initialized FechaEN
        fechaEN = new FechaEN ();
        fechaEN.Fecha = p_fecha;


        if (p_turno != -1) {
                // El argumento p_turno -> Property turno es oid = false
                // Lista de oids fecha
                fechaEN.Turno = new IManagerGenNHibernate.EN.IManager.TurnoEN ();
                fechaEN.Turno.Id = p_turno;
        }

        //Call to FechaCAD

        oid = _IFechaCAD.CrearFecha (fechaEN);
        return oid;
}

public void Destroy (Nullable<DateTime> fecha)
{
        _IFechaCAD.Destroy (fecha);
}
}
}
