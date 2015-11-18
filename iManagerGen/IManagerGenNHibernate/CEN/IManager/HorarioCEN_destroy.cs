
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
public partial class HorarioCEN
{
public void Destroy (string titulo)
{
        /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_Horario_destroy_customized) START*/

        _IHorarioCAD.Destroy (titulo);

        /*PROTECTED REGION END*/
}
}
}
