
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IMovimientosCAD
{
MovimientosEN ReadOIDDefault (int id);

int CrearMovimiento (MovimientosEN movimientos);
}
}
