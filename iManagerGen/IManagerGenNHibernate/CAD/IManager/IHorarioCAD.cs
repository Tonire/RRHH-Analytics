
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IHorarioCAD
{
HorarioEN ReadOIDDefault (string titulo);

void Modify (HorarioEN horario);


void Destroy (string titulo);


string CreaHorario (HorarioEN horario);

void AsignarDias (string p_Horario_OID, System.Collections.Generic.IList<int> p_dia_OIDs);

System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> GetHorariosByUsuario (string p_usuario);


HorarioEN GetHorario (string titulo);


System.Collections.Generic.IList<HorarioEN> DameTodos (int first, int size);
}
}
