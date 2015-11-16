
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
public partial class MovimientosCEN
{
public double GetMovimientoTotalMesAnyo (int p_mes_movimiento, int p_anyo_movimiento, string p_tipomovimiento)
{
        /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_Movimientos_getMovimientoTotalMesAnyo) ENABLED START*/

        // Write here your custom code...
        double total = 0;

        if (p_tipomovimiento != null) {
            System.Collections.Generic.IList<MovimientosEN> movimientosMesAnyo = _IMovimientosCAD.GetMovimientosByAnyoMes(p_mes_movimiento, p_anyo_movimiento, p_tipomovimiento);
            foreach(MovimientosEN movimiento in movimientosMesAnyo) {
                    total = total + movimiento.Cantidad;
            }
        }
        return total;
        /*PROTECTED REGION END*/
}
}
}
