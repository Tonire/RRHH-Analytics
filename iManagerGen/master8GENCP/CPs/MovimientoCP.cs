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
    public class MovimientoCP : BasicCP
    {

        public MovimientoCP() : base() { }

        public MovimientoCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public void CrearMovimiento(int p_oid_pedido, string tipo)
        {
            
            IMovimientosCAD _IMovimientosCAD = null;
            MovimientosCEN movimientosCEN = null;

            try
            {
                SessionInitializeTransaction();

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