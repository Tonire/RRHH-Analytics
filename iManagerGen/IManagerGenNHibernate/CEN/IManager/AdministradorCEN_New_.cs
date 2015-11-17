
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
    public partial class AdministradorCEN
    {
        public string New_(string p_email, string p_DNI, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fechaRegistro)
        {
            /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_Administrador_new__customized) ENABLED START*/

            AdministradorEN administradorEN = null;

            String pass, nonce = "Etsjj8BGtdbT1kPm2FtivCp1SY52pMYTQSobeoQKsSYRGI08lG5D3KThCaBh0AUwf6GYJ9gp2uDfd0jL";

            byte[] hash;
            string oid;
            pass = p_fechaRegistro.ToString() + nonce + p_password;

            using (System.Security.Cryptography.SHA512 shaM = new System.Security.Cryptography.SHA512Managed())
            {
                hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(pass));
            }

            //Initialized AdministradorEN
            administradorEN = new AdministradorEN();
            administradorEN.Email = p_email;

            administradorEN.DNI = p_DNI;

            administradorEN.Password = Utils.Util.GetEncondeMD5(System.Text.Encoding.UTF8.GetString(hash));

            administradorEN.Nombre = p_nombre;

            administradorEN.Apellidos = p_apellidos;

            administradorEN.FechaRegistro = p_fechaRegistro;

            //Call to AdministradorCAD

            oid = _IAdministradorCAD.New_(administradorEN);
            return oid;
            /*PROTECTED REGION END*/
        }
    }
}
