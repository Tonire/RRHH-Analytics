
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
public partial class EmpleadoCEN
{
public string New_ (string p_email, string p_DNI, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fechaRegistro)
{
        /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_Empleado_new__customized) ENABLED START*/

        EmpleadoEN empleadoEN = null;

        String pass, nonce = "Etsjj8BGtdbT1kPm2FtivCp1SY52pMYTQSobeoQKsSYRGI08lG5D3KThCaBh0AUwf6GYJ9gp2uDfd0jL";

        byte[] hash;
        string oid;
        pass = p_fechaRegistro.ToString () + nonce + p_password;

        using (System.Security.Cryptography.SHA512 shaM = new System.Security.Cryptography.SHA512Managed ())
        {
                hash = shaM.ComputeHash (Encoding.UTF8.GetBytes (pass));
        }


        //Initialized EmpleadoEN
        empleadoEN = new EmpleadoEN ();
        empleadoEN.Email = p_email;

        empleadoEN.DNI = p_DNI;
        string strHash = Convert.ToBase64String (hash);
        empleadoEN.Password = Utils.Util.GetEncondeMD5 (strHash);

        empleadoEN.Nombre = p_nombre;

        empleadoEN.Apellidos = p_apellidos;

        empleadoEN.FechaRegistro = p_fechaRegistro;

        //Call to EmpleadoCAD

        oid = _IEmpleadoCAD.New_ (empleadoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
