
using System;
using IManagerGenNHibernate.EN.IManager;

namespace IManagerGenNHibernate.CAD.IManager
{
public partial interface IAparienciaCAD
{
AparienciaEN ReadOIDDefault (string nombre);

string CrearApariencia (AparienciaEN apariencia);

System.Collections.Generic.IList<AparienciaEN> GetApariencia (int first, int size);


void Modify (AparienciaEN apariencia);


void Destroy (string nombre);
}
}
