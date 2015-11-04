
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IBalanceCAD
{
BalanceEN ReadOIDDefault (int anyo);

int CrearBalance (BalanceEN balance);

System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.BalanceEN> GetBalancesPorAnyo ();
}
}
