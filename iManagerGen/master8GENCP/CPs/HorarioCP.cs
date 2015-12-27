using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using IManagerGenNHibernate.CEN.IManager;
using NHibernate;
using IManagerGenNHibernate.Enumerated.IManager;

namespace EjemploProyectoCP.CPs
{
    public class HorarioCP : BasicCP
    {

        public HorarioCP() : base() { }

        public HorarioCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public string CrearHorario(HorarioEN horario, IList<String> usuarios, IList<TurnoEN> turnos, IList<DiaEN> dias)
        {
            IHorarioCAD _IHorarioCAD = null;
            HorarioCEN horarioCEN = null;
            ITurnoCAD _ITurnoCAD = null;
            TurnoCEN turnoCEN = null;
            IDiaCAD _IDiaCAD = null;
            DiaCEN diaCEN = null;

            String horario_oid;
            try
            {
                SessionInitializeTransaction();
                _IHorarioCAD = new HorarioCAD(session);
                horarioCEN = new HorarioCEN(_IHorarioCAD);

                _ITurnoCAD = new TurnoCAD(session);
                turnoCEN = new TurnoCEN(_ITurnoCAD);

                _IDiaCAD = new DiaCAD(session);
                diaCEN = new DiaCEN(_IDiaCAD);

                horario_oid = horarioCEN.CreaHorario(horario.Titulo, horario.Anyo, usuarios, horario.Mes);

                foreach (TurnoEN turno in turnos) {
                    turnoCEN.CrearTurno(turno.Nombre,turno.Desde,turno.Hasta,horario_oid);
                }

                turnos=turnoCEN.GetTurnosByHorario(horario_oid);

                foreach (DiaEN dia in dias) {
                    int oid = 0;
                    foreach (TurnoEN turno in turnos) {
                        if (dia.Turno.Nombre.CompareTo(turno.Nombre)==0){
                            oid = turno.Id;
                            diaCEN.CrearDia(dia.Dia, oid,horario_oid);
                            break;
                        }
                    }
                }

                SessionCommit();

            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }
            return horario_oid;
        }
        /*Este metodo borra el horario, eliminando mediante un Unrelationer su relacion en usuario, ademas borra de la base de datos
        los dias y turnos de dicho horario. OJO: Los borra totalmente no solo su relacion*/
        public void borrarHorario(string horario_oid)
        {
            IHorarioCAD _IHorarioCAD = null;
            HorarioCEN horarioCEN = null;
            ITurnoCAD _ITurnoCAD = null;
            TurnoCEN turnoCEN = null;
            IDiaCAD _IDiaCAD = null;
            DiaCEN diaCEN = null;

            try
            {
                SessionInitializeTransaction();
                _IHorarioCAD = new HorarioCAD(session);
                horarioCEN = new HorarioCEN(_IHorarioCAD);

                _ITurnoCAD = new TurnoCAD(session);
                turnoCEN = new TurnoCEN(_ITurnoCAD);

                _IDiaCAD = new DiaCAD(session);
                diaCEN = new DiaCEN(_IDiaCAD);

                HorarioEN horario=horarioCEN.GetHorario(horario_oid);

                /*Quitamos la relacion entre el horario X y los usuarios que tienen dicho horario*/
                IList<string> usuarios = new List<string>();
                foreach (UsuarioEN usuario in horario.Usuario){
                    usuarios.Add(usuario.Email);
                }
                horarioCEN.QuitarUsuario(horario_oid, usuarios);
                
                /*Eliminamos los turnos asociados al horario*/
                foreach (TurnoEN turno in horario.Turno)
                {
                    turnoCEN.Destroy(turno.Id);
                }

                /*Eliminamos los dias asociados al horario*/
                foreach (DiaEN dia in horario.Dia)
                {
                    diaCEN.Destroy(dia.Id);
                }

                horarioCEN.Destroy(horario_oid);
                SessionCommit();

            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }
        }

    }
}
