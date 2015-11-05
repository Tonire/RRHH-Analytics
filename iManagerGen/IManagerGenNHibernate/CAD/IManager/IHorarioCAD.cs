
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IHorarioCAD
{
HorarioEN ReadOIDDefault (int id);

void Modify (HorarioEN horario);


void Destroy (int id);


int CreaHorario (HorarioEN horario);
}
}
