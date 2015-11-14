
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.CAD.IManager;
//using System.Windows.Forms;
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
                IUsuarioCAD _IUsuarioCAD = new UsuarioCAD ();
                UsuarioCEN usuarioCEN = new UsuarioCEN (_IUsuarioCAD);
                IMensajeCAD _IMensajeCAD = new MensajeCAD ();
                MensajeCEN mensajeCEN = new MensajeCEN (_IMensajeCAD);
                IHorarioCAD _IHorarioCAD = new HorarioCAD ();
                HorarioCEN horarioCEN = new HorarioCEN (_IHorarioCAD);
                IPedidoCAD _IPedidoCAD = new PedidoCAD ();
                PedidoCEN pedidoCEN = new PedidoCEN (_IPedidoCAD);
                IProductoCAD _IProductoCAD = new ProductoCAD ();
                ProductoCEN productoCEN = new ProductoCEN (_IProductoCAD);
                IProveedorCAD _IProveedorCAD = new ProveedorCAD ();
                ProveedorCEN proveedorCEN = new ProveedorCEN (_IProveedorCAD);
                ISuperAdministradorCAD _ISuperAdministradorCAD = new SuperAdministradorCAD ();
                SuperAdministradorCEN superCEN = new SuperAdministradorCEN ();


                UsuarioEN toni = new UsuarioEN ();
                UsuarioEN julio = new UsuarioEN ();
                SuperAdministradorEN jefe = new SuperAdministradorEN ();
                #region Cliente
                //Cliente 1
                //MessageBox.Show ("Cago en dios!");
                toni.Email = "tonire@hotmail.com";
                toni.DNI = "48730721h";
                toni.Password = "tonireasdf";
                toni.Nombre = "Toni";
                toni.Apellidos = "Rebollo";
                usuarioCEN.Registrar (toni.Email, toni.DNI, toni.Password, toni.Nombre, toni.Apellidos, DateTime.Today);
                //CLiente 2
                julio.Email = "julio17@hotmail.com";
                julio.DNI = "48730721T";
                julio.Password = "julioasdf";
                julio.Nombre = "Toni";
                julio.Apellidos = "Rebollo";
                usuarioCEN.Registrar (julio.Email, julio.DNI, julio.Password, julio.Nombre, julio.Apellidos, DateTime.Today);
                //Jefe
                jefe.Email = "adri@hotmail.com";
                jefe.DNI = "15145454145N";
                jefe.Password = "123";
                jefe.Nombre = "Toni";
                jefe.Apellidos = "Rebollo";
                superCEN.New_ (jefe.Email, jefe.DNI, jefe.Password, jefe.Nombre, jefe.Apellidos, DateTime.Today);
                UsuarioEN prueba = usuarioCEN.IniciarSesion (jefe.Email, "123");

                Console.WriteLine ("\n\n\n------------------------" + prueba.GetType () + "------------------------");
                MensajeEN mensaje1 = new MensajeEN ();
                mensaje1.Asunto = "Esto es un mensaje de prueba";
                mensaje1.Contenido = "Hola esto es un mensaje para probar que los mensajes se envian.";
                mensajeCEN.CreaMensaje (julio.Email, toni.Email, mensaje1.Asunto, mensaje1.Contenido);
                IList<MensajeEN> listaMensajes = mensajeCEN.GetMensajesByRemitente (julio.Email);

                //Creamos Turnos
                List<TurnoEN> turnos = new List<TurnoEN>();
                TurnoEN turno = new TurnoEN ();
                TurnoEN turno1 = new TurnoEN ();
                TurnoEN turno2 = new TurnoEN ();
                turno.Nombre = "tarde";
                turno.Desde = "15:00";
                turno.Hasta = "19:00";
                turnos.Add (turno);
                turno1.Nombre = "manyana";
                turno1.Desde = "09:00";
                turno1.Hasta = "14:00";
                turnos.Add (turno1);
                turno2.Nombre = "especial";
                turno2.Desde = "20:00";
                turno2.Hasta = "00:00";
                turnos.Add (turno2);

                //Creamos Dias
                List<DiaEN> dias = new List<DiaEN>();
                DiaEN dia = new DiaEN ();

                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.lunes;
                dias.Add (dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.martes;
                dias.Add (dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.miercoles;
                dias.Add (dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.jueves;
                dias.Add (dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.viernes;
                dias.Add (dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.sabado;
                dias.Add (dia);
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.domingo;
                dias.Add (dia);

                //UsuarioEN usuario = new UsuarioEN();
                System.Collections.Generic.List<string> usuarios = new List<string>();
                usuarios.Add ("tonire@hotmail.com");
                usuarios.Add ("julio17@hotmail.com");
                //UsuarioEN us = new UsuarioEN();
                //us=_IUsuarioCAD.GetUsuarioByEmail("julio.el.pro@hotmail.com");

                horarioCEN.CreaHorario ("horario semanal 1", 2015, usuarios, turnos);
                /*UsuarioEN usuario = usuarioCEN.GetUsuarioByEmail("julio.el.pro@hotmail.com");
                 * IList<HorarioEN> horario=usuario.Horario;*/

                IList<UsuarioEN> usu = usuarioCEN.DameTodos (0, 10);
                usu.Add (new UsuarioEN ());
                //MessageBox.Show(horario[0].);
                #endregion
                #region Proovedor
                ProveedorEN proveedor1 = new ProveedorEN ();
                proveedor1.Email = "alibaba@china.com";
                proveedor1.Nombre = "Alibaba GROUP";
                proveedor1.Telefono = "0213-02546-23354";
                proveedorCEN.CrearProveedor (proveedor1.Email, proveedor1.Nombre, proveedor1.Telefono);
                IList<string> proveedores = new List<string>();
                proveedores.Add (proveedor1.Email);
                #endregion

                #region Producto
                ProductoEN producto1 = new ProductoEN ();
                producto1.Referencia = 1;
                producto1.Nombre = "Producto de prueba";
                producto1.Marca = "Marca 1";
                producto1.PrecioCompra = 10;
                producto1.PrecioVenta = 15;
                producto1.Stock = 0;
                productoCEN.CrearProducto (producto1.Referencia, producto1.Nombre, producto1.Marca, producto1.PrecioCompra, producto1.PrecioVenta, producto1.Stock, proveedores);

                LineaPedidoEN lp1 = new LineaPedidoEN ();
                LineaPedidoEN lp2 = new LineaPedidoEN ();
                lp1.Cantidad = 5;
                lp1.Producto = producto1;
                lp2.Cantidad = 2;
                lp2.Producto = producto1;
                IList<LineaPedidoEN> listaLineas = new List<LineaPedidoEN>();
                listaLineas.Add (lp1);
                listaLineas.Add (lp2);
                PedidoEN pedido1 = new PedidoEN ();
                pedido1.Descripcion = "Pedido de prueba";
                pedido1.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido1.FechaRealizacion = DateTime.Today;
                pedido1.FechaConfirmacion = DateTime.Today;
                pedido1.FechaCancelacion = DateTime.Today;

                pedidoCEN.CrearPedido (pedido1.Descripcion, pedido1.Estado, pedido1.FechaRealizacion, julio.Email, listaLineas, pedido1.FechaConfirmacion,pedido1.FechaCancelacion);

                IList<PedidoEN> listaPedidos = pedidoCEN.GetPedidosPendientes ();
                //string Hola = "quetal";
                #endregion

                #region Pedido

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
