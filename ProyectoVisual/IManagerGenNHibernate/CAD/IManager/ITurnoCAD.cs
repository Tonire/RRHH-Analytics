
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface ITurnoCAD
{
TurnoEN ReadOIDDefault (int id);

int CrearTurno (TurnoEN turno);

void Modify (TurnoEN turno);


void Destroy (int id);
}
}
