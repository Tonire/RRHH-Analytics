

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
 *      Definition of the class HorarioCEN
 *
 */
public partial class HorarioCEN
{
private IHorarioCAD _IHorarioCAD;

public HorarioCEN()
{
        this._IHorarioCAD = new HorarioCAD ();
}

public HorarioCEN(IHorarioCAD _IHorarioCAD)
{
        this._IHorarioCAD = _IHorarioCAD;
}

public IHorarioCAD get_IHorarioCAD ()
{
        return this._IHorarioCAD;
}

public void Modify (string p_Horario_OID, int p_anyo)
{
        HorarioEN horarioEN = null;

        //Initialized HorarioEN
        horarioEN = new HorarioEN ();
        horarioEN.Titulo = p_Horario_OID;
        horarioEN.Anyo = p_anyo;
        //Call to HorarioCAD

        _IHorarioCAD.Modify (horarioEN);
}

public void Destroy (string titulo)
{
        _IHorarioCAD.Destroy (titulo);
}

public string CreaHorario (string p_titulo, int p_anyo, System.Collections.Generic.IList<string> p_usuario)
{
        HorarioEN horarioEN = null;
        string oid;

        //Initialized HorarioEN
        horarioEN = new HorarioEN ();
        horarioEN.Titulo = p_titulo;

        horarioEN.Anyo = p_anyo;


        horarioEN.Usuario = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.UsuarioEN>();
        if (p_usuario != null) {
                foreach (string item in p_usuario) {
                        IManagerGenNHibernate.EN.IManager.UsuarioEN en = new IManagerGenNHibernate.EN.IManager.UsuarioEN ();
                        en.Email = item;
                        horarioEN.Usuario.Add (en);
                }
        }

        else{
                horarioEN.Usuario = new System.Collections.Generic.List<IManagerGenNHibernate.EN.IManager.UsuarioEN>();
        }

        //Call to HorarioCAD

        oid = _IHorarioCAD.CreaHorario (horarioEN);
        return oid;
}

public void AsignarDias (string p_Horario_OID, System.Collections.Generic.IList<int> p_dia_OIDs)
{
        //Call to HorarioCAD

        _IHorarioCAD.AsignarDias (p_Horario_OID, p_dia_OIDs);
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.HorarioEN> GetHorarioByUsuario (string p_usuario)
{
        return _IHorarioCAD.GetHorarioByUsuario (p_usuario);
}
}
}
