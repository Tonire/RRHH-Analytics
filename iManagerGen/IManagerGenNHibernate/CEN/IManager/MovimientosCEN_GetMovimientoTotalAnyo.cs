
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
public double GetMovimientoTotalAnyo (int p_anyo, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum p_tipomovimiento)
{
        /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_Movimientos_getMovimientoTotalAnyo) ENABLED START*/

        // Write here your custom code...
        double total = 0;

        if (p_anyo > 1) {
                System.Collections.Generic.IList<MovimientosEN> movimientosAnyo = _IMovimientosCAD.GetMovimientosByAnyo (p_anyo, p_tipomovimiento);

                foreach (MovimientosEN movimiento in movimientosAnyo) {
                        total = total + movimiento.Cantidad;
                }
        }
        return total;

        //throw new NotImplementedException ("Method GetMovimientoTotalAnyo() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
