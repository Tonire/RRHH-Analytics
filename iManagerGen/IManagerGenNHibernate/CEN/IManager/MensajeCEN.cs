

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

public int CreaMensaje (string p_Remitente, string p_Destinatario, string p_asunto, string p_contenido)
{
        MensajeEN mensajeEN = null;
        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();

        if (p_Remitente != null) {
                // El argumento p_Remitente -> Property Remitente es oid = false
                // Lista de oids id
                mensajeEN.Remitente = new IManagerGenNHibernate.EN.IManager.UsuarioEN ();
                mensajeEN.Remitente.Email = p_Remitente;
        }


        if (p_Destinatario != null) {
                // El argumento p_Destinatario -> Property Destinatario es oid = false
                // Lista de oids id
                mensajeEN.Destinatario = new IManagerGenNHibernate.EN.IManager.UsuarioEN ();
                mensajeEN.Destinatario.Email = p_Destinatario;
        }

        mensajeEN.Asunto = p_asunto;

        mensajeEN.Contenido = p_contenido;

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
}
}