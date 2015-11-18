

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
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoCAD _IPedidoCAD;

public PedidoCEN()
{
        this._IPedidoCAD = new PedidoCAD ();
}

public PedidoCEN(IPedidoCAD _IPedidoCAD)
{
        this._IPedidoCAD = _IPedidoCAD;
}

public IPedidoCAD get_IPedidoCAD ()
{
        return this._IPedidoCAD;
}

public int CrearPedido (string p_descripcion, IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum p_estado, Nullable<DateTime> p_fechaRealizacion, string p_usuario, System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.LineaPedidoEN> p_lineaPedido)
{
        PedidoEN pedidoEN = null;
        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Descripcion = p_descripcion;

        pedidoEN.Estado = p_estado;

        pedidoEN.FechaRealizacion = p_fechaRealizacion;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                pedidoEN.Usuario = new IManagerGenNHibernate.EN.IManager.UsuarioEN ();
                pedidoEN.Usuario.Email = p_usuario;
        }

        pedidoEN.LineaPedido = p_lineaPedido;

        //Call to PedidoCAD

        oid = _IPedidoCAD.CrearPedido (pedidoEN);
        return oid;
}

public void Destroy (int id)
{
        _IPedidoCAD.Destroy (id);
}

public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> GetPedidosPendientes ()
{
        return _IPedidoCAD.GetPedidosPendientes ();
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> GetPedidosConfirmados ()
{
        return _IPedidoCAD.GetPedidosConfirmados ();
}
public System.Collections.Generic.IList<IManagerGenNHibernate.EN.IManager.PedidoEN> GetPedidosCancelados ()
{
        return _IPedidoCAD.GetPedidosCancelados ();
}
public PedidoEN GetPedidoById (int id)
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoCAD.GetPedidoById (id);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoCAD.DameTodos (first, size);
        return list;
}
}
}
