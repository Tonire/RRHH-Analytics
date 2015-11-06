
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IMensajeCAD
{
MensajeEN ReadOIDDefault (int id);

int CreaMensaje (MensajeEN mensaje);

MensajeEN GetMensaje (int id);


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> GetMensajesByRemitente (string p_email);


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> GetMensajesByDestinatario (string p_email);
}
}
