
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
public partial class PedidoCEN
{
public void Modify (int p_Pedido_OID, string p_descripcion, IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum p_estado, Nullable<DateTime> p_fechaRealizacion, Nullable<DateTime> p_fechaConfirmacion, Nullable<DateTime> p_fechaCancelacion)
{
        /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_Pedido_modify_customized) START*/

        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Descripcion = p_descripcion;
        pedidoEN.Estado = p_estado;
        pedidoEN.FechaRealizacion = p_fechaRealizacion;
        pedidoEN.FechaConfirmacion = p_fechaConfirmacion;
        pedidoEN.FechaCancelacion = p_fechaCancelacion;
        //Call to PedidoCAD

        _IPedidoCAD.Modify (pedidoEN);

        /*PROTECTED REGION END*/
}
}
}
