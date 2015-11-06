
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IDiaCAD
{
DiaEN ReadOIDDefault (IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum dia);

IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum CrearDia (DiaEN dia);

void Destroy (IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum dia);


void AsignarTurno (IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum p_Dia_OID, int p_turno_OID);
}
}
