
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using System.Security.Cryptography;

namespace IManagerGenNHibernate.CEN.IManager
{
public partial class UsuarioCEN
{
public string Registrar (string p_email, string p_DNI, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fechaRegistro)
{
            /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_Usuario_registrar_customized) ENABLED START*/

            UsuarioEN usuarioEN = null;
            String pass, nonce = "Etsjj8BGtdbT1kPm2FtivCp1SY52pMYTQSobeoQKsSYRGI08lG5D3KThCaBh0AUwf6GYJ9gp2uDfd0jL";
            byte[] hash;
            string oid;
            pass = p_fechaRegistro.ToString() + nonce + p_password;

            using (SHA512 shaM = new SHA512Managed()) {
                hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(pass));
            }
            //Initialized UsuarioEN
            usuarioEN = new UsuarioEN();

            usuarioEN.Email = p_email;

            usuarioEN.DNI = p_DNI;

            usuarioEN.Password = Utils.Util.GetEncondeMD5(hash.ToString());

            usuarioEN.Nombre = p_nombre;

            usuarioEN.Apellidos = p_apellidos;

            usuarioEN.FechaRegistro = p_fechaRegistro;

            //Call to UsuarioCAD

            oid = _IUsuarioCAD.Registrar(usuarioEN);
            return oid;
            /*PROTECTED REGION END*/
        }
}
}
