
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
public IManagerGenNHibernate.EN.IManager.UsuarioEN IniciarSesion (string p_oid, string pass)
{
        /*PROTECTED REGION ID(IManagerGenNHibernate.CEN.IManager_Usuario_iniciarSesion) ENABLED START*/
        UsuarioEN usuarioEN = null;
        bool login = false;
        DateTime? fechaReg;
        String nonce = "Etsjj8BGtdbT1kPm2FtivCp1SY52pMYTQSobeoQKsSYRGI08lG5D3KThCaBh0AUwf6GYJ9gp2uDfd0jL";
        String password;

        byte[] hash;

        if (p_oid != null && pass != null) {
                usuarioEN = _IUsuarioCAD.GetUsuarioByEmail (p_oid);

                if (usuarioEN != null) {
                        fechaReg = usuarioEN.FechaRegistro;
                        password = fechaReg.ToString () + nonce + pass;
                        using (System.Security.Cryptography.SHA512 shaM = new System.Security.Cryptography.SHA512Managed ())
                        {
                                hash = shaM.ComputeHash (Encoding.UTF8.GetBytes (password));
                        }
                        String strHash = Convert.ToBase64String (hash);
                        String md5 = Utils.Util.GetEncondeMD5 (strHash);
                        if (usuarioEN.Password.CompareTo (md5) == 0) {
                                login = true;
                                Console.WriteLine ("-------------------------------------------Login Correcto-------------------------------------------");
                        }
                        else{
                                Console.WriteLine ("--------------------------------ERROR EN EL LOGIN CONTRASE�A INCORRECTA!----------------------------------");
                        }
                }
        }
        if (!login) {
                usuarioEN = null;
        }
        //return login;
        return usuarioEN;
        /*PROTECTED REGION END*/
}
}
}
