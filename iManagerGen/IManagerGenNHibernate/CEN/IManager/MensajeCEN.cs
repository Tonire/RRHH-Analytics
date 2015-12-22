

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;

namespace IManagerGenNHibernate.CEN.IManager
{
/*
 *      Definition of the class MensajeCEN
 *
 */
public partial class MensajeCEN
{
private IMensajeCAD _IMensajeCAD;

public MensajeCEN()
{
        this._IMensajeCAD = new MensajeCAD ();
}

public MensajeCEN(IMensajeCAD _IMensajeCAD)
{
        this._IMensajeCAD = _IMensajeCAD;
}

public IMensajeCAD get_IMensajeCAD ()
{
        return this._IMensajeCAD;
}

public int CreaMensaje (string p_remitente, string p_destinatario, string p_asunto, string p_contenido, bool p_leido)
{
        MensajeEN mensajeEN = null;
        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();

        if (p_remitente != null) {
                // El argumento p_remitente -> Property remitente es oid = false
                // Lista de oids id
                mensajeEN.Remitente = new IManagerGenNHibernate.EN.IManager.UsuarioEN ();
                mensajeEN.Remitente.Email = p_remitente;
        }


        if (p_destinatario != null) {
                // El argumento p_destinatario -> Property destinatario es oid = false
                // Lista de oids id
                mensajeEN.Destinatario = new IManagerGenNHibernate.EN.IManager.UsuarioEN ();
                mensajeEN.Destinatario.Email = p_destinatario;
        }

        mensajeEN.Asunto = p_asunto;

        mensajeEN.Contenido = p_contenido;

        mensajeEN.Leido = p_leido;

        //Call to MensajeCAD

        oid = _IMensajeCAD.CreaMensaje (mensajeEN);
        return oid;
}

public MensajeEN GetMensaje (int id)
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeCAD.GetMensaje (id);
        return mensajeEN;
}

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> GetMensajesByRemitente (string p_email)
{
        return _IMensajeCAD.GetMensajesByRemitente (p_email);
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.MensajeEN> GetMensajesByDestinatario (string p_email, int first, int size)
{
        return _IMensajeCAD.GetMensajesByDestinatario (p_email, first, size);
}
public void Modify (int p_Mensaje_OID, string p_asunto, string p_contenido, bool p_leido)
{
        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_Mensaje_OID;
        mensajeEN.Asunto = p_asunto;
        mensajeEN.Contenido = p_contenido;
        mensajeEN.Leido = p_leido;
        //Call to MensajeCAD

        _IMensajeCAD.Modify (mensajeEN);
}

public long ContarMensajesNoLeidosByDestinatario (string p_email)
{
        return _IMensajeCAD.ContarMensajesNoLeidosByDestinatario (p_email);
}
}
}
