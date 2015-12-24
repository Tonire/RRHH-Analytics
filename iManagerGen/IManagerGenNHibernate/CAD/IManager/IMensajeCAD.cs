
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


System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> GetMensajesByDestinatario (string p_email, int first, int size);


void Modify (MensajeEN mensaje);


long ContarMensajesNoLeidosByDestinatario (string p_email);


void Destroy (int id);
}
}
