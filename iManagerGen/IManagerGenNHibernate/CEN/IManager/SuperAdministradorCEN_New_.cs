
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
public partial class SuperAdministradorCEN
{
public string New_ (string p_email, string p_DNI, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fechaRegistro)
{
        /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_SuperAdministrador_new__customized) ENABLED START*/

        SuperAdministradorEN superAdministradorEN = null;

        String pass, nonce = "Etsjj8BGtdbT1kPm2FtivCp1SY52pMYTQSobeoQKsSYRGI08lG5D3KThCaBh0AUwf6GYJ9gp2uDfd0jL";

        byte[] hash;
        string oid;
        pass = p_fechaRegistro.ToString () + nonce + p_password;

        using (System.Security.Cryptography.SHA512 shaM = new System.Security.Cryptography.SHA512Managed ())
        {
                hash = shaM.ComputeHash (Encoding.UTF8.GetBytes (pass));
        }

        //Initialized SuperAdministradorEN
        superAdministradorEN = new SuperAdministradorEN ();
        superAdministradorEN.Email = p_email;

        superAdministradorEN.DNI = p_DNI;
        string strHash = Convert.ToBase64String (hash);
        superAdministradorEN.Password = Utils.Util.GetEncondeMD5 (strHash);

        superAdministradorEN.Nombre = p_nombre;

        superAdministradorEN.Apellidos = p_apellidos;

        superAdministradorEN.FechaRegistro = p_fechaRegistro;

        //Call to SuperAdministradorCAD

        oid = _ISuperAdministradorCAD.New_ (superAdministradorEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
