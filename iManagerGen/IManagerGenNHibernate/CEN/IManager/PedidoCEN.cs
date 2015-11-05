

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

public int CrearPedido (string p_total, IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum p_descripcion, string p_usuario)
{
        PedidoEN pedidoEN = null;
        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Total = p_total;

        pedidoEN.Descripcion = p_descripcion;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                pedidoEN.Usuario = new IManagerGenNHibernate.EN.IManager.UsuarioEN ();
                pedidoEN.Usuario.Email = p_usuario;
        }

        //Call to PedidoCAD

        oid = _IPedidoCAD.CrearPedido (pedidoEN);
        return oid;
}

public void Modify (int p_Pedido_OID, string p_total, IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum p_descripcion)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Total = p_total;
        pedidoEN.Descripcion = p_descripcion;
        //Call to PedidoCAD

        _IPedidoCAD.Modify (pedidoEN);
}

public void Destroy (int id)
{
        _IPedidoCAD.Destroy (id);
}
}
}
