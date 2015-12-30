
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using EjemploProyectoCP.CPs;
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
                IAdministradorCAD _IAdministradorCAD = new AdministradorCAD ();
                AdministradorCEN adminCEN = new AdministradorCEN ();
                IEmpleadoCAD _IEmpleadoCAD = new EmpleadoCAD ();
                EmpleadoCEN empleadoCEN = new EmpleadoCEN ();
                IMovimientosCAD _IMovimientosCAD = new MovimientosCAD ();
                MovimientosCEN movimientosCEN = new MovimientosCEN (_IMovimientosCAD);
                ILineaPedidoCAD _ILineaPedido = new LineaPedidoCAD ();
                LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN (_ILineaPedido);
                PedidoCP pedidoCP = new PedidoCP ();
                HorarioCP horarioCP = new HorarioCP ();


                #region Usuario
                /*UsuarioEN toni = new UsuarioEN ();
                 * UsuarioEN julio = new UsuarioEN ();
                 * UsuarioEN hector = new UsuarioEN ();
                 * UsuarioEN adri = new UsuarioEN ();
                 * //Administrador 1
                 * toni.Email = "toniyo@hotmail.com";
                 * toni.DNI = "48730721h";
                 * toni.Password = "1234asdf";
                 * toni.Nombre = "Toni";
                 * toni.Apellidos = "Rebollo";
                 * adminCEN.New_ (toni.Email, toni.DNI, toni.Password, toni.Nombre, toni.Apellidos, DateTime.Now);
                 * toni = usuarioCEN.IniciarSesion (toni.Email, "1234asdf");
                 * //Empleado 1
                 * julio.Email = "julio17@hotmail.com";
                 * julio.DNI = "48730721T";
                 * julio.Password = "julioasdf";
                 * julio.Nombre = "Toni";
                 * julio.Apellidos = "Rebollo";
                 * empleadoCEN.New_ (julio.Email, julio.DNI, julio.Password, julio.Nombre, julio.Apellidos, DateTime.Now);
                 * julio = usuarioCEN.IniciarSesion (julio.Email, "julioasdf");
                 * //Empleado2
                 * //Empleado 1
                 * hector.Email = "hector@hotmail.com";
                 * hector.DNI = "489965421T";
                 * hector.Password = "julioasdf";
                 * hector.Nombre = "Toni";
                 * hector.Apellidos = "Rebollo";
                 * empleadoCEN.New_ (hector.Email, hector.DNI, hector.Password, hector.Nombre, hector.Apellidos, DateTime.Now);
                 * hector = usuarioCEN.IniciarSesion (hector.Email, "julioasdf");
                 * //Jefe
                 * adri.Email = "adri@hotmail.com";
                 * adri.DNI = "15145454145N";
                 * adri.Password = "123";
                 * adri.Nombre = "Toni";
                 * adri.Apellidos = "Rebollo";
                 * superCEN.New_ (adri.Email, adri.DNI, adri.Password, adri.Nombre, adri.Apellidos, DateTime.Now);
                 * adri = usuarioCEN.IniciarSesion (adri.Email, "123");
                 * adri.GetType ();*/
                #endregion

                #region Mensaje
                /*MensajeEN mensaje1 = new MensajeEN ();
                 * mensaje1.Asunto = "Esto es un mensaje de prueba";
                 * mensaje1.Contenido = "Hola esto es un mensaje para probar que los mensajes se envian.";
                 * mensajeCEN.CreaMensaje (julio.Email, toni.Email, mensaje1.Asunto, mensaje1.Contenido, false, DateTime.Now);
                 *
                 * IList<MensajeEN> listaMensajes = mensajeCEN.GetMensajesByRemitente (julio.Email);
                 *
                 * IList<UsuarioEN> usu = usuarioCEN.DameTodos (0, 10);*/
                #endregion


                #region Proovedor
                IList<string> proveedores = new List<string>();
                /**      ProveedorEN proveedor1 = new ProveedorEN ();
                 *    proveedor1.Email = "alibaba@china.com";
                 *    proveedor1.Nombre = "Alibaba GROUP";
                 *    proveedor1.Telefono = "0213-02546-23354";
                 *    proveedorCEN.CrearProveedor (proveedor1.Email, proveedor1.Nombre, proveedor1.Telefono, "Ingeniero Jose Garcia Leon", "Albatera", "Espa�a", "x");
                 *    proveedores.Add (proveedor1.Email);
                 *
                 *    proveedor1 = new ProveedorEN ();
                 *    proveedor1.Email = "lg@ladrones.com";
                 *    proveedor1.Nombre = "LG";
                 *    proveedor1.Telefono = "548946512";
                 *    proveedorCEN.CrearProveedor (proveedor1.Email, proveedor1.Nombre, proveedor1.Telefono, "London", "UK", "UK", "x");
                 *    proveedores.Add (proveedor1.Email);**/
                //1
                proveedorCEN.CrearProveedor ("comunicacion.spain@adidas.com", "Adidas España S.A", "976 710 100", "Avenida María Zambrano", "Zaragoza", "España", "ESA28788909");
                proveedores.Add ("comunicacion.spain@adidas.com");

                //2
                proveedorCEN.CrearProveedor ("proveedor@nike.com", "American Nike, S.L.", "933 793 500", "Avda. Baix Llobregat 5", "El Prat de Llobregat", "España", "ESB59088054");
                proveedores.Add ("proveedor@nike.com");

                //3
                proveedorCEN.CrearProveedor ("j.pinillos@asics.es", "Asics Iberia, S.L.", "902 884 128", "C/ Canudas 9", "El Prat de Llobregat", "España", "ESB60739968");
                proveedores.Add ("j.pinillos@asics.es");

                //4
                proveedorCEN.CrearProveedor ("info-es@puma.com", "Puma Iberia, S.L.", "938 001 100", "Plaza De La Pau", "Cornellà de Llobregat", "España", "ESB85868339");
                proveedores.Add ("info-es@puma.com");

                //5
                proveedorCEN.CrearProveedor ("info@vans.es", "Vans Clothing, S.L.", "925 557 315", "C/ Polio Industrial Las Villas De Yuncos Carlos", "Yuncos", "España", "ESB45569761");
                proveedores.Add ("info@vans.es");

                //6
                proveedorCEN.CrearProveedor ("info@lecoqsportif.com", "Le Coq Sportif España, S.A.", "937 106 027", "C/ Rda Maiols 1", "Sant Quirze del Vallès", "España", "ESA50900513");
                proveedores.Add ("info@lecoqsportif.com");
                #endregion

                #region Producto
                /*  ProductoEN producto1 = new ProductoEN ();
                 * producto1.Referencia = "56489";
                 * producto1.Nombre = "Camiseta XL";
                 * producto1.Marca = "Noke";
                 * producto1.PrecioCompra = 10;
                 * producto1.PrecioVenta = 15;
                 * producto1.Stock = 0;
                 * productoCEN.CrearProducto (producto1.Referencia, producto1.Nombre, producto1.Marca, producto1.PrecioCompra, producto1.PrecioVenta, producto1.Stock, proveedores, 0);
                 * producto1 = new ProductoEN ();
                 * producto1.Referencia = "15468";
                 * producto1.Nombre = "Chandal";
                 * producto1.Marca = "Odidas";
                 * producto1.PrecioCompra = 20;
                 * producto1.PrecioVenta = 30;
                 * producto1.Stock = 0;
                 * productoCEN.CrearProducto (producto1.Referencia, producto1.Nombre, producto1.Marca, producto1.PrecioCompra, producto1.PrecioVenta, producto1.Stock, proveedores, 0);
                 * productoCEN.GetProductosByProveedor ("alibaba@china.com");*/
                //1
                productoCEN.CrearProducto ("O07596", "Tabe 11 JSY Azul", "Adidas", (float)23.55, (float)28.50, 34, proveedores, 0);
                //2
                productoCEN.CrearProducto ("O07598", "Tabe 11 JSY Rojo", "Adidas", (float)23.55, (float)28.50, 12, proveedores, 0);

                //3
                productoCEN.CrearProducto ("O07606", "Tabe 11 JSY Negro", "Adidas", (float)23.55, (float)28.50, 45, proveedores, 0);

                //4
                productoCEN.CrearProducto ("O07611", "Tabe 11 JSY Base Negro", "Adidas", (float)23.55, (float)28.50, 4, proveedores, 0);

                //6
                productoCEN.CrearProducto ("O07612", "Tabe 11 JSY Base Azul", "Adidas", (float)23.55, (float)28.50, 1, proveedores, 0);

                //7
                productoCEN.CrearProducto ("O07585", "Tabe 11 JSY Larga Blanca-Rojo", "Adidas", (float)23.55, (float)28.50, 16, proveedores, 0);

                //8
                productoCEN.CrearProducto ("O07586", "Tabe 11 JSY Larga Negra-Rojo", "Adidas", (float)23.55, (float)28.50, 20, proveedores, 0);

                //9
                productoCEN.CrearProducto ("O07587", "Tabe 11 JSY Larga Blanca-Azul", "Adidas", (float)23.55, (float)28.50, 9, proveedores, 0);

                //10
                productoCEN.CrearProducto ("O07592", "Tabe 11 JSY Larga Negro-Blanco", "Adidas", (float)23.55, (float)28.50, 0, proveedores, 0);

                //11
                productoCEN.CrearProducto ("F50486", "Tabe 14 JSY black/white", "Adidas", (float)26.43, (float)32.50, 5, proveedores, 0);

                //12
                productoCEN.CrearProducto ("F50491", "Tabe 14 JSY bold blue/white", "Adidas", (float)26.43, (float)32.50, 23, proveedores, 0);

                //13
                productoCEN.CrearProducto ("F50490", "Tabe 14 JSY white/red", "Adidas", (float)26.43, (float)32.50, 2, proveedores, 0);

                //14
                productoCEN.CrearProducto ("F50485", "Tabe 14 JSY power red/white", "Adidas", (float)26.43, (float)32.50, 6, proveedores, 0);

                //15
                productoCEN.CrearProducto ("F50487", "Tabe 14 JSY dark blue/white", "Adidas", (float)26.43, (float)32.50, 6, proveedores, 0);

                //16
                productoCEN.CrearProducto ("F50632", "Tabe 14 SHO bold blue/white", "Adidas", (float)26.43, (float)32.50, 44, proveedores, 0);

                //17
                productoCEN.CrearProducto ("F50633", "Tabe 14 SHO dark blue/white", "Adidas", (float)26.43, (float)32.50, 21, proveedores, 0);

                //18
                productoCEN.CrearProducto ("F50631", "Tabe 14 JSY power red/white", "Adidas", (float)26.43, (float)32.50, 16, proveedores, 0);

                //19
                productoCEN.CrearProducto ("F50636", "Tabe 14 JSY white/red", "Adidas", (float)26.43, (float)32.50, 6, proveedores, 0);

                //20
                productoCEN.CrearProducto ("Z73940", "Adidas Team 13 Jersey White/Black", "Adidas", (float)21.23, (float)26.52, 8, proveedores, 0);

                //21
                productoCEN.CrearProducto ("Z73944", "Adidas Team 13 Jersey White/ Cobalt", "Adidas", (float)21.23, (float)26.52, 0, proveedores, 0);

                //22
                productoCEN.CrearProducto ("132974", "Luge Training", "Adidas", (float)33.54, (float)36.73, 6, proveedores, 0);

                //23
                productoCEN.CrearProducto ("F38433", "VLHOOPS MID", "Adidas", (float)45.23, (float)57.23, 26, proveedores, 0);

                //24
                productoCEN.CrearProducto ("G65302", "adizero F50 TRX FG", "Adidas", (float)39.82, (float)42.34, 31, proveedores, 0);

                //25
                productoCEN.CrearProducto ("M29605", "adizero counterblas", "Adidas", (float)52.12, (float)57.24, 19, proveedores, 0);

                //26
                productoCEN.CrearProducto ("D73809", "SEELEY", "Adidas", (float)44.15, (float)48.33, 12, proveedores, 0);

                //27
                productoCEN.CrearProducto ("Q33931", "F5 TRX TF", "Adidas", (float)39.56, (float)42.14, 32, proveedores, 0);

                //28
                productoCEN.CrearProducto ("G65442", "F5 TRX HG J", "Adidas", (float)45.29, (float)51.23, 11, proveedores, 0);

                //29
                productoCEN.CrearProducto ("M29916", "Nitrocharge 3.0 HG", "Adidas", (float)74.93, (float)78.34, 10, proveedores, 0);

                //30
                productoCEN.CrearProducto ("C75631", "SEELEY BOAT", "Adidas", (float)65.12, (float)72.54, 3, proveedores, 0);

                //31
                productoCEN.CrearProducto ("Q23904", "11Nova TRX FG", "Adidas", (float)64.75, (float)67.43, 15, proveedores, 0);

                //32
                productoCEN.CrearProducto ("D67836", "ZX SANDAL W", "Adidas", (float)65.48, (float)73.51, 4, proveedores, 0);

                //33
                productoCEN.CrearProducto ("Q21663", "Predator LZ TRX FG", "Adidas", (float)58.38, (float)65.43, 7, proveedores, 0);

                //3
                productoCEN.CrearProducto ("Q23914", "11Questra IN J", "Adidas", (float)68.32, (float)73.54, 16, proveedores, 0);

                //35
                productoCEN.CrearProducto ("Q33811", "P Absolado LZ SG", "Adidas", (float)56.23, (float)63.86, 19, proveedores, 0);

                //36
                productoCEN.CrearProducto ("G65202", "F10 TRX AG", "Adidas", (float)66.43, (float)75.54, 27, proveedores, 0);

                //37
                productoCEN.CrearProducto ("D73804", "VARIAL MID J", "Adidas", (float)53.71, (float)63.21, 12, proveedores, 0);

                //38
                productoCEN.CrearProducto ("D67233", "BASKETPRO OCTO I", "Adidas", (float)74.54, (float)76.41, 9, proveedores, 0);

                //39
                productoCEN.CrearProducto ("Q23885", "P Absolion LZ TRX A", "Adidas", (float)64.32, (float)67.31, 0, proveedores, 0);

                //40
                productoCEN.CrearProducto ("G98180", "SEELEY", "Adidas", (float)48.56, (float)54.26, 5, proveedores, 0);

                //41
                productoCEN.CrearProducto ("L44750", "F50 adizero TRX FG", "Adidas", (float)64.18, (float)67.51, 6, proveedores, 0);

                //42
                productoCEN.CrearProducto ("D67002", "F10 TRX AG J", "Adidas", (float)85.83, (float)92.33, 32, proveedores, 0);

                //43
                productoCEN.CrearProducto ("Q33865", "F10 TRX AG", "Adidas", (float)68.43, (float)74.15, 20, proveedores, 0);

                //44
                productoCEN.CrearProducto ("Q23887", "Predito LZ TRX HG J", "Adidas", (float)58.39, (float)67.24, 21, proveedores, 0);

                //45
                productoCEN.CrearProducto ("Q33691", "nitrocharge 3.0 TRX", "Adidas", (float)61.52, (float)73.67, 2, proveedores, 0);

                //46
                productoCEN.CrearProducto ("G65380", "F30 TRX AG", "Adidas", (float)63.45, (float)74.81, 1, proveedores, 0);

                //47
                productoCEN.CrearProducto ("G65578", "ARTILLERY AS LOW", "Adidas", (float)45.37, (float)53.21, 6, proveedores, 0);

                //48
                productoCEN.CrearProducto ("M20162", "Predito Instinct FG", "Adidas", (float)37.62, (float)47.51, 49, proveedores, 0);

                //49
                productoCEN.CrearProducto ("D67175", "adizero HJ ST", "Adidas", (float)84.56, (float)102.34, 38, proveedores, 0);

                //50
                productoCEN.CrearProducto ("Q21672", "Predito LZ TRX TF", "Adidas", (float)66.27, (float)73.51, 32, proveedores, 0);

                //51
                productoCEN.CrearProducto ("CV-113823-AS5B", "STAR PLAYER EV MILK/ATHLETIC NAVY OX", "Converse", (float)53.84, (float)62.18, 38, proveedores, 0);

                //52
                productoCEN.CrearProducto ("CV-117381-AS1", "ALL STAR SPECIALTY DEEP FOREST HI", "Converse", (float)67.59, (float)73.33, 23, proveedores, 0);

                //53
                productoCEN.CrearProducto ("CV-CBGBP902-BK", "WALLET", "Converse", (float)72.90, (float)83.61, 6, proveedores, 0);

                //54
                productoCEN.CrearProducto ("CV-CKQ3107-MNT", "T-SHIRT V-NECK", "Converse", (float)90.61, (float)106.31, 8, proveedores, 0);

                //55
                productoCEN.CrearProducto ("CV-CKQ3203-BR", "POLO", "Converse", (float)58.49, (float)66.31, 11, proveedores, 0);

                //56
                productoCEN.CrearProducto ("CV-CKQ3214-PPL", "T-SHIRT CREW S/S", "Converse", (float)46.87, (float)53.21, 6, proveedores, 0);

                //57
                productoCEN.CrearProducto ("CV-CKQ9205-BK", "JACKET", "Converse", (float)66.98, (float)73.61, 6, proveedores, 0);

                //58
                productoCEN.CrearProducto ("CV-CSCR205-BK", "BUFANDA", "Converse", (float)63.25, (float)73.61, 4, proveedores, 0);

                //59
                productoCEN.CrearProducto ("CV-CWR5511-BK", "LEGGINS", "Converse", (float)57.35, (float)64.31, 22, proveedores, 0);

                //60
                productoCEN.CrearProducto ("CV-7J236-I1", "ALL STAR CORE RED OX", "Converse", (float)68.34, (float)76.41, 23, proveedores, 0);

                //61
                productoCEN.CrearProducto ("CV-532466C-D1", "LADY ALL STAR BLACK OX", "Converse", (float)77.37, (float)85.71, 6, proveedores, 0);

                //62
                productoCEN.CrearProducto ("CV-CS104-MIL", "CAP", "Converse", (float)67.89, (float)73.41, 8, proveedores, 0);

                //63
                productoCEN.CrearProducto ("CV-CWR3616-CLM", "FASHION LOGO TOP", "Converse", (float)59.05, (float)64.61, 12, proveedores, 0);

                //64
                productoCEN.CrearProducto ("CV-CWR2609-PP", "SOLID LONG SLEEVE", "Converse", (float)83.68, (float)97.34, 17, proveedores, 0);

                //65
                productoCEN.CrearProducto ("CV-CWQ3206-VLT", "BOAT WHIT ROLL UP SLEEVE", "Converse", (float)68.25, (float)80.21, 3, proveedores, 0);

                //66
                productoCEN.CrearProducto ("119066-9985", "NIKE Da.Hoody", "Nike", (float)71.43, (float)83.21, 8, proveedores, 0);

                //67
                productoCEN.CrearProducto ("119143-7185", "NIKE NOS YA76 BF FZ Hoody", "Nike", (float)52.44, (float)61.52, 9, proveedores, 0);

                //68
                productoCEN.CrearProducto ("119144-7185", "NIKE NOS N45 BF Cuf Pant", "Nike", (float)49.62, (float)54.21, 19, proveedores, 0);

                //69
                productoCEN.CrearProducto ("119148-9000", "NIKE NOS SS Solid Swoosh V Neck Tee", "Nike", (float)74.52, (float)82.51, 31, proveedores, 0);

                //70
                productoCEN.CrearProducto ("119150-9500", "NIKE NOS Legend Slim Poly Pant", "Nike", (float)57.72, (float)64.91, 37, proveedores, 0);

                //71
                productoCEN.CrearProducto ("119151-9500", "NIKE NOS Jersey Cuffed Capri", "Nike", (float)34.12, (float)44.31, 13, proveedores, 0);

                //72
                productoCEN.CrearProducto ("119153-9000", "NIKE NOS Definition Bra", "Nike", (float)83.23, (float)97.51, 6, proveedores, 0);

                //73
                productoCEN.CrearProducto ("119153-9501", "NIKE NOS Definition Bra", "Nike", (float)44.98, (float)52.14, 4, proveedores, 0);

                //74
                productoCEN.CrearProducto ("119154-7185", "NIKE NOS Wmns Jersey Short", "Nike", (float)66.26, (float)73.21, 23, proveedores, 0);

                //75
                productoCEN.CrearProducto ("119154-9501", "NIKE NOS Wmns Jersey Short", "Nike", (float)47.83, (float)54.38, 5, proveedores, 0);

                //76
                productoCEN.CrearProducto ("119155-9500", "NIKE NOS Regular DF Cotton Capri", "Nike", (float)56.23, (float)63.74, 9, proveedores, 0);

                //77
                productoCEN.CrearProducto ("119156-9500", "NIKE NOS Regular DF Cotton Pant", "Nike", (float)61.94, (float)76.52, 18, proveedores, 0);

                //78
                productoCEN.CrearProducto ("119157-9000", "NIKE NOS Core Compression SL Top", "Nike", (float)71.95, (float)83.53, 12, proveedores, 0);

                //79
                productoCEN.CrearProducto ("119157-9500", "NIKE NOS Core Compression SL Top", "Nike", (float)67.83, (float)83.41, 16, proveedores, 0);

                //80
                productoCEN.CrearProducto ("119159-9500", "NIKE NOS Core Compression 6 Short", "Nike", (float)63.32, (float)75.32, 28, proveedores, 0);

                //81
                productoCEN.CrearProducto ("119160-7185", "NIKE NOS Squad Fleece Cuffed Pant", "Nike", (float)69.64, (float)82.14, 9, proveedores, 0);

                //82
                productoCEN.CrearProducto ("119160-9501", "NIKE NOS Squad Fleece Cuffed Pant", "Nike", (float)57.62, (float)76.43, 16, proveedores, 0);

                //83
                productoCEN.CrearProducto ("119161-9501", "NIKE NOS Squad Fleece FZ Hoody", "Nike", (float)61.58, (float)69.24, 1, proveedores, 0);

                //84
                productoCEN.CrearProducto ("119213-5162", "NIKE NOS AD Basic Woven Short", "Nike", (float)48.26, (float)55.72, 3, proveedores, 0);

                //85
                productoCEN.CrearProducto ("119214-5162", "NIKE NOS AD Basic Woven Med Short", "Nike", (float)52.33, (float)74.92, 18, proveedores, 0);

                //86
                productoCEN.CrearProducto ("119215-5162", "NIKE NOS AD Essential Cuffed Pant", "Nike", (float)58.73, (float)66.72, 24, proveedores, 0);

                //87
                productoCEN.CrearProducto ("119217-9500", "NIKE NOS Nike Fly Short", "Nike", (float)73.52, (float)82.42, 16, proveedores, 0);

                //88
                productoCEN.CrearProducto ("119218-3000", "NIKE NOS DFCT Version 2.", "Nike", (float)64.43, (float)73.82, 15, proveedores, 0);

                //89
                productoCEN.CrearProducto ("119221-7185", "NIKE NOS AD Jersey Medium", "Nike", (float)67.51, (float)76.13, 55, proveedores, 0);

                //90
                productoCEN.CrearProducto ("119221-9501", "NIKE NOS AD Jersey Medium", "Nike", (float)59.30, (float)68.45, 3, proveedores, 0);

                //91
                productoCEN.CrearProducto ("120514-5015", "Graphic He.Woven Short", "Nike", (float)33.56, (float)53.61, 2, proveedores, 0);

                //92
                productoCEN.CrearProducto ("120517-5036", "Rib Tank Stripe Da. Top", "Nike", (float)41.65, (float)53.15, 14, proveedores, 0);

                //93
                productoCEN.CrearProducto ("120518-7012", "Nike Campus Knit Set", "Nike", (float)63.25, (float)74.41, 19, proveedores, 0);

                //94
                productoCEN.CrearProducto ("120539-9020", "DFCT He.T-Shirt", "Nike", (float)25.41, (float)36.31, 13, proveedores, 0);

                //95
                productoCEN.CrearProducto ("120547-9000", "Basketball JDI Ki.T-Shirt", "Nike", (float)58.53, (float)63.29, 9, proveedores, 0);

                //96
                productoCEN.CrearProducto ("120859-5000", "NIKE NOS Waffle Swoosh SS Tee", "Nike", (float)53.26, (float)72.93, 9, proveedores, 0);

                //97
                productoCEN.CrearProducto ("120860-9500", "NIKE NOS Legend SS Top", "Nike", (float)26.52, (float)33.24, 16, proveedores, 0);

                //98
                productoCEN.CrearProducto ("120861-7185", "NIKE NOS Jersey Cuffed Capri", "Nike", (float)57.45, (float)62.61, 13, proveedores, 0);

                //99
                productoCEN.CrearProducto ("120862-9500", "NIKE NOS Speed Legend SS Top 2.", "Nike", (float)68.15, (float)73.86, 14, proveedores, 0);

                //100
                productoCEN.CrearProducto ("122142-5000", "CLASIC FLEECE FZ Da.Hoody", "Nike", (float)31.56, (float)43.83, 1, proveedores, 0);

                //101
                productoCEN.CrearProducto ("122240-9000", "NIKE RUBY CREW Da.Shirt", "Nike", (float)46.75, (float)59.09, 13, proveedores, 0);

                //102
                productoCEN.CrearProducto ("122241-5004", "CLASSIC FLEECE FZ JDI He.Hoody", "Nike", (float)63.51, (float)69.52, 18, proveedores, 0);

                //103
                productoCEN.CrearProducto ("122242-7006", "SWOOSH FILL He.Shirt", "Nike", (float)73.51, (float)83.60, 23, proveedores, 0);

                //104
                productoCEN.CrearProducto ("122243-5005", "CLASSIC FRESHER PANT He.Hose", "Nike", (float)82.61, (float)95.37, 6, proveedores, 0);
                #endregion

                #region LineasPedido
                /* LineaPedidoEN lp1 = new LineaPedidoEN ();
                 * LineaPedidoEN lp2 = new LineaPedidoEN ();
                 * lp1.Cantidad = 5;
                 * lp1.Producto = producto1;
                 * lp2.Cantidad = 2;
                 * lp2.Producto = productoCEN.GetProducto ("56489");
                 * IList<LineaPedidoEN> listaLineas = new List<LineaPedidoEN>();
                 * listaLineas.Add (lp1);
                 * listaLineas.Add (lp2);*/
                #endregion

                #region Pedido
                /*PedidoEN pedido1 = new PedidoEN ();
                 * pedido1.Descripcion = "Pedido de prueba";
                 * pedido1.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                 * pedido1.FechaRealizacion = DateTime.Now;
                 * int pedido = pedidoCEN.CrearPedido (pedido1.Descripcion, pedido1.Estado, pedido1.FechaRealizacion, julio.Email, listaLineas);
                 *
                 * IList<PedidoEN> listaPedidos = pedidoCEN.GetPedidosPendientes ();
                 *
                 * pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (pedido, DateTime.Now);
                 *
                 * IList<LineaPedidoEN> lineasPrueba = lineaPedidoCEN.GetLineasPedidoByPedido (pedido);
                 *
                 *
                 * PedidoEN pedido2 = new PedidoEN ();
                 * pedido2.Descripcion = "Pedido dos";
                 * pedido2.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                 * pedido2.FechaRealizacion = DateTime.Now;
                 *
                 * int oidPedido2 = pedidoCEN.CrearPedido (pedido2.Descripcion, pedido2.Estado, pedido2.FechaRealizacion, toni.Email, listaLineas);
                 * pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (oidPedido2, DateTime.Now);
                 *
                 * double totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);
                 *
                 * pedidoCEN.Destroy (pedidoCEN.GetPedidosConfirmados () [1].Id);*/

                #endregion

                #region Turnos
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
                #endregion

                #region Dias
                //Creamos Dias
                List<DiaEN> dias = new List<DiaEN>();
                DiaEN dia = new DiaEN ();
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.lunes;
                dia.Turno = turno1;
                dias.Add (dia);
                dia = new DiaEN ();
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.martes;
                dia.Turno = turno;
                dias.Add (dia);
                dia = new DiaEN ();
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.miercoles;
                dia.Turno = turno1;
                dias.Add (dia);
                dia = new DiaEN ();
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.jueves;
                dia.Turno = turno;
                dias.Add (dia);
                dia = new DiaEN ();
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.viernes;
                dia.Turno = turno1;
                dias.Add (dia);
                dia = new DiaEN ();
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.sabado;
                dia.Turno = turno;
                dias.Add (dia);
                dia = new DiaEN ();
                dia.Dia = IManagerGenNHibernate.Enumerated.IManager.DiasSemanaEnum.domingo;
                dia.Turno = turno2;
                dias.Add (dia);
                #endregion region

                #region Horario
                /*HorarioEN horario = new HorarioEN ();
                 * horario.Titulo = "Horario semanal";
                 * horario.Anyo = 2015;
                 *
                 * System.Collections.Generic.List<string> usuarios = new List<string>();
                 * usuarios.Add ("toniyo@hotmail.com");
                 * usuarios.Add ("julio17@hotmail.com");
                 *
                 * string horario_oid = horarioCP.CrearHorario (horario, usuarios, turnos, dias);
                 * horarioCP.borrarHorario (horario_oid);*/
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
