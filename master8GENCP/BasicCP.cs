using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using IManagerGenNHibernate.CAD.IManager; // <- Poner el nombre del proyecto NHibernate + GenHibernate.CAD + NombreProyectoOOH4RIA
                                         // Acordaros de añadir la referencia al proyecto GenHibernate. (Add References) 

namespace EjemploProyectoCP
{
    public class BasicCP
    {
        protected ISession session;

        protected bool sessionStarted;

        protected ITransaction tx;

        protected BasicCP()
        {
                sessionStarted = true;
        }

        protected BasicCP(ISession sessionAux)
        {
                session = sessionAux;
                sessionStarted = false;
        }

        protected void SessionInitializeTransaction ()
        {
                if (session == null && sessionStarted==true) {
                        session = NHibernateHelper.OpenSession ();
                        tx = session.BeginTransaction ();
                }
        }

        protected void SessionCommit ()
        {
                if (sessionStarted && session != null)
                        tx.Commit ();
        }

        protected void SessionRollBack ()
        {
                if (sessionStarted && session != null && session.IsOpen)
                        tx.Rollback ();
        }

        protected void SessionClose ()
        {
                if (sessionStarted && session != null && session.IsOpen) {
                        session.Close ();
                        session.Dispose ();
                        session = null;
                }
        }
    }
}
