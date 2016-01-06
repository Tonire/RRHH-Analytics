
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
public partial class UsuarioCEN
{
public void Modify (string p_Usuario_OID, string p_DNI, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fechaRegistro)
{
        /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_Usuario_modify_customized) ENABLED START*/

        UsuarioEN usuarioEN = null;
        String pass, nonce = "Etsjj8BGtdbT1kPm2FtivCp1SY52pMYTQSobeoQKsSYRGI08lG5D3KThCaBh0AUwf6GYJ9gp2uDfd0jL";

        byte[] hash;
        pass = p_fechaRegistro.ToString() + nonce + p_password;

        using (System.Security.Cryptography.SHA512 shaM = new System.Security.Cryptography.SHA512Managed()) {
            hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(pass));
        }

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.DNI = p_DNI;
        string strHash = Convert.ToBase64String(hash);
        usuarioEN.Password = Utils.Util.GetEncondeMD5(strHash);
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.FechaRegistro = p_fechaRegistro;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);

        /*PROTECTED REGION END*/
}
}
}
