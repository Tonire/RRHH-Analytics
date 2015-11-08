
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using System.Windows.Forms;
//using EjemploProyectoCP.CPs;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                /*List<IManagerGenNHibernate.EN.Mediaplayer.MusicTrackEN> musicTracks = new List<IManagerGenNHibernate.EN.Mediaplayer.MusicTrackEN>();
                 * IManagerGenNHibernate.EN.Mediaplayer.UserEN userEN = new IManagerGenNHibernate.EN.Mediaplayer.UserEN();
                 * IManagerGenNHibernate.EN.Mediaplayer.ArtistEN artistEN = new IManagerGenNHibernate.EN.Mediaplayer.ArtistEN();
                 * IManagerGenNHibernate.EN.Mediaplayer.MusicTrackEN musicTrackEN = new IManagerGenNHibernate.EN.Mediaplayer.MusicTrackEN();
                 * IManagerGenNHibernate.CEN.Mediaplayer.ArtistCEN artistCEN = new IManagerGenNHibernate.CEN.Mediaplayer.ArtistCEN();
                 * IManagerGenNHibernate.CEN.Mediaplayer.UserCEN userCEN = new IManagerGenNHibernate.CEN.Mediaplayer.UserCEN();
                 * IManagerGenNHibernate.CEN.Mediaplayer.MusicTrackCEN musicTrackCEN = new IManagerGenNHibernate.CEN.Mediaplayer.MusicTrackCEN();
                 * IManagerGenNHibernate.CEN.Mediaplayer.PlayListCEN playListCEN = new IManagerGenNHibernate.CEN.Mediaplayer.PlayListCEN();
                 *
                 *              //Add Users
                 * userEN.Email = "user@user.com";
                 * userEN.Name = "user";
                 * userEN.Surname = "userSurname";
                 * userEN.Password = "user";
                 * userCEN.New_(userEN.Name, userEN.Surname, userEN.Email, userEN.Password);
                 *
                 * //Add Music Track1
                 * musicTrackEN.Id = "http://www2.b3ta.com/mp3/Beer Beer Beer (YOB mix).mp3";
                 * musicTrackEN.Format = "mp3";
                 * musicTrackEN.Lyrics = "Beer Beer Beer Beer Beer Beer ..";
                 * musicTrackEN.Name = "Beer Beer Beer";
                 * musicTrackEN.Company = "Company";
                 * musicTrackEN.Cover = "http://www.tomasabraham.com.ar/cajadig/2007/images/nro18-2/beer1.jpg";
                 * musicTrackEN.Price = 20;
                 * musicTrackEN.Rating = 5;
                 * musicTrackEN.CommunityRating = 5;
                 * musicTrackEN.Duration = 200;
                 * musicTrackCEN.New_(musicTrackEN.Id, musicTrackEN.Format, musicTrackEN.Lyrics, musicTrackEN.Name,
                 *  musicTrackEN.Company, musicTrackEN.Cover, musicTrackEN.CommunityRating, musicTrackEN.Rating,
                 *  musicTrackEN.Price, musicTrackEN.Duration);
                 * musicTracks.Add(musicTrackEN);
                 * musicTrackCEN.AsignUser(musicTrackEN.Id,userEN.Email);
                 *
                 * //Define Album
                 * //IManagerGenNHibernate.CEN.Mediaplayer.AlbumCEN albumCEN = new IManagerGenNHibernate.CEN.Mediaplayer.AlbumCEN();
                 * //albumCEN.New_("Album 1", "This is a Album 1", artists, musicTracks);*/
                #region Cliente
                //Cliente 1
                //MessageBox.Show ("Cago en dios!");
                IUsuarioCAD _IUsuarioCAD = new UsuarioCAD ();
                UsuarioCEN usuarioCEN = new UsuarioCEN (_IUsuarioCAD);
                IMensajeCAD _IMensajeCAD = new MensajeCAD ();
                MensajeCEN mensajeCEN = new MensajeCEN (_IMensajeCAD);
                IHorarioCAD _IHorarioCAD = new HorarioCAD();
                HorarioCEN horarioCEN = new HorarioCEN(_IHorarioCAD);
                UsuarioEN toni = new UsuarioEN ();
                UsuarioEN julio = new UsuarioEN ();
                toni.Email = "toni.rb.rebollo.el.mas.xulo@hotmail.com";
                toni.DNI = "48730721h";
                toni.Password = "tonireasdf";
                usuarioCEN.Registrar (toni.Email, toni.DNI, toni.Password);
                //CLiente 2
                julio.Email = "julio.el.pro@hotmail.com";
                julio.DNI = "48730721T";
                julio.Password = "julioasdf";
                usuarioCEN.Registrar (julio.Email, julio.DNI, julio.Password);
                MensajeEN mensaje1 = new MensajeEN ();
                mensaje1.Asunto = "Te reviento";
                mensaje1.Contenido = "Te voy a reventar un dia de estos.";
                mensajeCEN.CreaMensaje (julio.Email, toni.Email, mensaje1.Asunto, mensaje1.Contenido);
                IList<MensajeEN> listaMensajes = mensajeCEN.GetMensajesByRemitente (julio.Email);
                //MensajeEN mensaje = mensajeCEN.GetMensajesByRemitente (julio.Email);
                //MessageBox.Show ("El asunto es: " + listaMensajes [0].Asunto);

                //Creamos Turnos
                List<TurnoEN> turnos = new List<TurnoEN>();
                TurnoEN turno = new TurnoEN();
                turno.Nombre = "tarde";
                turnos.Add(turno);
                turno.Nombre = "mañana";
                turnos.Add(turno);
                turno.Nombre = "especial";
                turnos.Add(turno);

                //Creamos Dias
                List<DiaEN> dias = new List<DiaEN>();
                DiaEN dia = new DiaEN();

                dia.Dia =IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.lunes;
                dias.Add(dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.martes;
                dias.Add(dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.miercoles;
                dias.Add(dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.jueves;
                dias.Add(dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.viernes;
                dias.Add(dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.sabado;
                dias.Add(dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.domingo;
                dias.Add(dia);

                //UsuarioEN usuario = new UsuarioEN();
                System.Collections.Generic.IList<string> usuarios = null;
                usuarios.Add(usuarioCEN.GetUsuarioByEmail("toni.rb.rebollo.el.mas.xulo@hotmail.com").Email);
                usuarios.Add(usuarioCEN.GetUsuarioByEmail("julio.el.pro@hotmail.com").Email);

                horarioCEN.CreaHorario("horario semanal 1",2015,usuarios,turnos);
                #endregion
                /*PROTECTED REGION END*/
            }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
