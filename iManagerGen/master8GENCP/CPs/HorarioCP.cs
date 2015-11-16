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

        public void CrearHorario(HorarioEN horario, IList<String> usuarios, IList<TurnoEN> turnos, IList<DiaEN> dias)
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

                horario_oid = horarioCEN.CreaHorario(horario.Titulo, horario.Anyo, usuarios);

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
        }
       
    }
}
