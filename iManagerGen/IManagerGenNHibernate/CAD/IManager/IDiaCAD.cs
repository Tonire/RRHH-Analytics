
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IDiaCAD
{
DiaEN ReadOIDDefault (int id);

int CrearDia (DiaEN dia);

void Destroy (int id);


void AsignarTurno (int p_Dia_OID, int p_turno_OID);

System.Collections.Generic.IList<DiaEN> GetAllDias (int first, int size);
}
}
