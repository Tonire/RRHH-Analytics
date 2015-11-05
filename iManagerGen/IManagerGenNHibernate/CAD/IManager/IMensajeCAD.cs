
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IMensajeCAD
{
MensajeEN ReadOIDDefault (int id);

int CreaMensaje (MensajeEN mensaje);

MensajeEN GetMensaje (int id);
}
}
