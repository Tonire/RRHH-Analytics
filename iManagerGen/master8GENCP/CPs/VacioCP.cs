﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using master8GenNHibernate.EN.Petstore3; // <- Apuntar a los respectivos paquetes de vuestro proyecto.
//using master8GenNHibernate.CAD.Petstore3;
//using master8GenNHibernate.CEN.Petstore3;
using NHibernate;

namespace EjemploProyectoCP.CPs
{
    public class VacioCP : BasicCP
    {

        public VacioCP() : base() { }

        public VacioCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public int EjemploOperacionCP()
        {
            //IPedidoCAD _IPedidoCAD = null;
            //PedidoCEN pedidoCEN = null;
            //ArticuloCP articuloCP = null;
            int oid = -1;

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

            return oid;
        }
       
    }
}
