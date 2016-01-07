
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
             //   IProductoCAD _IProductoCAD = new ProductoCAD ();
                   ProductoCEN productoCEN = new ProductoCEN ();
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

                PedidoCP pedidoCP = new PedidoCP ();
                VentaCP ventaCP = new VentaCP ();
                HorarioCP horarioCP = new HorarioCP ();


                #region Usuario
                UsuarioEN toni = new UsuarioEN ();
                UsuarioEN julio = new UsuarioEN ();
                UsuarioEN hector = new UsuarioEN ();
                UsuarioEN adri = new UsuarioEN ();
                //Administrador 1
                toni.Email = "toniyo@hotmail.com";
                toni.DNI = "48730721h";
                toni.Password = "1234asdf";
                toni.Nombre = "Toni";
                toni.Apellidos = "Rebollo";
                adminCEN.New_ (toni.Email, toni.DNI, toni.Password, toni.Nombre, toni.Apellidos, DateTime.Now);
                toni = usuarioCEN.IniciarSesion (toni.Email, "1234asdf");
                /** //Empleado 1
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
                proveedorCEN.CrearProveedor("proveedor@nike.com", "American Nike, S.L.", "933 793 500", "120 9th Street S.W. Clarion", "Iowa", "EEUU", "ESB59088054");
                proveedores.Add("proveedor@nike.com");

                //3
                proveedorCEN.CrearProveedor ("j.pinillos@asics.es", "Asics Iberia, S.L.", "902 884 128", "C/ Canudas 9", "El Prat de Llobregat", "España", "ESB60739968");
                proveedores.Add ("j.pinillos@asics.es");

                //4

                proveedorCEN.CrearProveedor("info-es@puma.com", "Puma Iberia, S.L.", "938 001 100", "Talange Hauconcourt", "Talange", "France", "ESB85868339");
                proveedores.Add("info-es@puma.com");


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

                //LineaPedido1
                LineaPedidoEN lp1 = new LineaPedidoEN ();
                lp1.Cantidad = 22;
                lp1.Producto = productoCEN.GetProducto ("O07592");
                LineaPedidoEN lp2 = new LineaPedidoEN ();
                lp2.Cantidad = 16;
                lp2.Producto = productoCEN.GetProducto ("Q23885");
                LineaPedidoEN lp3 = new LineaPedidoEN ();
                lp3.Cantidad = 7;
                lp3.Producto = productoCEN.GetProducto ("G65380");
                LineaPedidoEN lp4 = new LineaPedidoEN ();
                lp4.Cantidad = 7;
                lp4.Producto = productoCEN.GetProducto ("Q33691");
                IList<LineaPedidoEN> Pedido01_1 = new List<LineaPedidoEN>();
                Pedido01_1.Add (lp1);
                Pedido01_1.Add (lp2);
                Pedido01_1.Add (lp3);
                Pedido01_1.Add (lp4);

                //LineaPedido2
                LineaPedidoEN lp5 = new LineaPedidoEN ();
                lp5.Cantidad = 3;
                lp5.Producto = productoCEN.GetProducto ("O07587");
                LineaPedidoEN lp6 = new LineaPedidoEN ();
                lp6.Cantidad = 18;
                lp6.Producto = productoCEN.GetProducto ("D73804");
                LineaPedidoEN lp7 = new LineaPedidoEN ();
                lp7.Cantidad = 2;
                lp7.Producto = productoCEN.GetProducto ("CV-117381-AS1");
                LineaPedidoEN lp8 = new LineaPedidoEN ();
                lp8.Cantidad = 5;
                lp8.Producto = productoCEN.GetProducto ("G65442");
                LineaPedidoEN lp9 = new LineaPedidoEN ();
                lp9.Cantidad = 2;
                lp9.Producto = productoCEN.GetProducto ("132974");
                LineaPedidoEN lp10 = new LineaPedidoEN ();
                lp10.Cantidad = 4;
                lp10.Producto = productoCEN.GetProducto ("L44750");
                LineaPedidoEN lp11 = new LineaPedidoEN ();
                lp11.Cantidad = 2;
                lp11.Producto = productoCEN.GetProducto ("119213-5162");
                LineaPedidoEN lp12 = new LineaPedidoEN ();
                lp12.Cantidad = 6;
                lp12.Producto = productoCEN.GetProducto ("O07611");
                LineaPedidoEN lp13 = new LineaPedidoEN ();
                lp13.Cantidad = 5;
                lp13.Producto = productoCEN.GetProducto ("F50486");
                LineaPedidoEN lp14 = new LineaPedidoEN ();
                lp14.Cantidad = 3;
                lp14.Producto = productoCEN.GetProducto ("CV-CKQ9205-BK");

                IList<LineaPedidoEN> Pedido02_1 = new List<LineaPedidoEN>();
                Pedido02_1.Add (lp5);
                Pedido02_1.Add (lp6);
                Pedido02_1.Add (lp7);
                Pedido02_1.Add (lp8);
                Pedido02_1.Add (lp9);
                Pedido02_1.Add (lp10);
                Pedido02_1.Add (lp11);
                Pedido02_1.Add (lp12);
                Pedido02_1.Add (lp13);
                Pedido02_1.Add (lp14);


                //LineaPedido3
                LineaPedidoEN lp15 = new LineaPedidoEN ();
                lp15.Cantidad = 3;
                lp15.Producto = productoCEN.GetProducto ("Q23904");
                LineaPedidoEN lp16 = new LineaPedidoEN ();
                lp16.Cantidad = 4;
                lp16.Producto = productoCEN.GetProducto ("D67175");
                LineaPedidoEN lp17 = new LineaPedidoEN ();
                lp17.Cantidad = 5;
                lp17.Producto = productoCEN.GetProducto ("Q33865");
                LineaPedidoEN lp18 = new LineaPedidoEN ();
                lp18.Cantidad = 2;
                lp18.Producto = productoCEN.GetProducto ("Z73940");
                IList<LineaPedidoEN> Pedido03_1 = new List<LineaPedidoEN>();
                Pedido03_1.Add (lp15);
                Pedido03_1.Add (lp16);
                Pedido03_1.Add (lp17);
                Pedido03_1.Add (lp18);


                //LineaPedido4
                LineaPedidoEN lp19 = new LineaPedidoEN ();
                lp19.Cantidad = 9;
                lp19.Producto = productoCEN.GetProducto ("Q21672");
                LineaPedidoEN lp20 = new LineaPedidoEN ();
                lp20.Cantidad = 18;
                lp20.Producto = productoCEN.GetProducto ("CV-532466C-D1");
                LineaPedidoEN lp21 = new LineaPedidoEN ();
                lp21.Cantidad = 3;
                lp21.Producto = productoCEN.GetProducto ("119148-9000");


                IList<LineaPedidoEN> Pedido04_1 = new List<LineaPedidoEN>();
                Pedido04_1.Add (lp19);
                Pedido04_1.Add (lp20);
                Pedido04_1.Add (lp21);


                //LineaPedido5
                LineaPedidoEN lp22 = new LineaPedidoEN ();
                lp22.Cantidad = 12;
                lp22.Producto = productoCEN.GetProducto ("Z73944");
                LineaPedidoEN lp23 = new LineaPedidoEN ();
                lp23.Cantidad = 8;
                lp23.Producto = productoCEN.GetProducto ("119161-9501");
                LineaPedidoEN lp24 = new LineaPedidoEN ();
                lp24.Cantidad = 2;
                lp24.Producto = productoCEN.GetProducto ("F50490");
                LineaPedidoEN lp25 = new LineaPedidoEN ();
                lp25.Cantidad = 9;
                lp25.Producto = productoCEN.GetProducto ("119153-9501");
                LineaPedidoEN lp26 = new LineaPedidoEN ();
                lp26.Cantidad = 2;
                lp26.Producto = productoCEN.GetProducto ("D67233");
                LineaPedidoEN lp27 = new LineaPedidoEN ();
                lp27.Cantidad = 8;
                lp27.Producto = productoCEN.GetProducto ("L44750");
                LineaPedidoEN lp28 = new LineaPedidoEN ();
                lp28.Cantidad = 5;
                lp28.Producto = productoCEN.GetProducto ("122243-5005");
                LineaPedidoEN lp29 = new LineaPedidoEN ();
                lp29.Cantidad = 3;
                lp29.Producto = productoCEN.GetProducto ("F50485");
                LineaPedidoEN lp30 = new LineaPedidoEN ();
                lp30.Cantidad = 10;
                lp30.Producto = productoCEN.GetProducto ("O07598");

                IList<LineaPedidoEN> Pedido05_1 = new List<LineaPedidoEN>();
                Pedido05_1.Add (lp22);
                Pedido05_1.Add (lp23);
                Pedido05_1.Add (lp24);
                Pedido05_1.Add (lp25);
                Pedido05_1.Add (lp26);
                Pedido05_1.Add (lp27);
                Pedido05_1.Add (lp28);
                Pedido05_1.Add (lp29);


                //LineaPedido6
                LineaPedidoEN lp31 = new LineaPedidoEN ();
                lp31.Cantidad = 8;
                lp31.Producto = productoCEN.GetProducto ("120517-5036");
                LineaPedidoEN lp32 = new LineaPedidoEN ();
                lp32.Cantidad = 1;
                lp32.Producto = productoCEN.GetProducto ("CV-CWR2609-PP");
                LineaPedidoEN lp33 = new LineaPedidoEN ();
                lp33.Cantidad = 3;
                lp33.Producto = productoCEN.GetProducto ("Q23885");
                LineaPedidoEN lp34 = new LineaPedidoEN ();
                lp34.Cantidad = 6;
                lp34.Producto = productoCEN.GetProducto ("122142-5000");
                LineaPedidoEN lp35 = new LineaPedidoEN ();
                lp35.Cantidad = 6;
                lp35.Producto = productoCEN.GetProducto ("CV-CWQ3206-VLT");
                LineaPedidoEN lp36 = new LineaPedidoEN ();
                lp36.Cantidad = 7;
                lp36.Producto = productoCEN.GetProducto ("119213-5162");
                IList<LineaPedidoEN> Pedido06_1 = new List<LineaPedidoEN>();
                Pedido06_1.Add (lp31);
                Pedido06_1.Add (lp32);
                Pedido06_1.Add (lp33);
                Pedido06_1.Add (lp34);
                Pedido06_1.Add (lp35);
                Pedido06_1.Add (lp36);

                //LineaPedido7
                LineaPedidoEN lp37 = new LineaPedidoEN ();
                lp37.Cantidad = 4;
                lp37.Producto = productoCEN.GetProducto ("O07612");
                LineaPedidoEN lp38 = new LineaPedidoEN ();
                lp38.Cantidad = 8;
                lp38.Producto = productoCEN.GetProducto ("120514-5015");
                LineaPedidoEN lp39 = new LineaPedidoEN ();
                lp39.Cantidad = 8;
                lp39.Producto = productoCEN.GetProducto ("Q23885");
                LineaPedidoEN lp40 = new LineaPedidoEN ();
                lp40.Cantidad = 3;
                lp40.Producto = productoCEN.GetProducto ("122142-5000");
                LineaPedidoEN lp41 = new LineaPedidoEN ();
                lp41.Cantidad = 8;
                lp41.Producto = productoCEN.GetProducto ("120514-5015");

                IList<LineaPedidoEN> Pedido07_1 = new List<LineaPedidoEN>();
                Pedido07_1.Add (lp31);
                Pedido07_1.Add (lp32);
                Pedido07_1.Add (lp33);
                Pedido07_1.Add (lp34);
                Pedido07_1.Add (lp35);



                //LineaPedido8
                LineaPedidoEN lp42 = new LineaPedidoEN ();
                lp42.Cantidad = 4;
                lp42.Producto = productoCEN.GetProducto ("O07612");
                LineaPedidoEN lp43 = new LineaPedidoEN ();
                lp43.Cantidad = 1;
                lp43.Producto = productoCEN.GetProducto ("120514-5015");
                LineaPedidoEN lp44 = new LineaPedidoEN ();
                lp44.Cantidad = 2;
                lp44.Producto = productoCEN.GetProducto ("F50490");
                LineaPedidoEN lp45 = new LineaPedidoEN ();
                lp45.Cantidad = 3;
                lp45.Producto = productoCEN.GetProducto ("119153-9000");
                LineaPedidoEN lp46 = new LineaPedidoEN ();
                lp46.Cantidad = 4;
                lp46.Producto = productoCEN.GetProducto ("F50490");

                IList<LineaPedidoEN> Pedido08_1 = new List<LineaPedidoEN>();
                Pedido08_1.Add (lp42);
                Pedido08_1.Add (lp43);
                Pedido08_1.Add (lp44);
                Pedido08_1.Add (lp45);
                Pedido08_1.Add (lp46);

                //LineaPedido9
                LineaPedidoEN lp47 = new LineaPedidoEN ();
                lp47.Cantidad = 9;
                lp47.Producto = productoCEN.GetProducto ("O07612");
                LineaPedidoEN lp48 = new LineaPedidoEN ();
                lp48.Cantidad = 12;
                lp48.Producto = productoCEN.GetProducto ("120514-5015");


                IList<LineaPedidoEN> Pedido09_1 = new List<LineaPedidoEN>();
                Pedido09_1.Add (lp47);
                Pedido09_1.Add (lp48);


                //LineaPedido10
                LineaPedidoEN lp49 = new LineaPedidoEN ();
                lp49.Cantidad = 4;
                lp49.Producto = productoCEN.GetProducto ("D67836");
                LineaPedidoEN lp50 = new LineaPedidoEN ();
                lp50.Cantidad = 5;
                lp50.Producto = productoCEN.GetProducto ("F50636");
                LineaPedidoEN lp51 = new LineaPedidoEN ();
                lp51.Cantidad = 2;
                lp51.Producto = productoCEN.GetProducto ("CV-CKQ3107-MNT");
                LineaPedidoEN lp52 = new LineaPedidoEN ();
                lp52.Cantidad = 8;
                lp52.Producto = productoCEN.GetProducto ("CV-CS104-MIL");


                IList<LineaPedidoEN> Pedido10_1 = new List<LineaPedidoEN>();
                Pedido10_1.Add (lp49);
                Pedido10_1.Add (lp50);
                Pedido10_1.Add (lp51);
                Pedido10_1.Add (lp52);


                //LineaPedido11
                LineaPedidoEN lp53 = new LineaPedidoEN ();
                lp53.Cantidad = 8;
                lp53.Producto = productoCEN.GetProducto ("CV-CKQ3214-PPL");
                LineaPedidoEN lp54 = new LineaPedidoEN ();
                lp54.Cantidad = 15;
                lp54.Producto = productoCEN.GetProducto ("120547-9000");
                LineaPedidoEN lp55 = new LineaPedidoEN ();
                lp55.Cantidad = 8;
                lp55.Producto = productoCEN.GetProducto ("Q33691");
                LineaPedidoEN lp56 = new LineaPedidoEN ();
                lp56.Cantidad = 4;
                lp56.Producto = productoCEN.GetProducto ("119155-9500");
                LineaPedidoEN lp57 = new LineaPedidoEN ();
                lp57.Cantidad = 10;
                lp57.Producto = productoCEN.GetProducto ("CV-CKQ3214-PPL");
                LineaPedidoEN lp58 = new LineaPedidoEN ();
                lp58.Cantidad = 3;
                lp58.Producto = productoCEN.GetProducto ("120539-9020");
                LineaPedidoEN lp59 = new LineaPedidoEN ();
                lp59.Cantidad = 6;
                lp59.Producto = productoCEN.GetProducto ("120862-9500");
                LineaPedidoEN lp60 = new LineaPedidoEN ();
                lp60.Cantidad = 16;
                lp60.Producto = productoCEN.GetProducto ("Z73944");


                IList<LineaPedidoEN> Pedido11_1 = new List<LineaPedidoEN>();
                Pedido11_1.Add (lp53);
                Pedido11_1.Add (lp54);
                Pedido11_1.Add (lp55);
                Pedido11_1.Add (lp56);
                Pedido11_1.Add (lp57);
                Pedido11_1.Add (lp58);
                Pedido11_1.Add (lp59);
                Pedido11_1.Add (lp60);

                //LineaPedido12
                LineaPedidoEN lp61 = new LineaPedidoEN ();
                lp61.Cantidad = 3;
                lp61.Producto = productoCEN.GetProducto ("G65202");
                LineaPedidoEN lp62 = new LineaPedidoEN ();
                lp62.Cantidad = 6;
                lp62.Producto = productoCEN.GetProducto ("CV-532466C-D1");
                LineaPedidoEN lp63 = new LineaPedidoEN ();
                lp63.Cantidad = 3;
                lp63.Producto = productoCEN.GetProducto ("D67002");
                LineaPedidoEN lp64 = new LineaPedidoEN ();
                lp64.Cantidad = 4;
                lp64.Producto = productoCEN.GetProducto ("G65302");
                LineaPedidoEN lp65 = new LineaPedidoEN ();
                lp65.Cantidad = 7;
                lp65.Producto = productoCEN.GetProducto ("M29605");
                LineaPedidoEN lp66 = new LineaPedidoEN ();
                lp66.Cantidad = 4;
                lp66.Producto = productoCEN.GetProducto ("O07586");



                IList<LineaPedidoEN> Pedido12_1 = new List<LineaPedidoEN>();
                Pedido12_1.Add (lp53);
                Pedido12_1.Add (lp54);
                Pedido12_1.Add (lp55);
                Pedido12_1.Add (lp56);
                Pedido12_1.Add (lp57);
                Pedido12_1.Add (lp58);
                Pedido12_1.Add (lp59);
                Pedido12_1.Add (lp60);

                #endregion

                #region Pedido

                //Pedido1
                PedidoEN pedido1 = new PedidoEN ();
                pedido1.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido1.FechaRealizacion = DateTime.Parse("01/05/2015 10:12:30",System.Globalization.CultureInfo.InvariantCulture);
                int pedido = pedidoCEN.CrearPedido(pedido1.Estado, pedido1.FechaRealizacion, toni.Email, Pedido01_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento(pedido, DateTime.Parse("01/07/2015 12:50:12",System.Globalization.CultureInfo.InvariantCulture));
                double totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo(2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);

                PedidoEN pedido1x = new PedidoEN();
                pedido1x.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido1x.FechaRealizacion = DateTime.Parse("01/15/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture);
                int pedidox = pedidoCEN.CrearPedido(pedido1x.Estado, pedido1x.FechaRealizacion, toni.Email, Pedido01_1);

                //Pedido2
                PedidoEN pedido2 = new PedidoEN ();
                pedido2.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido2.FechaRealizacion = DateTime.Parse ("02/14/2015 9:26:21", System.Globalization.CultureInfo.InvariantCulture);
                int ped2 = pedidoCEN.CrearPedido (pedido2.Estado, pedido2.FechaRealizacion, toni.Email, Pedido02_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (ped2, DateTime.Parse ("02/19/2015 14:10:00", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);


                //Pedido3
                PedidoEN pedido3 = new PedidoEN ();
                pedido3.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;

                pedido3.FechaRealizacion = DateTime.Parse("03/14/2015 10:36:41", System.Globalization.CultureInfo.InvariantCulture);
                int ped3 = pedidoCEN.CrearPedido(pedido3.Estado, pedido3.FechaRealizacion, toni.Email, Pedido03_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento(ped3, DateTime.Parse("03/19/2015 09:19:56", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo(2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);

                PedidoEN pedido2x = new PedidoEN();
                pedido2x.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido2x.FechaRealizacion = DateTime.Parse("04/12/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture);
                int pedi2x = pedidoCEN.CrearPedido(pedido2x.Estado, pedido2x.FechaRealizacion, toni.Email, Pedido02_1);



                //Pedido4
                PedidoEN pedido4 = new PedidoEN ();
                pedido4.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido4.FechaRealizacion = DateTime.Parse ("04/24/2015 15:16:11", System.Globalization.CultureInfo.InvariantCulture);
                int ped4 = pedidoCEN.CrearPedido (pedido4.Estado, pedido4.FechaRealizacion, toni.Email, Pedido04_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (ped4, DateTime.Parse ("04/25/2015 11:17:08", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);


                //Pedido5
                PedidoEN pedido5 = new PedidoEN ();
                pedido5.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido5.FechaRealizacion = DateTime.Parse ("05/05/2015 18:03:21", System.Globalization.CultureInfo.InvariantCulture);
                int ped5 = pedidoCEN.CrearPedido (pedido5.Estado, pedido5.FechaRealizacion, toni.Email, Pedido05_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (ped5, DateTime.Parse ("05/10/2015 12:01:10", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);



                //Pedido6
                PedidoEN pedido6 = new PedidoEN ();
                pedido6.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido6.FechaRealizacion = DateTime.Parse ("06/11/2015 08:07:56", System.Globalization.CultureInfo.InvariantCulture);
                int ped6 = pedidoCEN.CrearPedido (pedido6.Estado, pedido6.FechaRealizacion, toni.Email, Pedido06_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (ped6, DateTime.Parse ("06/14/2015 16:46:48", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);



                //Pedido7
                PedidoEN pedido7 = new PedidoEN ();
                pedido7.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido7.FechaRealizacion = DateTime.Parse ("07/23/2015 14:01:01", System.Globalization.CultureInfo.InvariantCulture);
                int ped7 = pedidoCEN.CrearPedido (pedido7.Estado, pedido7.FechaRealizacion, toni.Email, Pedido07_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (ped7, DateTime.Parse ("07/13/2015 10:37:09", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);



                //Pedido8
                PedidoEN pedido8 = new PedidoEN ();
                pedido8.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido8.FechaRealizacion = DateTime.Parse ("08/24/2015 15:16:11", System.Globalization.CultureInfo.InvariantCulture);
                int ped8 = pedidoCEN.CrearPedido (pedido8.Estado, pedido8.FechaRealizacion, toni.Email, Pedido08_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (ped8, DateTime.Parse ("08/29/2015 11:17:08", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);



                //Pedido9
                PedidoEN pedido9 = new PedidoEN ();
                pedido9.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido9.FechaRealizacion = DateTime.Parse ("09/02/2015 17:51:03", System.Globalization.CultureInfo.InvariantCulture);
                int ped9 = pedidoCEN.CrearPedido (pedido9.Estado, pedido9.FechaRealizacion, toni.Email, Pedido09_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (ped9, DateTime.Parse ("09/12/2015 11:00:08", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);



                //Pedido10
                PedidoEN pedido10 = new PedidoEN ();
                pedido10.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido10.FechaRealizacion = DateTime.Parse ("10/04/2015 15:06:47", System.Globalization.CultureInfo.InvariantCulture);
                int ped10 = pedidoCEN.CrearPedido (pedido10.Estado, pedido10.FechaRealizacion, toni.Email, Pedido10_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (ped10, DateTime.Parse ("10/21/2015 09:25:04", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);



                //Pedido11
                PedidoEN pedido11 = new PedidoEN ();
                pedido11.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido11.FechaRealizacion = DateTime.Parse ("11/20/2015 12:00:28", System.Globalization.CultureInfo.InvariantCulture);
                int ped11 = pedidoCEN.CrearPedido (pedido11.Estado, pedido11.FechaRealizacion, toni.Email, Pedido11_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (ped11, DateTime.Parse ("11/25/2015 17:17:08", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);



                //Pedido12
                PedidoEN pedido12 = new PedidoEN ();
                pedido12.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;

                pedido12.FechaRealizacion = DateTime.Parse("12/14/2015 15:16:11", System.Globalization.CultureInfo.InvariantCulture);
                int ped12 = pedidoCEN.CrearPedido(pedido12.Estado, pedido12.FechaRealizacion, toni.Email, Pedido12_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento(ped12, DateTime.Parse("12/17/2015 08:27:45", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo(2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);

                PedidoEN pedido3x = new PedidoEN();
                pedido3x.Estado = IManagerGenNHibernate.Enumerated.IManager.EstadoPedidoEnum.pendiente;
                pedido3x.FechaRealizacion = DateTime.Parse("01/04/2016 17:12:30", System.Globalization.CultureInfo.InvariantCulture);
                int pedi3x = pedidoCEN.CrearPedido(pedido3x.Estado, pedido3x.FechaRealizacion, toni.Email, Pedido11_1);



                #endregion


                #region Ventas
            
                //Enero

                //LineaVentas 1
                LineaVentaEN lv1 = new LineaVentaEN ();
                lv1.Cantidad = 1;

                lv1.Producto = productoCEN.GetProducto("O07592");
                LineaVentaEN lv2 = new LineaVentaEN();
                lv2.Cantidad = 1;
                lv2.Producto = productoCEN.GetProducto("120547-9000");
                LineaVentaEN lv3 = new LineaVentaEN();

                lv3.Cantidad = 1;
                lv3.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta01_1 = new List<LineaVentaEN>();
                Venta01_1.Add (lv1);
                Venta01_1.Add (lv2);
                Venta01_1.Add (lv3);

                //Venta1        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta01_1);

                //LineaVentas 2
                LineaVentaEN lv4 = new LineaVentaEN ();
                lv4.Cantidad = 1;

                lv4.Producto = productoCEN.GetProducto("119153-9000");
                LineaVentaEN lv5 = new LineaVentaEN();
                lv5.Cantidad = 1;
                lv5.Producto = productoCEN.GetProducto("O07585");


                IList<LineaVentaEN> Venta02_1 = new List<LineaVentaEN>();
                Venta02_1.Add(lv4);
                Venta02_1.Add(lv5);

                //Venta2        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/05/2015 16:56:22", System.Globalization.CultureInfo.InvariantCulture), Venta02_1);

                //LineaVentas 3
                LineaVentaEN lv6 = new LineaVentaEN();
                lv6.Cantidad = 1;
                lv6.Producto = productoCEN.GetProducto("F50485");
                LineaVentaEN lv7 = new LineaVentaEN();
                lv7.Cantidad = 1;
                lv7.Producto = productoCEN.GetProducto("O07592");
                LineaVentaEN lv8 = new LineaVentaEN();
                lv8.Cantidad = 1;
                lv8.Producto = productoCEN.GetProducto("O07598");
                LineaVentaEN lv9 = new LineaVentaEN();
                lv9.Cantidad = 1;
                lv9.Producto = productoCEN.GetProducto("G98180");

                IList<LineaVentaEN> Venta03_1 = new List<LineaVentaEN>();
                Venta03_1.Add(lv6);
                Venta03_1.Add(lv7);
                Venta03_1.Add(lv8);
                Venta03_1.Add(lv9);


                //Venta3        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/08/2015 11:02:11", System.Globalization.CultureInfo.InvariantCulture), Venta03_1);

                //LineaVentas 4
                LineaVentaEN lv10 = new LineaVentaEN ();
                lv10.Cantidad = 1;

                lv10.Producto = productoCEN.GetProducto("O07592");
                LineaVentaEN lv11 = new LineaVentaEN();
                lv11.Cantidad = 1;
                lv11.Producto = productoCEN.GetProducto("G98180");
                LineaVentaEN lv12 = new LineaVentaEN();
                lv12.Cantidad = 1;
                lv12.Producto = productoCEN.GetProducto("F50485");

                IList<LineaVentaEN> Venta04_1 = new List<LineaVentaEN>();
                Venta04_1.Add(lv10);
                Venta04_1.Add(lv11);
                Venta04_1.Add(lv12);
           
                //Venta4        
                 ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/09/2015 12:02:10", System.Globalization.CultureInfo.InvariantCulture), Venta04_1);

                 //LineaVentas 5
                 LineaVentaEN lv13 = new LineaVentaEN();
                 lv13.Cantidad = 1;
                 lv13.Producto = productoCEN.GetProducto("O07592");
                 LineaVentaEN lv14 = new LineaVentaEN();
                 lv14.Cantidad = 1;
                 lv14.Producto = productoCEN.GetProducto("120547-9000");
                 LineaVentaEN lv15 = new LineaVentaEN();
                 lv15.Cantidad = 1;
                 lv15.Producto = productoCEN.GetProducto("120518-7012");

                 IList<LineaVentaEN> Venta05_1 = new List<LineaVentaEN>();
                 Venta05_1.Add(lv13);
                 Venta05_1.Add(lv14);
                 Venta05_1.Add(lv15);

                //Venta5        
                  ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta05_1);


                  //LineaVentas 6
                  LineaVentaEN lv16 = new LineaVentaEN();
                  lv16.Cantidad = 1;
                  lv16.Producto = productoCEN.GetProducto("O07592");
                  LineaVentaEN lv17 = new LineaVentaEN();
                  lv17.Cantidad = 1;
                  lv17.Producto = productoCEN.GetProducto("120547-9000");
                  LineaVentaEN lv18 = new LineaVentaEN();
                  lv18.Cantidad = 1;
                  lv18.Producto = productoCEN.GetProducto("120518-7012");

                  IList<LineaVentaEN> Venta06_1 = new List<LineaVentaEN>();
                  Venta06_1.Add(lv16);
                  Venta06_1.Add(lv17);
                  Venta06_1.Add(lv18);

               //Venta6        
                  ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/09/2015 18:00:10", System.Globalization.CultureInfo.InvariantCulture), Venta06_1);

                  //LineaVentas 7
                  LineaVentaEN lv19 = new LineaVentaEN();
                  lv19.Cantidad = 1;
                  lv19.Producto = productoCEN.GetProducto("O07592");
                  LineaVentaEN lv20 = new LineaVentaEN();
                  lv20.Cantidad = 1;
                  lv20.Producto = productoCEN.GetProducto("120547-9000");
                  LineaVentaEN lv21 = new LineaVentaEN();
                  lv21.Cantidad = 1;
                  lv21.Producto = productoCEN.GetProducto("120518-7012");

                  IList<LineaVentaEN> Venta07_1 = new List<LineaVentaEN>();
                  Venta07_1.Add(lv19);
                  Venta07_1.Add(lv20);
                  Venta07_1.Add(lv21);

                //Venta7        
                 ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/12/2015 10:45:10", System.Globalization.CultureInfo.InvariantCulture), Venta07_1);

                 //LineaVentas 8
                 LineaVentaEN lv22 = new LineaVentaEN();
                 lv22.Cantidad = 1;
                 lv22.Producto = productoCEN.GetProducto("O07592");
                 LineaVentaEN lv23 = new LineaVentaEN();
                 lv23.Cantidad = 1;
                 lv23.Producto = productoCEN.GetProducto("120547-9000");
                 LineaVentaEN lv24 = new LineaVentaEN();
                 lv24.Cantidad = 1;
                 lv24.Producto = productoCEN.GetProducto("120518-7012");

                 IList<LineaVentaEN> Venta08_1 = new List<LineaVentaEN>();
                 Venta08_1.Add(lv22);
                 Venta08_1.Add(lv23);
                 Venta08_1.Add(lv24);

                //Venta8        
                 ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/12/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta08_1);

                 //LineaVentas 9
                 LineaVentaEN lv25 = new LineaVentaEN();
                 lv25.Cantidad = 1;
                 lv25.Producto = productoCEN.GetProducto("O07592");
                 LineaVentaEN lv26 = new LineaVentaEN();
                 lv26.Cantidad = 1;
                 lv26.Producto = productoCEN.GetProducto("120547-9000");
                 LineaVentaEN lv27 = new LineaVentaEN();
                 lv27.Cantidad = 1;
                 lv27.Producto = productoCEN.GetProducto("120518-7012");

                 IList<LineaVentaEN> Venta09_1 = new List<LineaVentaEN>();
                 Venta09_1.Add(lv25);
                 Venta09_1.Add(lv26);
                 Venta09_1.Add(lv27);

                    //Venta9        
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/14/2015 14:02:10", System.Globalization.CultureInfo.InvariantCulture), Venta09_1);

                    //LineaVentas 10
                    LineaVentaEN lv28 = new LineaVentaEN();
                    lv28.Cantidad = 1;
                    lv28.Producto = productoCEN.GetProducto("O07592");


                    IList<LineaVentaEN> Venta10_1 = new List<LineaVentaEN>();
                    Venta10_1.Add(lv28);

                    //Venta10        
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/14/2015 19:30:25", System.Globalization.CultureInfo.InvariantCulture), Venta10_1);


                    //LineaVentas 11

                    LineaVentaEN lv33 = new LineaVentaEN();
                    lv33.Cantidad = 1;
                    lv33.Producto = productoCEN.GetProducto("120518-7012");

                    IList<LineaVentaEN> Venta11_1 = new List<LineaVentaEN>();

                    Venta11_1.Add(lv33);

                    //Venta11        
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/16/2015 09:30:12", System.Globalization.CultureInfo.InvariantCulture), Venta11_1);

                    //LineaVentas 12
                    LineaVentaEN lv34 = new LineaVentaEN();
                    lv34.Cantidad = 1;
                    lv34.Producto = productoCEN.GetProducto("119144-7185");
                    LineaVentaEN lv35 = new LineaVentaEN();


                    IList<LineaVentaEN> Venta12_1 = new List<LineaVentaEN>();
                    Venta12_1.Add(lv34);

                    //Venta12        
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta12_1);



                    //LineaVentas 13
                    LineaVentaEN lv37 = new LineaVentaEN();
                    lv37.Cantidad = 1;
                    lv37.Producto = productoCEN.GetProducto("O07592");


                    IList<LineaVentaEN> Venta13_1 = new List<LineaVentaEN>();
                    Venta13_1.Add(lv37);
        

                    //Venta13       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/18/2015 14:22:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                    //LineaVentas 14
                    LineaVentaEN lv38 = new LineaVentaEN();
                    lv38.Cantidad = 1;
                    lv38.Producto = productoCEN.GetProducto("119144-7185");



                    IList<LineaVentaEN> Venta14_1 = new List<LineaVentaEN>();
                    Venta14_1.Add(lv34);

                    //Venta14       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/18/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta14_1);

                    //LineaVentas 15
                    LineaVentaEN lv39 = new LineaVentaEN();
                    lv39.Cantidad = 1;
                    lv39.Producto = productoCEN.GetProducto("O07592");


                    IList<LineaVentaEN> Venta15_1 = new List<LineaVentaEN>();
                    Venta15_1.Add(lv39);
        
                
                    //Venta15       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/19/2015 11:28:10", System.Globalization.CultureInfo.InvariantCulture), Venta15_1);

                    //LineaVentas 16
                    LineaVentaEN lv40 = new LineaVentaEN();
                    lv40.Cantidad = 1;
                    lv40.Producto = productoCEN.GetProducto("O07592");


                    IList<LineaVentaEN> Venta16_1 = new List<LineaVentaEN>();
                    Venta16_1.Add(lv40);

                    //Venta16       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/19/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta16_1);

                    //LineaVentas 17
                    LineaVentaEN lv41 = new LineaVentaEN();
                    lv41.Cantidad = 1;
                    lv41.Producto = productoCEN.GetProducto("O07592");
                    LineaVentaEN lv42 = new LineaVentaEN();
                    lv42.Cantidad = 1;
                    lv42.Producto = productoCEN.GetProducto("120547-9000");
                    LineaVentaEN lv43 = new LineaVentaEN();
                    lv43.Cantidad = 1;
                    lv43.Producto = productoCEN.GetProducto("120518-7012");

                    IList<LineaVentaEN> Venta17_1 = new List<LineaVentaEN>();
                    Venta17_1.Add(lv41);
                    Venta17_1.Add(lv42);
                    Venta17_1.Add(lv43);

                    //Venta17       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/19/2015 18:10:30", System.Globalization.CultureInfo.InvariantCulture), Venta17_1);

                    //LineaVentas 18
                    LineaVentaEN lv44 = new LineaVentaEN();
                    lv44.Cantidad = 1;
                    lv44.Producto = productoCEN.GetProducto("F50485");
                    LineaVentaEN lv45 = new LineaVentaEN();
                    lv45.Cantidad = 1;
                    lv45.Producto = productoCEN.GetProducto("O07592");
                    LineaVentaEN lv46 = new LineaVentaEN();
                    lv46.Cantidad = 1;
                    lv46.Producto = productoCEN.GetProducto("O07598");
                    LineaVentaEN lv47 = new LineaVentaEN();
                    lv47.Cantidad = 1;
                    lv47.Producto = productoCEN.GetProducto("G98180");

                    IList<LineaVentaEN> Venta18_1 = new List<LineaVentaEN>();
                    Venta18_1.Add(lv44);
                    Venta18_1.Add(lv45);
                    Venta18_1.Add(lv46);
                    Venta18_1.Add(lv47);

                    //Venta18       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/20/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta18_1);

                    //LineaVentas 19
                    LineaVentaEN lv48 = new LineaVentaEN();
                    lv48.Cantidad = 1;
                    lv48.Producto = productoCEN.GetProducto("119144-7185");

                    IList<LineaVentaEN> Venta19_1 = new List<LineaVentaEN>();
                    Venta19_1.Add(lv48);

                    //Venta19       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/21/2015 10:00:30", System.Globalization.CultureInfo.InvariantCulture), Venta19_1);


                    //LineaVentas 20
                    LineaVentaEN lv49 = new LineaVentaEN();
                    lv49.Cantidad = 1;
                    lv49.Producto = productoCEN.GetProducto("F50485");
                    LineaVentaEN lv50 = new LineaVentaEN();
                    lv50.Cantidad = 1;
                    lv50.Producto = productoCEN.GetProducto("O07592");
                    LineaVentaEN lv51 = new LineaVentaEN();
                    lv51.Cantidad = 1;
                    lv51.Producto = productoCEN.GetProducto("O07598");
                    LineaVentaEN lv52 = new LineaVentaEN();
                    lv52.Cantidad = 1;
                    lv52.Producto = productoCEN.GetProducto("G98180");

                    IList<LineaVentaEN> Venta20_1 = new List<LineaVentaEN>();
                    Venta20_1.Add(lv49);
                    Venta20_1.Add(lv50);
                    Venta20_1.Add(lv51);
                    Venta20_1.Add(lv52);

                    //Venta20       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/21/2015 13:00:13", System.Globalization.CultureInfo.InvariantCulture), Venta20_1);

                    //LineaVentas 21
                    LineaVentaEN lv53 = new LineaVentaEN();
                    lv53.Cantidad = 1;
                    lv53.Producto = productoCEN.GetProducto("119144-7185");



                    IList<LineaVentaEN> Venta21_1 = new List<LineaVentaEN>();
                    Venta21_1.Add(lv53);


                    //Venta21       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/22/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta21_1);

                    //LineaVentas 22
                    LineaVentaEN lv54 = new LineaVentaEN();
                    lv54.Cantidad = 1;
                    lv54.Producto = productoCEN.GetProducto("119144-7185");



                    IList<LineaVentaEN> Venta22_1 = new List<LineaVentaEN>();
                    Venta21_1.Add(lv53);

                    //Venta22       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/22/2015 16:02:32", System.Globalization.CultureInfo.InvariantCulture), Venta22_1);

                    //LineaVentas 23
                    LineaVentaEN lv55 = new LineaVentaEN();
                    lv55.Cantidad = 1;
                    lv55.Producto = productoCEN.GetProducto("O07592");


                    IList<LineaVentaEN> Venta23_1 = new List<LineaVentaEN>();
                    Venta15_1.Add(lv55);
        
                
                    //Venta23       ;
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/22/2015 17:24:11", System.Globalization.CultureInfo.InvariantCulture), Venta23_1);

                    //LineaVentas 24
                    LineaVentaEN lv56 = new LineaVentaEN();
                    lv56.Cantidad = 1;
                    lv56.Producto = productoCEN.GetProducto("O07592");


                    IList<LineaVentaEN> Venta24_1 = new List<LineaVentaEN>();
                    Venta15_1.Add(lv56);

                    //Venta24       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/23/2015 09:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta24_1);

                    //LineaVentas 25
                    LineaVentaEN lv57 = new LineaVentaEN();
                    lv57.Cantidad = 1;
                    lv57.Producto = productoCEN.GetProducto("G98180");

                    IList<LineaVentaEN> Venta25_1 = new List<LineaVentaEN>();
                    Venta25_1.Add(lv57);
        

                    //Venta25       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/23/2015 11:08:30", System.Globalization.CultureInfo.InvariantCulture), Venta25_1);

                    //LineaVentas 26
                    LineaVentaEN lv58 = new LineaVentaEN();
                    lv58.Cantidad = 1;
                    lv58.Producto = productoCEN.GetProducto("F50485");

                    IList<LineaVentaEN> Venta26_1 = new List<LineaVentaEN>();
                    Venta26_1.Add(lv58);

                    //Venta26       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/23/2015 12:15:20", System.Globalization.CultureInfo.InvariantCulture), Venta26_1);

                    //LineaVentas 27
                    LineaVentaEN lv59 = new LineaVentaEN();
                    lv59.Cantidad = 1;
                    lv59.Producto = productoCEN.GetProducto("M20162");

                    IList<LineaVentaEN> Venta27_1 = new List<LineaVentaEN>();
                    Venta27_1.Add(lv59);

                    //Venta27       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/23/2015 13:18:50", System.Globalization.CultureInfo.InvariantCulture), Venta27_1);

                    //LineaVentas 28
                    LineaVentaEN lv60 = new LineaVentaEN();
                    lv60.Cantidad = 1;
                    lv60.Producto = productoCEN.GetProducto("F50485");

                    IList<LineaVentaEN> Venta28_1 = new List<LineaVentaEN>();
                    Venta28_1.Add(lv60);

                    //Venta28      
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/24/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta28_1);

                    //LineaVentas 29
                    LineaVentaEN lv61 = new LineaVentaEN();
                    lv61.Cantidad = 1;
                    lv61.Producto = productoCEN.GetProducto("M20162");

                    IList<LineaVentaEN> Venta29_1 = new List<LineaVentaEN>();
                    Venta29_1.Add(lv61);

                    //Venta29      
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/24/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta29_1);

                    //LineaVentas 30
                    LineaVentaEN lv62 = new LineaVentaEN();
                    lv62.Cantidad = 1;
                    lv62.Producto = productoCEN.GetProducto("F50485");

                    IList<LineaVentaEN> Venta30_1 = new List<LineaVentaEN>();
                    Venta30_1.Add(lv62);

                    //Venta30      
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/24/2015 17:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta30_1);

                    //LineaVentas 31
                    LineaVentaEN lv63 = new LineaVentaEN();
                    lv63.Cantidad = 1;
                    lv63.Producto = productoCEN.GetProducto("Q21672");

                    IList<LineaVentaEN> Venta31_1 = new List<LineaVentaEN>();
                    Venta31_1.Add(lv63);

                    //Venta31       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/25/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta31_1);

                    //LineaVentas 32
                    LineaVentaEN lv64 = new LineaVentaEN();
                    lv64.Cantidad = 1;
                    lv64.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                    IList<LineaVentaEN> Venta32_1 = new List<LineaVentaEN>();
                    Venta32_1.Add(lv64);

                    //Venta32       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/25/2015 11:15:30", System.Globalization.CultureInfo.InvariantCulture), Venta32_1);

                    //LineaVentas 33
                    LineaVentaEN lv65 = new LineaVentaEN();
                    lv65.Cantidad = 1;
                    lv65.Producto = productoCEN.GetProducto("M20162");

                    IList<LineaVentaEN> Venta33_1 = new List<LineaVentaEN>();
                    Venta33_1.Add(lv65);

                    //Venta33       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/26/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta33_1);

                    //LineaVentas 34
                    LineaVentaEN lv66 = new LineaVentaEN();
                    lv66.Cantidad = 1;
                    lv66.Producto = productoCEN.GetProducto("F50485");

                    IList<LineaVentaEN> Venta34_1 = new List<LineaVentaEN>();
                    Venta34_1.Add(lv66);

                    //Venta34       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/27/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta34_1);

                    //LineaVentas 35
                    LineaVentaEN lv67 = new LineaVentaEN();
                    lv67.Cantidad = 1;
                    lv67.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                    IList<LineaVentaEN> Venta35_1 = new List<LineaVentaEN>();
                    Venta35_1.Add(lv67);

                    //Venta35       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/28/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta35_1);

                    //LineaVentas 36
                    LineaVentaEN lv68 = new LineaVentaEN();
                    lv68.Cantidad = 1;
                    lv68.Producto = productoCEN.GetProducto("F50485");

                    IList<LineaVentaEN> Venta36_1 = new List<LineaVentaEN>();
                    Venta36_1.Add(lv68);

                    //Venta36      
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/29/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta36_1);

                    //LineaVentas 37
                    LineaVentaEN lv69 = new LineaVentaEN();
                    lv69.Cantidad = 1;
                    lv69.Producto = productoCEN.GetProducto("D67175");

                    IList<LineaVentaEN> Venta37_1 = new List<LineaVentaEN>();
                    Venta37_1.Add(lv69);

                    //Venta37       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/29/2015 18:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta37_1);

                    //LineaVentas 38
                    LineaVentaEN lv70 = new LineaVentaEN();
                    lv70.Cantidad = 1;
                    lv70.Producto = productoCEN.GetProducto("D67175");

                    IList<LineaVentaEN> Venta38_1 = new List<LineaVentaEN>();
                    Venta38_1.Add(lv70);

                    //Venta38       
                    ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("01/30/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta38_1);
                   
            
            
                
                //Febrero------------------------------------------------------------------------

                    //LineaVentas 39
                    LineaVentaEN lv71 = new LineaVentaEN();
                    lv71.Cantidad = 1;
                    lv71.Producto = productoCEN.GetProducto("D67175");

                    IList<LineaVentaEN> Venta39_1 = new List<LineaVentaEN>();
                    Venta39_1.Add(lv71);


                //Venta39        
             
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta39_1);

                //LineaVentas 40
                LineaVentaEN lv72 = new LineaVentaEN();
                lv72.Cantidad = 1;
                lv72.Producto = productoCEN.GetProducto("119221-7185");

                IList<LineaVentaEN> Venta40_1 = new List<LineaVentaEN>();
                Venta40_1.Add(lv72);

                //Venta40        
               
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta40_1);

                //LineaVentas 41
                LineaVentaEN lv73 = new LineaVentaEN();
                lv73.Cantidad = 1;
                lv73.Producto = productoCEN.GetProducto("119221-7185");

                IList<LineaVentaEN> Venta41_1 = new List<LineaVentaEN>();
                Venta41_1.Add(lv73);

                //Venta41        
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta41_1);

                //LineaVentas 42
                LineaVentaEN lv74 = new LineaVentaEN();
                lv74.Cantidad = 1;
                lv74.Producto = productoCEN.GetProducto("119221-7185");

                IList<LineaVentaEN> Venta42_1 = new List<LineaVentaEN>();
                Venta42_1.Add(lv74);

                //Venta42        
               
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta42_1);

                //LineaVentas 43
                LineaVentaEN lv75 = new LineaVentaEN();
                lv75.Cantidad = 1;
                lv75.Producto = productoCEN.GetProducto("119221-7185");

                IList<LineaVentaEN> Venta43_1 = new List<LineaVentaEN>();
                Venta43_1.Add(lv75);

                //Venta43        
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta43_1);

                //LineaVentas 44
                LineaVentaEN lv76 = new LineaVentaEN();
                lv76.Cantidad = 1;
                lv76.Producto = productoCEN.GetProducto("119221-7185");

                IList<LineaVentaEN> Venta44_1 = new List<LineaVentaEN>();
                Venta44_1.Add(lv76);

                //Venta44        
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta44_1);


                //LineaVentas 45
                LineaVentaEN lv77 = new LineaVentaEN();
                lv77.Cantidad = 1;
                lv77.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta45_1 = new List<LineaVentaEN>();
                Venta45_1.Add(lv77);

                //Venta45        
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta45_1);


                //LineaVentas 46
                LineaVentaEN lv78 = new LineaVentaEN();
                lv78.Cantidad = 1;
                lv78.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta46_1 = new List<LineaVentaEN>();
                Venta46_1.Add(lv78);

                //Venta46        
               
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta46_1);


                //LineaVentas 47
                LineaVentaEN lv79 = new LineaVentaEN();
                lv79.Cantidad = 1;
                lv79.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                IList<LineaVentaEN> Venta47_1 = new List<LineaVentaEN>();
                Venta47_1.Add(lv79);

                //Venta47        
                
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta47_1);

                //LineaVentas 48
                LineaVentaEN lv80 = new LineaVentaEN();
                lv80.Cantidad = 1;
                lv80.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                IList<LineaVentaEN> Venta48_1 = new List<LineaVentaEN>();
                Venta48_1.Add(lv80);

                //Venta48        
               
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta48_1);

                //LineaVentas 49
                LineaVentaEN lv81 = new LineaVentaEN();
                lv81.Cantidad = 1;
                lv81.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                IList<LineaVentaEN> Venta49_1 = new List<LineaVentaEN>();
                Venta49_1.Add(lv81);

                //Venta49        
               
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta49_1);


                //LineaVentas 50
                LineaVentaEN lv82 = new LineaVentaEN();
                lv82.Cantidad = 1;
                lv82.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                IList<LineaVentaEN> Venta50_1 = new List<LineaVentaEN>();
                Venta50_1.Add(lv82);

                //Venta50        
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta50_1);

                //LineaVentas 50
                LineaVentaEN lv83 = new LineaVentaEN();
                lv83.Cantidad = 1;
                lv83.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                IList<LineaVentaEN> Venta51_1 = new List<LineaVentaEN>();
                Venta51_1.Add(lv83);

                //Venta51       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta51_1);

                //LineaVentas 51
                LineaVentaEN lv84 = new LineaVentaEN();
                lv84.Cantidad = 1;
                lv84.Producto = productoCEN.GetProducto("119150-9500");

                IList<LineaVentaEN> Venta52_1 = new List<LineaVentaEN>();
                Venta52_1.Add(lv84);

                //Venta52       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta52_1);

                //LineaVentas 52
                LineaVentaEN lv85 = new LineaVentaEN();
                lv85.Cantidad = 1;
                lv85.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta53_1 = new List<LineaVentaEN>();
                Venta53_1.Add(lv85);

                //Venta53       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta53_1);

                //LineaVentas 54
                LineaVentaEN lv86 = new LineaVentaEN();
                lv86.Cantidad = 1;
                lv86.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta54_1 = new List<LineaVentaEN>();
                Venta54_1.Add(lv86);

                //Venta54       
         
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta54_1);

                //LineaVentas 55
                LineaVentaEN lv87 = new LineaVentaEN();
                lv87.Cantidad = 1;
                lv87.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta55_1 = new List<LineaVentaEN>();
                Venta55_1.Add(lv87);

                //Venta55       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta55_1);


                //LineaVentas 56
                LineaVentaEN lv88 = new LineaVentaEN();
                lv88.Cantidad = 1;
                lv88.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta56_1 = new List<LineaVentaEN>();
                Venta56_1.Add(lv88);

                //Venta56       


                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta56_1);

                //LineaVentas 57
                LineaVentaEN lv89 = new LineaVentaEN();
                lv89.Cantidad = 1;
                lv89.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta57_1 = new List<LineaVentaEN>();
                Venta57_1.Add(lv89);

                //Venta57       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta57_1);

                //LineaVentas 58
                LineaVentaEN lv90 = new LineaVentaEN();
                lv90.Cantidad = 1;
                lv90.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta58_1 = new List<LineaVentaEN>();
                Venta58_1.Add(lv90);

                //Venta58       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta58_1);

                //LineaVentas 59
                LineaVentaEN lv91 = new LineaVentaEN();
                lv91.Cantidad = 1;
                lv91.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta59_1 = new List<LineaVentaEN>();
                Venta59_1.Add(lv91);

                //Venta59       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta59_1);


                //LineaVentas 60
                LineaVentaEN lv92 = new LineaVentaEN();
                lv92.Cantidad = 1;
                lv92.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta60_1 = new List<LineaVentaEN>();
                Venta60_1.Add(lv92);

                //Venta60       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta60_1);


                //LineaVentas 61
                LineaVentaEN lv93 = new LineaVentaEN();
                lv93.Cantidad = 1;
                lv93.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta61_1 = new List<LineaVentaEN>();
                Venta61_1.Add(lv93);

                //Venta61       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta61_1);


                //LineaVentas 62
                LineaVentaEN lv94 = new LineaVentaEN();
                lv94.Cantidad = 1;
                lv94.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta62_1 = new List<LineaVentaEN>();
                Venta62_1.Add(lv94);

                //Venta62       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta62_1);

                //LineaVentas 63
                LineaVentaEN lv95 = new LineaVentaEN();
                lv95.Cantidad = 1;
                lv95.Producto = productoCEN.GetProducto("D67175");


                IList<LineaVentaEN> Venta63_1 = new List<LineaVentaEN>();
                Venta63_1.Add(lv95);

                //Venta63       
          
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta63_1);


                //LineaVentas 64
                LineaVentaEN lv96 = new LineaVentaEN();
                lv96.Cantidad = 1;
                lv96.Producto = productoCEN.GetProducto("D67175");

                IList<LineaVentaEN> Venta64_1 = new List<LineaVentaEN>();
                Venta64_1.Add(lv96);

                //Venta64       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta64_1);


                //LineaVentas 65
                LineaVentaEN lv97 = new LineaVentaEN();
                lv97.Cantidad = 1;
                lv97.Producto = productoCEN.GetProducto("D67175");

                IList<LineaVentaEN> Venta65_1 = new List<LineaVentaEN>();
                Venta65_1.Add(lv97);

                //Venta65       
             
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta65_1);

                //LineaVentas 66
                LineaVentaEN lv98 = new LineaVentaEN();
                lv98.Cantidad = 1;
                lv98.Producto = productoCEN.GetProducto("D67175");

                IList<LineaVentaEN> Venta66_1 = new List<LineaVentaEN>();
                Venta66_1.Add(lv98);

                //Venta66       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/24/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta66_1);

                //LineaVentas 67
                LineaVentaEN lv99 = new LineaVentaEN();
                lv99.Cantidad = 1;
                lv99.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta67_1 = new List<LineaVentaEN>();
                Venta67_1.Add(lv99);

                //Venta67       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/26/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta67_1);

                //LineaVentas 68
                LineaVentaEN lv100 = new LineaVentaEN();
                lv100.Cantidad = 1;
                lv100.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta68_1 = new List<LineaVentaEN>();
                Venta68_1.Add(lv100);

                //Venta68      

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/27/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta68_1);

                //LineaVentas 69
                LineaVentaEN lv101 = new LineaVentaEN();
                lv101.Cantidad = 1;
                lv101.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta69_1 = new List<LineaVentaEN>();
                Venta69_1.Add(lv101);

                //Venta69       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/27/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta69_1);

                //LineaVentas 70
                LineaVentaEN lv102 = new LineaVentaEN();
                lv102.Cantidad = 1;
                lv102.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta70_1 = new List<LineaVentaEN>();
                Venta70_1.Add(lv102);

                //Venta70       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/27/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta70_1);


                //LineaVentas 71
                LineaVentaEN lv103 = new LineaVentaEN();
                lv103.Cantidad = 1;
                lv103.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                IList<LineaVentaEN> Venta71_1 = new List<LineaVentaEN>();
                Venta71_1.Add(lv103);

                //Venta71       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("02/27/2015 20:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta71_1);

            
                //Marzo-------------------------------------------------------------------------------------

                //LineaVentas 74
                LineaVentaEN lv104 = new LineaVentaEN();
                lv104.Cantidad = 1;
                lv104.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                IList<LineaVentaEN> Venta74_1 = new List<LineaVentaEN>();
                Venta74_1.Add(lv104);    

                //Venta74        
             
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta74_1);

                //LineaVentas 75
                LineaVentaEN lv105 = new LineaVentaEN();
                lv105.Cantidad = 1;
                lv105.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta75_1 = new List<LineaVentaEN>();
                Venta75_1.Add(lv105);    

                //Venta75        
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta75_1);

                //LineaVentas 76
                LineaVentaEN lv106 = new LineaVentaEN();
                lv106.Cantidad = 1;
                lv106.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta76_1 = new List<LineaVentaEN>();
                Venta76_1.Add(lv106);   

                //Venta76        
     
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta76_1);


                //LineaVentas 77
                LineaVentaEN lv107 = new LineaVentaEN();
                lv107.Cantidad = 1;
                lv107.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta77_1 = new List<LineaVentaEN>();
                Venta77_1.Add(lv107);   

                //Venta77        
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta77_1);


                //LineaVentas 78
                LineaVentaEN lv108 = new LineaVentaEN();
                lv108.Cantidad = 1;
                lv108.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta78_1 = new List<LineaVentaEN>();
                Venta78_1.Add(lv108);   

                //Venta78
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta78_1);

                //LineaVentas 79
                LineaVentaEN lv109 = new LineaVentaEN();
                lv109.Cantidad = 1;
                lv109.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta79_1 = new List<LineaVentaEN>();
                Venta79_1.Add(lv109); 

                //Venta79        
               
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta79_1);


                //LineaVentas 80
                LineaVentaEN lv110 = new LineaVentaEN();
                lv110.Cantidad = 1;
                lv110.Producto = productoCEN.GetProducto("D67175");

                IList<LineaVentaEN> Venta80_1 = new List<LineaVentaEN>();
                Venta80_1.Add(lv110); 

                //Venta80        
             
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta80_1);

                //LineaVentas 81
                LineaVentaEN lv111 = new LineaVentaEN();
                lv111.Cantidad = 1;
                lv111.Producto = productoCEN.GetProducto("D67175");

                IList<LineaVentaEN> Venta81_1 = new List<LineaVentaEN>();
                Venta81_1.Add(lv111); 

                //Venta81        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta81_1);

                //LineaVentas 82
                LineaVentaEN lv112 = new LineaVentaEN();
                lv112.Cantidad = 1;
                lv112.Producto = productoCEN.GetProducto("D67175");

                IList<LineaVentaEN> Venta82_1 = new List<LineaVentaEN>();
                Venta82_1.Add(lv112);

                //Venta82       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta82_1);

                //LineaVentas 83
                LineaVentaEN lv113 = new LineaVentaEN();
                lv113.Cantidad = 1;
                lv113.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta83_1 = new List<LineaVentaEN>();
                Venta83_1.Add(lv113);

                //Venta83        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta83_1);

                //LineaVentas 84
                LineaVentaEN lv114 = new LineaVentaEN();
                lv114.Cantidad = 1;
                lv114.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta84_1 = new List<LineaVentaEN>();
                Venta84_1.Add(lv114);

                //Venta84        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta84_1);

                //LineaVentas 85
                LineaVentaEN lv115 = new LineaVentaEN();
                lv115.Cantidad = 1;
                lv115.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta85_1 = new List<LineaVentaEN>();
                Venta85_1.Add(lv115);

                //Venta85       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta85_1);

                LineaVentaEN lv116 = new LineaVentaEN();
                lv116.Cantidad = 1;
                lv116.Producto = productoCEN.GetProducto("O07606");

                IList<LineaVentaEN> Venta86_1 = new List<LineaVentaEN>();
                Venta86_1.Add(lv116);

                //Venta86       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta86_1);


                LineaVentaEN lv117 = new LineaVentaEN();
                lv117.Cantidad = 1;
                lv117.Producto = productoCEN.GetProducto("O07606");

                IList<LineaVentaEN> Venta87_1 = new List<LineaVentaEN>();
                Venta87_1.Add(lv117);

                //Venta87       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta87_1);

                LineaVentaEN lv118 = new LineaVentaEN();
                lv118.Cantidad = 1;
                lv118.Producto = productoCEN.GetProducto("G65302");

                IList<LineaVentaEN> Venta88_1 = new List<LineaVentaEN>();
                Venta88_1.Add(lv118);

                //Venta88       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta88_1);

                LineaVentaEN lv119 = new LineaVentaEN();
                lv119.Cantidad = 1;
                lv119.Producto = productoCEN.GetProducto("G65302");

                IList<LineaVentaEN> Venta89_1 = new List<LineaVentaEN>();
                Venta89_1.Add(lv119);

                //Venta89       
     
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta89_1);

                LineaVentaEN lv120 = new LineaVentaEN();
                lv120.Cantidad = 1;
                lv120.Producto = productoCEN.GetProducto("G65302");

                IList<LineaVentaEN> Venta90_1 = new List<LineaVentaEN>();
                Venta90_1.Add(lv120);

                //Venta90       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta90_1);

                LineaVentaEN lv121 = new LineaVentaEN();
                lv121.Cantidad = 1;
                lv121.Producto = productoCEN.GetProducto("D73804");

                IList<LineaVentaEN> Venta91_1 = new List<LineaVentaEN>();
                Venta91_1.Add(lv121);

                //Venta91       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta91_1);


                LineaVentaEN lv122 = new LineaVentaEN();
                lv122.Cantidad = 1;
                lv122.Producto = productoCEN.GetProducto("D73804");

                IList<LineaVentaEN> Venta92_1 = new List<LineaVentaEN>();
                Venta92_1.Add(lv121);

                //Venta92       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta92_1);

                LineaVentaEN lv123 = new LineaVentaEN();
                lv123.Cantidad = 1;
                lv123.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta93_1 = new List<LineaVentaEN>();
                Venta93_1.Add(lv123);

                //Vent93       
      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta93_1);


                LineaVentaEN lv124 = new LineaVentaEN();
                lv124.Cantidad = 1;
                lv124.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta94_1 = new List<LineaVentaEN>();
                Venta94_1.Add(lv124);

                //Venta94       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta94_1);

                LineaVentaEN lv125 = new LineaVentaEN();
                lv125.Cantidad = 1;
                lv125.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta95_1 = new List<LineaVentaEN>();
                Venta95_1.Add(lv125);

                //Venta95       
             
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta95_1);

                LineaVentaEN lv126 = new LineaVentaEN();
                lv126.Cantidad = 1;
                lv126.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta96_1 = new List<LineaVentaEN>();
                Venta96_1.Add(lv126);

                //Venta96       
    
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta96_1);

                LineaVentaEN lv127 = new LineaVentaEN();
                lv127.Cantidad = 1;
                lv127.Producto = productoCEN.GetProducto("120517-5036");

                IList<LineaVentaEN> Venta97_1 = new List<LineaVentaEN>();
                Venta97_1.Add(lv127);

                //Venta97      

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta97_1);

                LineaVentaEN lv128 = new LineaVentaEN();
                lv128.Cantidad = 1;
                lv128.Producto = productoCEN.GetProducto("120517-5036");

                IList<LineaVentaEN> Venta98_1 = new List<LineaVentaEN>();
                Venta98_1.Add(lv128);

                //Venta98       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta98_1);

                LineaVentaEN lv129 = new LineaVentaEN();
                lv129.Cantidad = 1;
                lv129.Producto = productoCEN.GetProducto("119159-9500");

                IList<LineaVentaEN> Venta99_1 = new List<LineaVentaEN>();
                Venta99_1.Add(lv129);

                //Venta99       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta99_1);

                LineaVentaEN lv130 = new LineaVentaEN();
                lv130.Cantidad = 1;
                lv130.Producto = productoCEN.GetProducto("119159-9500");

                IList<LineaVentaEN> Venta100_1 = new List<LineaVentaEN>();
                Venta100_1.Add(lv130);

                //Venta100      

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("03/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta100_1);

                //Abril----------------------------------------------------------------------

                LineaVentaEN lv131 = new LineaVentaEN();
                lv131.Cantidad = 1;
                lv131.Producto = productoCEN.GetProducto("119159-9500");

                IList<LineaVentaEN> Venta101_1 = new List<LineaVentaEN>();
                Venta101_1.Add(lv131);

                //Venta101        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta101_1);


                LineaVentaEN lv132 = new LineaVentaEN();
                lv132.Cantidad = 1;
                lv132.Producto = productoCEN.GetProducto("D67002");

                IList<LineaVentaEN> Venta102_1 = new List<LineaVentaEN>();
                Venta102_1.Add(lv132);    

                //Venta102        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta102_1);

                LineaVentaEN lv133 = new LineaVentaEN();
                lv133.Cantidad = 1;
                lv133.Producto = productoCEN.GetProducto("D67002");

                IList<LineaVentaEN> Venta103_1 = new List<LineaVentaEN>();
                Venta103_1.Add(lv133);   
                

                //Venta103        
          
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta103_1);

                LineaVentaEN lv134 = new LineaVentaEN();
                lv134.Cantidad = 1;
                lv134.Producto = productoCEN.GetProducto("120517-5036");

                IList<LineaVentaEN> Venta104_1 = new List<LineaVentaEN>();
                Venta104_1.Add(lv134);

                //Venta104        
      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta104_1);

                LineaVentaEN lv135 = new LineaVentaEN();
                lv135.Cantidad = 1;
                lv135.Producto = productoCEN.GetProducto("120517-5036");

                IList<LineaVentaEN> Venta105_1 = new List<LineaVentaEN>();
                Venta105_1.Add(lv135);

                //Venta105

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta105_1);


                LineaVentaEN lv136 = new LineaVentaEN();
                lv136.Cantidad = 1;
                lv136.Producto = productoCEN.GetProducto("CV-532466C-D1");

                IList<LineaVentaEN> Venta106_1 = new List<LineaVentaEN>();
                Venta106_1.Add(lv136);

                //Venta106        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta106_1);

                LineaVentaEN lv137 = new LineaVentaEN();
                lv137.Cantidad = 1;
                lv137.Producto = productoCEN.GetProducto("CV-532466C-D1");

                IList<LineaVentaEN> Venta107_1 = new List<LineaVentaEN>();
                Venta107_1.Add(lv137);

               //Venta107        
               
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta107_1);

                LineaVentaEN lv138 = new LineaVentaEN();
                lv138.Cantidad = 1;
                lv138.Producto = productoCEN.GetProducto("CV-532466C-D1");

                IList<LineaVentaEN> Venta108_1 = new List<LineaVentaEN>();
                Venta108_1.Add(lv138);

                //Venta108        
    
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta108_1);
                
                
                LineaVentaEN lv139 = new LineaVentaEN();
                lv139.Cantidad = 12;
                lv139.Producto = productoCEN.GetProducto("O07606");

                IList<LineaVentaEN> Venta109_1 = new List<LineaVentaEN>();
                Venta109_1.Add(lv139);

                //Venta109       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta109_1);

                 
                LineaVentaEN lv140 = new LineaVentaEN();
                lv140.Cantidad = 1;
                lv140.Producto = productoCEN.GetProducto("F50632");

                IList<LineaVentaEN> Venta110_1 = new List<LineaVentaEN>();
                Venta110_1.Add(lv140);

                //Venta110        
           
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta110_1);

                LineaVentaEN lv141 = new LineaVentaEN();
                lv141.Cantidad = 1;
                lv141.Producto = productoCEN.GetProducto("CV-CKQ3107-MNT");

                IList<LineaVentaEN> Venta111_1 = new List<LineaVentaEN>();
                Venta111_1.Add(lv141);

                //Venta111        
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta111_1);

                   LineaVentaEN lv142 = new LineaVentaEN();
                lv142.Cantidad = 1;
                lv142.Producto = productoCEN.GetProducto("132974");

                IList<LineaVentaEN> Venta112_1 = new List<LineaVentaEN>();
                Venta112_1.Add(lv142);


                //Venta112       
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta112_1);

                LineaVentaEN lv143 = new LineaVentaEN();
                lv143.Cantidad = 1;
                lv143.Producto = productoCEN.GetProducto("132974");

                IList<LineaVentaEN> Venta113_1 = new List<LineaVentaEN>();
                Venta113_1.Add(lv143);

                //Venta113       
           
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta113_1);

                  LineaVentaEN lv144 = new LineaVentaEN();
                lv144.Cantidad = 2;
                lv144.Producto = productoCEN.GetProducto("132974");

                IList<LineaVentaEN> Venta114_1 = new List<LineaVentaEN>();
                Venta114_1.Add(lv144);

                //Venta114       
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta114_1);
                
            
                  LineaVentaEN lv145 = new LineaVentaEN();
                lv145.Cantidad = 1;
                lv145.Producto = productoCEN.GetProducto("122142-5000");

                IList<LineaVentaEN> Venta115_1 = new List<LineaVentaEN>();
                Venta115_1.Add(lv145);


                //Venta115       
               
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta115_1);

                  LineaVentaEN lv146 = new LineaVentaEN();
                lv146.Cantidad = 1;
                lv146.Producto = productoCEN.GetProducto("122142-5000");

                IList<LineaVentaEN> Venta116_1 = new List<LineaVentaEN>();
                Venta116_1.Add(lv146);

                //Venta116       
           
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta116_1);

                
                  LineaVentaEN lv147 = new LineaVentaEN();
                lv147.Cantidad = 1;
                lv147.Producto = productoCEN.GetProducto("122142-5000");

                IList<LineaVentaEN> Venta117_1 = new List<LineaVentaEN>();
                Venta117_1.Add(lv147);
            
                //Venta117       
               
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta117_1);

                    LineaVentaEN lv148 = new LineaVentaEN();
                lv148.Cantidad = 1;
                lv148.Producto = productoCEN.GetProducto("CV-CBGBP902-BK");

                IList<LineaVentaEN> Venta118_1 = new List<LineaVentaEN>();
                Venta118_1.Add(lv148);

                //Venta118       
           
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta118_1);

                LineaVentaEN lv149 = new LineaVentaEN();
                lv149.Cantidad = 1;
                lv149.Producto = productoCEN.GetProducto("CV-CBGBP902-BK");

                IList<LineaVentaEN> Venta119_1 = new List<LineaVentaEN>();
                Venta119_1.Add(lv149);

                //Venta119       
                
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta119_1);

                LineaVentaEN lv150 = new LineaVentaEN();
                lv150.Cantidad = 1;
                lv150.Producto = productoCEN.GetProducto("G65578");

                IList<LineaVentaEN> Venta120_1 = new List<LineaVentaEN>();
                Venta120_1.Add(lv150);

                //Vent120       
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta120_1);

                   LineaVentaEN lv151 = new LineaVentaEN();
                lv151.Cantidad = 1;
                lv151.Producto = productoCEN.GetProducto("G65578");

                IList<LineaVentaEN> Venta121_1 = new List<LineaVentaEN>();
                Venta121_1.Add(lv151);

                //Venta121       
                
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta121_1);

                LineaVentaEN lv152 = new LineaVentaEN();
                lv152.Cantidad = 1;
                lv152.Producto = productoCEN.GetProducto("G65578");

                IList<LineaVentaEN> Venta122_1 = new List<LineaVentaEN>();
                Venta122_1.Add(lv152);
                
                //Venta122       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta122_1);

                LineaVentaEN lv153 = new LineaVentaEN();
                lv153.Cantidad = 1;
                lv153.Producto = productoCEN.GetProducto("119221-9501");

                IList<LineaVentaEN> Venta123_1 = new List<LineaVentaEN>();
                Venta123_1.Add(lv153);

                //Venta123       
           
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta123_1);

                 LineaVentaEN lv154 = new LineaVentaEN();
                lv154.Cantidad = 1;
                lv154.Producto = productoCEN.GetProducto("C75631");

                IList<LineaVentaEN> Venta124_1 = new List<LineaVentaEN>();
                Venta124_1.Add(lv154);

                //Venta124      

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta124_1);

                LineaVentaEN lv155 = new LineaVentaEN();
                lv155.Cantidad = 1;
                lv155.Producto = productoCEN.GetProducto("CV-CWQ3206-VLT");

                IList<LineaVentaEN> Venta125_1 = new List<LineaVentaEN>();
                Venta125_1.Add(lv155);    

                //Venta125       
           
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta125_1);

                 LineaVentaEN lv156 = new LineaVentaEN();
                lv156.Cantidad = 1;
                lv156.Producto = productoCEN.GetProducto("CV-CWQ3206-VLT");

                IList<LineaVentaEN> Venta126_1 = new List<LineaVentaEN>();
                Venta126_1.Add(lv156);    

                //Venta126       
               
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta126_1);


                     LineaVentaEN lv157 = new LineaVentaEN();
                lv157.Cantidad = 1;
                lv157.Producto = productoCEN.GetProducto("CV-CWQ3206-VLT");

                IList<LineaVentaEN> Venta127_1 = new List<LineaVentaEN>();
                Venta127_1.Add(lv157);    


                //Venta127      

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta127_1);

                 LineaVentaEN lv158 = new LineaVentaEN();
                lv158.Cantidad = 1;
                lv158.Producto = productoCEN.GetProducto("119218-3000");

                IList<LineaVentaEN> Venta128_1 = new List<LineaVentaEN>();
                Venta128_1.Add(lv158);   

                //Venta128       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/25/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta128_1);

                  LineaVentaEN lv159 = new LineaVentaEN();
                lv159.Cantidad = 1;
                lv159.Producto = productoCEN.GetProducto("119218-3000");

                IList<LineaVentaEN> Venta129_1 = new List<LineaVentaEN>();
                Venta129_1.Add(lv159);   

                //Venta129      

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/26/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta129_1);

                  LineaVentaEN lv160 = new LineaVentaEN();
                lv160.Cantidad = 1;
                lv160.Producto = productoCEN.GetProducto("120514-5015");

                IList<LineaVentaEN> Venta130_1 = new List<LineaVentaEN>();
                Venta130_1.Add(lv160);   

                //Venta130      
       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("04/29/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta130_1);

                   LineaVentaEN lv161 = new LineaVentaEN();
                lv161.Cantidad = 1;
                lv161.Producto = productoCEN.GetProducto("120514-5015");

                IList<LineaVentaEN> Venta131_1 = new List<LineaVentaEN>();
                Venta131_1.Add(lv160);   

                //Mayo-----------------------------------------------------------------------
                
                
                //Venta131        
                
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta131_1);

                LineaVentaEN lv162 = new LineaVentaEN();
                lv162.Cantidad = 1;
                lv162.Producto = productoCEN.GetProducto("F50487");

                IList<LineaVentaEN> Venta132_1 = new List<LineaVentaEN>();
                Venta132_1.Add(lv162);   


                //Venta132        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta132_1);

                     LineaVentaEN lv163 = new LineaVentaEN();
                lv163.Cantidad = 1;
                lv163.Producto = productoCEN.GetProducto("M29916");

                IList<LineaVentaEN> Venta133_1 = new List<LineaVentaEN>();
                Venta133_1.Add(lv163); 
                

                //Venta133        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta133_1);


                 LineaVentaEN lv164 = new LineaVentaEN();
                lv164.Cantidad = 1;
                lv164.Producto = productoCEN.GetProducto("M29916");

                IList<LineaVentaEN> Venta134_1 = new List<LineaVentaEN>();
                Venta134_1.Add(lv164);     

               

                //venta134        
       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta134_1);

                 LineaVentaEN lv165 = new LineaVentaEN();
                lv165.Cantidad = 1;
                lv165.Producto = productoCEN.GetProducto("120539-9020");

                IList<LineaVentaEN> Venta135_1 = new List<LineaVentaEN>();
                Venta135_1.Add(lv165); 
                
                //venta135

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta135_1);

                 LineaVentaEN lv166 = new LineaVentaEN();
                lv166.Cantidad = 1;
                lv166.Producto = productoCEN.GetProducto("120539-9020");

                IList<LineaVentaEN> Venta136_1 = new List<LineaVentaEN>();
                Venta136_1.Add(lv166); 

                //venta136        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta136_1);

                  LineaVentaEN lv167 = new LineaVentaEN();
                lv167.Cantidad = 1;
                lv167.Producto = productoCEN.GetProducto("120539-9020");

                IList<LineaVentaEN> Venta137_1 = new List<LineaVentaEN>();
                Venta137_1.Add(lv167); 

                //venta137        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta137_1);

                   LineaVentaEN lv168 = new LineaVentaEN();
                lv168.Cantidad = 1;
                lv168.Producto = productoCEN.GetProducto("122142-5000");

                IList<LineaVentaEN> Venta138_1 = new List<LineaVentaEN>();
                Venta138_1.Add(lv168); 

                //venta138        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta138_1);

                 LineaVentaEN lv169 = new LineaVentaEN();
                lv169.Cantidad = 1;
                lv169.Producto = productoCEN.GetProducto("122142-5000");

                IList<LineaVentaEN> Venta139_1 = new List<LineaVentaEN>();
                Venta139_1.Add(lv169); 

                //venta139       
            
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta139_1);

                
                 LineaVentaEN lv170 = new LineaVentaEN();
                lv170.Cantidad = 3;
                lv170.Producto = productoCEN.GetProducto("122142-5000");

                IList<LineaVentaEN> Venta140_1 = new List<LineaVentaEN>();
                Venta140_1.Add(lv170); 

                //venta140        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta140_1);

                   
                 LineaVentaEN lv171 = new LineaVentaEN();
                lv171.Cantidad = 3;
                lv171.Producto = productoCEN.GetProducto("120860-9500");

                IList<LineaVentaEN> Venta141_1 = new List<LineaVentaEN>();
                Venta141_1.Add(lv171); 

                //venta141        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta141_1);

                  LineaVentaEN lv172 = new LineaVentaEN();
                lv172.Cantidad = 3;
                lv172.Producto = productoCEN.GetProducto("122243-5005");

                IList<LineaVentaEN> Venta142_1 = new List<LineaVentaEN>();
                Venta142_1.Add(lv172); 

                //venta142       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta142_1);

                 LineaVentaEN lv173 = new LineaVentaEN();
                lv173.Cantidad = 1;
                lv173.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                IList<LineaVentaEN> Venta143_1 = new List<LineaVentaEN>();
                Venta143_1.Add(lv173); 

                //venta143       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta143_1);

                LineaVentaEN lv174 = new LineaVentaEN();
                lv174.Cantidad = 1;
                lv174.Producto = productoCEN.GetProducto("CV-7J236-I1");

                IList<LineaVentaEN> Venta144_1 = new List<LineaVentaEN>();
                Venta144_1.Add(lv174);

                //venta144       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta144_1);

                
                LineaVentaEN lv175 = new LineaVentaEN();
                lv175.Cantidad = 2;
                lv175.Producto = productoCEN.GetProducto("CV-7J236-I1");

                IList<LineaVentaEN> Venta145_1 = new List<LineaVentaEN>();
                Venta145_1.Add(lv175);

                //venta145       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta145_1);

                LineaVentaEN lv176 = new LineaVentaEN();
                lv176.Cantidad = 2;
                lv176.Producto = productoCEN.GetProducto("CV-CWR5511-BK");

                IList<LineaVentaEN> Venta146_1 = new List<LineaVentaEN>();
                Venta146_1.Add(lv176);

                //venta146       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta146_1);

                LineaVentaEN lv177 = new LineaVentaEN();
                lv177.Cantidad = 2;
                lv177.Producto = productoCEN.GetProducto("CV-CSCR205-BK");

                IList<LineaVentaEN> Venta147_1 = new List<LineaVentaEN>();
                Venta147_1.Add(lv177);

                //venta147       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta147_1);

                
                LineaVentaEN lv178 = new LineaVentaEN();
                lv178.Cantidad = 2;
                lv178.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta148_1 = new List<LineaVentaEN>();
                Venta148_1.Add(lv178);

                //venta148       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta148_1);

                      LineaVentaEN lv179 = new LineaVentaEN();
                lv179.Cantidad = 2;
                lv179.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta149_1 = new List<LineaVentaEN>();
                Venta149_1.Add(lv179);

                //venta149       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta149_1);

                      LineaVentaEN lv180 = new LineaVentaEN();
                lv180.Cantidad = 2;
                lv180.Producto = productoCEN.GetProducto("D67836");

                IList<LineaVentaEN> Venta150_1 = new List<LineaVentaEN>();
                Venta150_1.Add(lv180);

                //venta150       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta150_1);

                      LineaVentaEN lv181 = new LineaVentaEN();
                lv181.Cantidad = 2;
                lv181.Producto = productoCEN.GetProducto("Z73940");

                IList<LineaVentaEN> Venta151_1 = new List<LineaVentaEN>();
                Venta151_1.Add(lv181);

                //venta151       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta151_1);

                      LineaVentaEN lv182 = new LineaVentaEN();
                lv182.Cantidad = 2;
                lv182.Producto = productoCEN.GetProducto("Z73940");

                IList<LineaVentaEN> Venta152_1 = new List<LineaVentaEN>();
                Venta152_1.Add(lv182);
                
                //venta152       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta152_1);

                      LineaVentaEN lv183 = new LineaVentaEN();
                lv183.Cantidad = 2;
                lv183.Producto = productoCEN.GetProducto("Z73940");

                IList<LineaVentaEN> Venta153_1 = new List<LineaVentaEN>();
                Venta153_1.Add(lv183);

                //venta153       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta153_1);

                      LineaVentaEN lv184 = new LineaVentaEN();
                lv184.Cantidad = 2;
                lv184.Producto = productoCEN.GetProducto("F50486");

                IList<LineaVentaEN> Venta154_1 = new List<LineaVentaEN>();
                Venta154_1.Add(lv184);

                //venta154      

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta154_1);
                    
                      LineaVentaEN lv185 = new LineaVentaEN();
                lv185.Cantidad = 2;
                lv185.Producto = productoCEN.GetProducto("F50486");

                IList<LineaVentaEN> Venta155_1 = new List<LineaVentaEN>();
                Venta155_1.Add(lv185);
                
                //venta155       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta155_1);

                      LineaVentaEN lv186 = new LineaVentaEN();
                lv186.Cantidad = 2;
                lv186.Producto = productoCEN.GetProducto("O07587");

                IList<LineaVentaEN> Venta156_1 = new List<LineaVentaEN>();
                Venta156_1.Add(lv186);

                //venta156       
 
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta156_1);

                      LineaVentaEN lv187 = new LineaVentaEN();
                lv187.Cantidad = 2;
                lv187.Producto = productoCEN.GetProducto("O07587");

                IList<LineaVentaEN> Venta157_1 = new List<LineaVentaEN>();
                Venta157_1.Add(lv187);

                //venta157      

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta157_1);

                      LineaVentaEN lv188 = new LineaVentaEN();
                lv188.Cantidad = 2;
                lv188.Producto = productoCEN.GetProducto("O07587");

                IList<LineaVentaEN> Venta158_1 = new List<LineaVentaEN>();
                Venta158_1.Add(lv188);
                
                //venta158       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/25/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta158_1);

                      LineaVentaEN lv189 = new LineaVentaEN();
                lv189.Cantidad = 2;
                lv189.Producto = productoCEN.GetProducto("O07587");

                IList<LineaVentaEN> Venta159_1 = new List<LineaVentaEN>();
                Venta159_1.Add(lv189);

                //venta159      

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/26/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta159_1);

                      LineaVentaEN lv190 = new LineaVentaEN();
                lv190.Cantidad = 2;
                lv190.Producto = productoCEN.GetProducto("119213-5162");

                IList<LineaVentaEN> Venta160_1 = new List<LineaVentaEN>();
                Venta160_1.Add(lv190);

                //venta160      

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/29/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta160_1);

                      LineaVentaEN lv191 = new LineaVentaEN();
                lv191.Cantidad = 2;
                lv191.Producto = productoCEN.GetProducto("119213-5162");

                IList<LineaVentaEN> Venta161_1 = new List<LineaVentaEN>();
                Venta161_1.Add(lv191);

                //venta161       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/30/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta161_1);

                      LineaVentaEN lv192 = new LineaVentaEN();
                lv192.Cantidad = 2;
                lv192.Producto = productoCEN.GetProducto("119213-5162");

                IList<LineaVentaEN> Venta162_1 = new List<LineaVentaEN>();
                Venta162_1.Add(lv192);

                //venta162     

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/30/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta162_1);

                      LineaVentaEN lv193 = new LineaVentaEN();
                lv193.Cantidad = 2;
                lv193.Producto = productoCEN.GetProducto("119213-5162");

                IList<LineaVentaEN> Venta163_1 = new List<LineaVentaEN>();
                Venta163_1.Add(lv193);

                //venta163      

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("05/30/2015 17:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta163_1);
                
                //Junio----------------------------------------------------------------------

                      LineaVentaEN lv194 = new LineaVentaEN();
                lv194.Cantidad = 2;
                lv194.Producto = productoCEN.GetProducto("D67233");

                IList<LineaVentaEN> Venta164_1 = new List<LineaVentaEN>();
                Venta164_1.Add(lv194);

                //venta164        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta164_1);

                      LineaVentaEN lv195 = new LineaVentaEN();
                lv195.Cantidad = 2;
                lv195.Producto = productoCEN.GetProducto("D67233");

                IList<LineaVentaEN> Venta165_1 = new List<LineaVentaEN>();
                Venta165_1.Add(lv195);

                //venta165        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta165_1);

                      LineaVentaEN lv196 = new LineaVentaEN();
                lv196.Cantidad = 2;
                lv196.Producto = productoCEN.GetProducto("D67233");

                IList<LineaVentaEN> Venta166_1 = new List<LineaVentaEN>();
                Venta166_1.Add(lv196);

                //venta166        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta166_1);

                      LineaVentaEN lv197 = new LineaVentaEN();
                lv197.Cantidad = 2;
                lv197.Producto = productoCEN.GetProducto("D67233");

                IList<LineaVentaEN> Venta167_1 = new List<LineaVentaEN>();
                Venta167_1.Add(lv197);

                //venta167        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta167_1);
                
                  LineaVentaEN lv198 = new LineaVentaEN();
                lv198.Cantidad = 2;
                lv198.Producto = productoCEN.GetProducto("F50636");

                IList<LineaVentaEN> Venta168_1 = new List<LineaVentaEN>();
                Venta168_1.Add(lv198);

                //venta168
              
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta168_1);

                      LineaVentaEN lv199 = new LineaVentaEN();
                lv199.Cantidad = 2;
                lv199.Producto = productoCEN.GetProducto("F50636");

                IList<LineaVentaEN> Venta169_1 = new List<LineaVentaEN>();
                Venta169_1.Add(lv199);

                //venta169        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta169_1);

                      LineaVentaEN lv200 = new LineaVentaEN();
                lv200.Cantidad = 2;
                lv200.Producto = productoCEN.GetProducto("120861-7185");

                IList<LineaVentaEN> Venta170_1 = new List<LineaVentaEN>();
                Venta170_1.Add(lv200);

                //venta170        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta170_1);

                      LineaVentaEN lv201 = new LineaVentaEN();
                lv201.Cantidad = 2;
                lv201.Producto = productoCEN.GetProducto("120861-7185");

                IList<LineaVentaEN> Venta171_1 = new List<LineaVentaEN>();
                Venta171_1.Add(lv201);

                //venta171        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta171_1);

                      LineaVentaEN lv202 = new LineaVentaEN();
                lv202.Cantidad = 2;
                lv202.Producto = productoCEN.GetProducto("120861-7185");

                IList<LineaVentaEN> Venta172_1 = new List<LineaVentaEN>();
                Venta172_1.Add(lv202);

                //venta172       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta172_1);

                      LineaVentaEN lv203 = new LineaVentaEN();
                lv203.Cantidad = 2;
                lv203.Producto = productoCEN.GetProducto("119153-9501");

                IList<LineaVentaEN> Venta173_1 = new List<LineaVentaEN>();
                Venta173_1.Add(lv203);

                //venta173        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta173_1);

                      LineaVentaEN lv204 = new LineaVentaEN();
                lv204.Cantidad = 2;
                lv204.Producto = productoCEN.GetProducto("119153-9501");

                IList<LineaVentaEN> Venta174_1 = new List<LineaVentaEN>();
                Venta174_1.Add(lv204);

                //venta174        

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta174_1);

                      LineaVentaEN lv205 = new LineaVentaEN();
                lv205.Cantidad = 2;
                lv205.Producto = productoCEN.GetProducto("120860-9500");

                IList<LineaVentaEN> Venta175_1 = new List<LineaVentaEN>();
                Venta175_1.Add(lv205);

                //venta175       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta175_1);

                      LineaVentaEN lv206 = new LineaVentaEN();
                lv206.Cantidad = 2;
                lv206.Producto = productoCEN.GetProducto("120860-9500");

                IList<LineaVentaEN> Venta176_1 = new List<LineaVentaEN>();
                Venta176_1.Add(lv206);

                //venta176       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta176_1);

                      LineaVentaEN lv207 = new LineaVentaEN();
                lv207.Cantidad = 2;
                lv207.Producto = productoCEN.GetProducto("O07612");

                IList<LineaVentaEN> Venta177_1 = new List<LineaVentaEN>();
                Venta177_1.Add(lv207);

                //venta177       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta177_1);

                      LineaVentaEN lv208 = new LineaVentaEN();
                lv208.Cantidad = 2;
                lv208.Producto = productoCEN.GetProducto("O07612");

                IList<LineaVentaEN> Venta178_1 = new List<LineaVentaEN>();
                Venta178_1.Add(lv208);

                //venta178       
             
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta178_1);

                      LineaVentaEN lv209 = new LineaVentaEN();
                lv209.Cantidad = 2;
                lv209.Producto = productoCEN.GetProducto("CV-CS104-MIL");

                IList<LineaVentaEN> Venta179_1 = new List<LineaVentaEN>();
                Venta179_1.Add(lv209);

                //venta179       
 
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta179_1);

                      LineaVentaEN lv210 = new LineaVentaEN();
                lv210.Cantidad = 2;
                lv210.Producto = productoCEN.GetProducto("CV-CS104-MIL");

                IList<LineaVentaEN> Venta180_1 = new List<LineaVentaEN>();
                Venta180_1.Add(lv210);

                //venta180       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta180_1);

                      LineaVentaEN lv211 = new LineaVentaEN();
                lv211.Cantidad = 2;
                lv211.Producto = productoCEN.GetProducto("CV-CS104-MIL");

                IList<LineaVentaEN> Venta181_1 = new List<LineaVentaEN>();
                Venta181_1.Add(lv211);

                //venta181       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta181_1);

                      LineaVentaEN lv212 = new LineaVentaEN();
                lv212.Cantidad = 2;
                lv212.Producto = productoCEN.GetProducto("119156-9500");

                IList<LineaVentaEN> Venta182_1 = new List<LineaVentaEN>();
                Venta182_1.Add(lv212);

                //venta182       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta182_1);

                      LineaVentaEN lv213 = new LineaVentaEN();
                lv213.Cantidad = 2;
                lv213.Producto = productoCEN.GetProducto("119156-9500");

                IList<LineaVentaEN> Venta183_1 = new List<LineaVentaEN>();
                Venta183_1.Add(lv213);

                //venta183       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("06/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta183_1);

                      LineaVentaEN lv214 = new LineaVentaEN();
                lv214.Cantidad = 2;
                lv214.Producto = productoCEN.GetProducto("119156-9500");

                IList<LineaVentaEN> Venta184_1 = new List<LineaVentaEN>();
                Venta184_1.Add(lv214);

                //Julio----------------------------------------------------------------------

                //venta184        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta184_1);

                  LineaVentaEN lv215 = new LineaVentaEN();
                lv215.Cantidad = 1;
                lv215.Producto = productoCEN.GetProducto("119217-9500");

                IList<LineaVentaEN> Venta185_1 = new List<LineaVentaEN>();
                Venta185_1.Add(lv215);

                //venta185        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta185_1);
                
                      LineaVentaEN lv216 = new LineaVentaEN();
                lv216.Cantidad = 1;
                lv216.Producto = productoCEN.GetProducto("119217-9500");

                IList<LineaVentaEN> Venta186_1 = new List<LineaVentaEN>();
                Venta186_1.Add(lv216);

                //venta186        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta186_1);

                      LineaVentaEN lv217 = new LineaVentaEN();
                lv217.Cantidad = 1;
                lv217.Producto = productoCEN.GetProducto("M29605");

                IList<LineaVentaEN> Venta187_1 = new List<LineaVentaEN>();
                Venta187_1.Add(lv217);

                //venta187        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta187_1);

                      LineaVentaEN lv218 = new LineaVentaEN();
                lv218.Cantidad = 1;
                lv218.Producto = productoCEN.GetProducto("M29605");

                IList<LineaVentaEN> Venta188_1 = new List<LineaVentaEN>();
                Venta188_1.Add(lv218);

                //venta188
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta188_1);

                      LineaVentaEN lv219 = new LineaVentaEN();
                lv219.Cantidad = 1;
                lv219.Producto = productoCEN.GetProducto("M29605");

                IList<LineaVentaEN> Venta189_1 = new List<LineaVentaEN>();
                Venta189_1.Add(lv219);

                //venta189        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta189_1);
                
                      LineaVentaEN lv220 = new LineaVentaEN();
                lv220.Cantidad = 1;
                lv220.Producto = productoCEN.GetProducto("L44750");

                IList<LineaVentaEN> Venta190_1 = new List<LineaVentaEN>();
                Venta190_1.Add(lv220);

                //venta190        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/03/2015 19:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta190_1);

                      LineaVentaEN lv221 = new LineaVentaEN();
                lv221.Cantidad = 1;
                lv221.Producto = productoCEN.GetProducto("L44750");

                IList<LineaVentaEN> Venta191_1 = new List<LineaVentaEN>();
                Venta191_1.Add(lv221);

                //venta191        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta191_1);

                      LineaVentaEN lv222 = new LineaVentaEN();
                lv222.Cantidad = 1;
                lv222.Producto = productoCEN.GetProducto("L44750");

                IList<LineaVentaEN> Venta192_1 = new List<LineaVentaEN>();
                Venta192_1.Add(lv222);

                //venta192       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta192_1);

                      LineaVentaEN lv223 = new LineaVentaEN();
                lv223.Cantidad = 1;
                lv223.Producto = productoCEN.GetProducto("122241-5004");

                IList<LineaVentaEN> Venta193_1 = new List<LineaVentaEN>();
                Venta193_1.Add(lv223);

                //venta193        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta193_1);

                      LineaVentaEN lv224 = new LineaVentaEN();
                lv224.Cantidad = 1;
                lv224.Producto = productoCEN.GetProducto("122241-5004");

                IList<LineaVentaEN> Venta194_1 = new List<LineaVentaEN>();
                Venta194_1.Add(lv224);

                //venta194        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta194_1);

                      LineaVentaEN lv225 = new LineaVentaEN();
                lv225.Cantidad = 1;
                lv225.Producto = productoCEN.GetProducto("CV-532466C-D1");

                IList<LineaVentaEN> Venta195_1 = new List<LineaVentaEN>();
                Venta195_1.Add(lv225);

                //venta195       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta195_1);

                      LineaVentaEN lv226 = new LineaVentaEN();
                lv226.Cantidad = 1;
                lv226.Producto = productoCEN.GetProducto("CV-532466C-D1");

                IList<LineaVentaEN> Venta196_1 = new List<LineaVentaEN>();
                Venta196_1.Add(lv226);

                //venta196       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta196_1);

                      LineaVentaEN lv227 = new LineaVentaEN();
                lv227.Cantidad = 1;
                lv227.Producto = productoCEN.GetProducto("CV-117381-AS1");

                IList<LineaVentaEN> Venta197_1 = new List<LineaVentaEN>();
                Venta197_1.Add(lv227);

                //venta197        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta197_1);

                      LineaVentaEN lv228 = new LineaVentaEN();
                lv228.Cantidad = 1;
                lv228.Producto = productoCEN.GetProducto("CV-117381-AS1");

                IList<LineaVentaEN> Venta198_1 = new List<LineaVentaEN>();
                Venta198_1.Add(lv228);

                //venta198       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta198_1);

                      LineaVentaEN lv229 = new LineaVentaEN();
                lv229.Cantidad = 1;
                lv229.Producto = productoCEN.GetProducto("122242-7006");

                IList<LineaVentaEN> Venta199_1 = new List<LineaVentaEN>();
                Venta199_1.Add(lv229);

                //venta199       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta199_1);

                      LineaVentaEN lv230 = new LineaVentaEN();
                lv230.Cantidad = 1;
                lv230.Producto = productoCEN.GetProducto("122242-7006");

                IList<LineaVentaEN> Venta200_1 = new List<LineaVentaEN>();
                Venta200_1.Add(lv230);

                //venta200       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta200_1);

                      LineaVentaEN lv231 = new LineaVentaEN();
                lv231.Cantidad = 1;
                lv231.Producto = productoCEN.GetProducto("122242-7006");

                IList<LineaVentaEN> Venta201_1 = new List<LineaVentaEN>();
                Venta201_1.Add(lv231);

                //venta201       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta201_1);

                      LineaVentaEN lv232 = new LineaVentaEN();
                lv232.Cantidad = 1;
                lv232.Producto = productoCEN.GetProducto("122242-7006");

                IList<LineaVentaEN> Venta202_1 = new List<LineaVentaEN>();
                Venta202_1.Add(lv232);

                //venta202       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta202_1);

                      LineaVentaEN lv233 = new LineaVentaEN();
                lv233.Cantidad = 1;
                lv233.Producto = productoCEN.GetProducto("122242-7006");

                IList<LineaVentaEN> Venta203_1 = new List<LineaVentaEN>();
                Venta203_1.Add(lv233);

                //Vent93       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta203_1);

                      LineaVentaEN lv234 = new LineaVentaEN();
                lv234.Cantidad = 1;
                lv234.Producto = productoCEN.GetProducto("120517-5036");

                IList<LineaVentaEN> Venta204_1 = new List<LineaVentaEN>();
                Venta204_1.Add(lv234);

                //venta204       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta204_1);

                      LineaVentaEN lv235 = new LineaVentaEN();
                lv235.Cantidad = 1;
                lv235.Producto = productoCEN.GetProducto("120517-5036");

                IList<LineaVentaEN> Venta205_1 = new List<LineaVentaEN>();
                Venta205_1.Add(lv235);

                //venta205       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta205_1);
            
                      LineaVentaEN lv236 = new LineaVentaEN();
                lv236.Cantidad = 1;
                lv236.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta206_1 = new List<LineaVentaEN>();
                Venta206_1.Add(lv236);

                //venta206       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta206_1);

                      LineaVentaEN lv237 = new LineaVentaEN();
                lv237.Cantidad = 1;
                lv237.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta207_1 = new List<LineaVentaEN>();
                Venta207_1.Add(lv237);

                //venta207      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta207_1);

                      LineaVentaEN lv238 = new LineaVentaEN();
                lv238.Cantidad = 1;
                lv238.Producto = productoCEN.GetProducto("D73804");

                IList<LineaVentaEN> Venta208_1 = new List<LineaVentaEN>();
                Venta208_1.Add(lv238);

                //venta208       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta208_1);

                      LineaVentaEN lv239 = new LineaVentaEN();
                lv239.Cantidad = 1;
                lv239.Producto = productoCEN.GetProducto("D73804");

                IList<LineaVentaEN> Venta209_1 = new List<LineaVentaEN>();
                Venta209_1.Add(lv239);

                //venta209       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta209_1);

                      LineaVentaEN lv240 = new LineaVentaEN();
                lv240.Cantidad = 1;
                lv240.Producto = productoCEN.GetProducto("D73804");

                IList<LineaVentaEN> Venta210_1 = new List<LineaVentaEN>();
                Venta210_1.Add(lv240);
                
                //venta210      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("07/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta210_1);

                      LineaVentaEN lv241 = new LineaVentaEN();
                lv241.Cantidad = 1;
                lv241.Producto = productoCEN.GetProducto("F38433");

                IList<LineaVentaEN> Venta211_1 = new List<LineaVentaEN>();
                Venta211_1.Add(lv241);

                //Agosto---------------------------------------------------------------------

                //venta211        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta211_1);

                      LineaVentaEN lv242 = new LineaVentaEN();
                lv242.Cantidad = 2;
                lv242.Producto = productoCEN.GetProducto("F38433");

                IList<LineaVentaEN> Venta212_1 = new List<LineaVentaEN>();
                Venta212_1.Add(lv242);

                //venta212        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta212_1);

                      LineaVentaEN lv243 = new LineaVentaEN();
                lv243.Cantidad = 2;
                lv243.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta213_1 = new List<LineaVentaEN>();
                Venta213_1.Add(lv243);

                //venta213        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta213_1);

                      LineaVentaEN lv244 = new LineaVentaEN();
                lv244.Cantidad = 2;
                lv244.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta214_1 = new List<LineaVentaEN>();
                Venta214_1.Add(lv244);

                //venta214        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta214_1);

                      LineaVentaEN lv245 = new LineaVentaEN();
                lv245.Cantidad = 2;
                lv245.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta215_1 = new List<LineaVentaEN>();
                Venta215_1.Add(lv245);

                //venta215
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta215_1);

                      LineaVentaEN lv246 = new LineaVentaEN();
                lv246.Cantidad = 2;
                lv246.Producto = productoCEN.GetProducto("O07596");

                IList<LineaVentaEN> Venta216_1 = new List<LineaVentaEN>();
                Venta216_1.Add(lv246);

                //venta216        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta216_1);

                      LineaVentaEN lv247 = new LineaVentaEN();
                lv247.Cantidad = 2;
                lv247.Producto = productoCEN.GetProducto("O07596");

                IList<LineaVentaEN> Venta217_1 = new List<LineaVentaEN>();
                Venta217_1.Add(lv247);

                //venta217        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta217_1);

                      LineaVentaEN lv248 = new LineaVentaEN();
                lv248.Cantidad = 2;
                lv248.Producto = productoCEN.GetProducto("119221-7185");

                IList<LineaVentaEN> Venta218_1 = new List<LineaVentaEN>();
                Venta218_1.Add(lv248);

                //venta218        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta218_1);


                      LineaVentaEN lv249 = new LineaVentaEN();
                lv249.Cantidad = 2;
                lv249.Producto = productoCEN.GetProducto("119221-7185");

                IList<LineaVentaEN> Venta219_1 = new List<LineaVentaEN>();
                Venta219_1.Add(lv249);

                //venta219       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta219_1);

                      LineaVentaEN lv250 = new LineaVentaEN();
                lv250.Cantidad = 2;
                lv250.Producto = productoCEN.GetProducto("119221-7185");

                IList<LineaVentaEN> Venta220_1 = new List<LineaVentaEN>();
                Venta220_1.Add(lv250);

                //venta220        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta220_1);

                      LineaVentaEN lv251 = new LineaVentaEN();
                lv251.Cantidad = 2;
                lv251.Producto = productoCEN.GetProducto("F50632");

                IList<LineaVentaEN> Venta221_1 = new List<LineaVentaEN>();
                Venta221_1.Add(lv251);

                //venta221        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta221_1);

                      LineaVentaEN lv252 = new LineaVentaEN();
                lv252.Cantidad = 2;
                lv252.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta222_1 = new List<LineaVentaEN>();
                Venta222_1.Add(lv252);

                //venta222       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta222_1);

                      LineaVentaEN lv253 = new LineaVentaEN();
                lv253.Cantidad = 2;
                lv253.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta223_1 = new List<LineaVentaEN>();
                Venta223_1.Add(lv253);

                //venta223       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta223_1);

                      LineaVentaEN lv254 = new LineaVentaEN();
                lv254.Cantidad = 2;
                lv254.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta224_1 = new List<LineaVentaEN>();
                Venta224_1.Add(lv254);
                
                //venta224        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta224_1);


                      LineaVentaEN lv255 = new LineaVentaEN();
                lv255.Cantidad = 2;
                lv255.Producto = productoCEN.GetProducto("119215-5162");

                IList<LineaVentaEN> Venta225_1 = new List<LineaVentaEN>();
                Venta225_1.Add(lv255);

                //venta225       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta224_1);

                      LineaVentaEN lv256 = new LineaVentaEN();
                lv256.Cantidad = 2;
                lv256.Producto = productoCEN.GetProducto("119215-5162");

                IList<LineaVentaEN> Venta226_1 = new List<LineaVentaEN>();
                Venta226_1.Add(lv256);
    

                //venta226       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta225_1);

                      LineaVentaEN lv257 = new LineaVentaEN();
                lv257.Cantidad = 2;
                lv257.Producto = productoCEN.GetProducto("F50632");

                IList<LineaVentaEN> Venta227_1 = new List<LineaVentaEN>();
                Venta227_1.Add(lv257);

                //venta227       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("08/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta226_1);

                      LineaVentaEN lv258 = new LineaVentaEN();
                lv258.Cantidad = 2;
                lv258.Producto = productoCEN.GetProducto("F50632");

                IList<LineaVentaEN> Venta228_1 = new List<LineaVentaEN>();
                Venta228_1.Add(lv258);
                
                //Septiembre-----------------------------------------------------------------

                //venta228      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta228_1);
                
                      LineaVentaEN lv259 = new LineaVentaEN();
                lv259.Cantidad = 1;
                lv259.Producto = productoCEN.GetProducto("119215-5162");

                IList<LineaVentaEN> Venta229_1 = new List<LineaVentaEN>();
                Venta229_1.Add(lv259);
                
                //venta229        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/05/2015 16:56:22", System.Globalization.CultureInfo.InvariantCulture), Venta229_1);

                  LineaVentaEN lv260 = new LineaVentaEN();
                lv260.Cantidad = 1;
                lv260.Producto = productoCEN.GetProducto("119215-5162");

                IList<LineaVentaEN> Venta230_1 = new List<LineaVentaEN>();
                Venta230_1.Add(lv260);

                //venta230        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/08/2015 11:02:11", System.Globalization.CultureInfo.InvariantCulture), Venta230_1);

                      LineaVentaEN lv261 = new LineaVentaEN();
                lv261.Cantidad = 1;
                lv261.Producto = productoCEN.GetProducto("F50633");

                IList<LineaVentaEN> Venta231_1 = new List<LineaVentaEN>();
                Venta231_1.Add(lv261);

                //venta231        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/09/2015 12:02:10", System.Globalization.CultureInfo.InvariantCulture), Venta231_1);

                      LineaVentaEN lv262 = new LineaVentaEN();
                lv262.Cantidad = 1;
                lv262.Producto = productoCEN.GetProducto("F50633");

                IList<LineaVentaEN> Venta232_1 = new List<LineaVentaEN>();
                Venta232_1.Add(lv262);

                //venta232        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta232_1);

                      LineaVentaEN lv263 = new LineaVentaEN();
                lv263.Cantidad = 1;
                lv263.Producto = productoCEN.GetProducto("Q23904");

                IList<LineaVentaEN> Venta233_1 = new List<LineaVentaEN>();
                Venta233_1.Add(lv263);

                //venta233        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/09/2015 18:00:10", System.Globalization.CultureInfo.InvariantCulture), Venta233_1);

                      LineaVentaEN lv264 = new LineaVentaEN();
                lv264.Cantidad = 1;
                lv264.Producto = productoCEN.GetProducto("Q23904");

                IList<LineaVentaEN> Venta234_1 = new List<LineaVentaEN>();
                Venta234_1.Add(lv264);

                //venta234        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/12/2015 10:45:10", System.Globalization.CultureInfo.InvariantCulture), Venta234_1);

                      LineaVentaEN lv265 = new LineaVentaEN();
                lv265.Cantidad = 1;
                lv265.Producto = productoCEN.GetProducto("Q23904");

                IList<LineaVentaEN> Venta235_1 = new List<LineaVentaEN>();
                Venta235_1.Add(lv265);

                //venta235        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/12/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta235_1);

                      LineaVentaEN lv266 = new LineaVentaEN();
                lv266.Cantidad = 1;
                lv266.Producto = productoCEN.GetProducto("CV-CWR2609-PP");

                IList<LineaVentaEN> Venta236_1 = new List<LineaVentaEN>();
                Venta236_1.Add(lv266);

                //venta236        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/14/2015 14:02:10", System.Globalization.CultureInfo.InvariantCulture), Venta236_1);

                      LineaVentaEN lv267 = new LineaVentaEN();
                lv267.Cantidad = 1;
                lv267.Producto = productoCEN.GetProducto("CV-CWR2609-PP");

                IList<LineaVentaEN> Venta237_1 = new List<LineaVentaEN>();
                Venta237_1.Add(lv267);

                //venta237        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/14/2015 19:30:25", System.Globalization.CultureInfo.InvariantCulture), Venta237_1);

                      LineaVentaEN lv268 = new LineaVentaEN();
                lv268.Cantidad = 1;
                lv268.Producto = productoCEN.GetProducto("CV-CWR2609-PP");

                IList<LineaVentaEN> Venta238_1 = new List<LineaVentaEN>();
                Venta238_1.Add(lv268);

                //venta238        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/16/2015 09:30:12", System.Globalization.CultureInfo.InvariantCulture), Venta238_1);

                      LineaVentaEN lv269 = new LineaVentaEN();
                lv269.Cantidad = 1;
                lv269.Producto = productoCEN.GetProducto("CV-CWR2609-PP");

                IList<LineaVentaEN> Venta239_1 = new List<LineaVentaEN>();
                Venta239_1.Add(lv269);

                //venta239        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta239_1);

                      LineaVentaEN lv270 = new LineaVentaEN();
                lv270.Cantidad = 1;
                lv270.Producto = productoCEN.GetProducto("Q33811");

                IList<LineaVentaEN> Venta240_1 = new List<LineaVentaEN>();
                Venta240_1.Add(lv270);

                //venta240       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/18/2015 14:22:30", System.Globalization.CultureInfo.InvariantCulture), Venta240_1);

                      LineaVentaEN lv271 = new LineaVentaEN();
                lv271.Cantidad = 1;
                lv271.Producto = productoCEN.GetProducto("Q33811");

                IList<LineaVentaEN> Venta241_1 = new List<LineaVentaEN>();
                Venta241_1.Add(lv271);

                //venta241     
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/18/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta241_1);

                      LineaVentaEN lv272 = new LineaVentaEN();
                lv272.Cantidad = 1;
                lv272.Producto = productoCEN.GetProducto("Q33811");

                IList<LineaVentaEN> Venta242_1 = new List<LineaVentaEN>();
                Venta242_1.Add(lv272);

                //venta242       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/19/2015 11:28:10", System.Globalization.CultureInfo.InvariantCulture), Venta242_1);

                      LineaVentaEN lv273 = new LineaVentaEN();
                lv273.Cantidad = 1;
                lv273.Producto = productoCEN.GetProducto("Q33811");

                IList<LineaVentaEN> Venta243_1 = new List<LineaVentaEN>();
                Venta243_1.Add(lv273);

                //venta243       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/19/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta243_1);

                      LineaVentaEN lv274 = new LineaVentaEN();
                lv274.Cantidad = 1;
                lv274.Producto = productoCEN.GetProducto("122241-5004");

                IList<LineaVentaEN> Venta244_1 = new List<LineaVentaEN>();
                Venta244_1.Add(lv274);

                //venta244       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/19/2015 18:10:30", System.Globalization.CultureInfo.InvariantCulture), Venta244_1);

                      LineaVentaEN lv275 = new LineaVentaEN();
                lv275.Cantidad = 1;
                lv275.Producto = productoCEN.GetProducto("122241-5004");

                IList<LineaVentaEN> Venta245_1 = new List<LineaVentaEN>();
                Venta245_1.Add(lv275);

                //venta245       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/20/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta245_1);

                      LineaVentaEN lv276 = new LineaVentaEN();
                lv276.Cantidad = 1;
                lv276.Producto = productoCEN.GetProducto("122241-5004");

                IList<LineaVentaEN> Venta246_1 = new List<LineaVentaEN>();
                Venta246_1.Add(lv276);

                //venta246       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/21/2015 10:00:30", System.Globalization.CultureInfo.InvariantCulture), Venta246_1);


                      LineaVentaEN lv277 = new LineaVentaEN();
                lv277.Cantidad = 1;
                lv277.Producto = productoCEN.GetProducto("122241-5004");

                IList<LineaVentaEN> Venta247_1 = new List<LineaVentaEN>();
                Venta247_1.Add(lv277);

                //venta247       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/21/2015 13:00:13", System.Globalization.CultureInfo.InvariantCulture), Venta247_1);

                      LineaVentaEN lv278 = new LineaVentaEN();
                lv278.Cantidad = 1;
                lv278.Producto = productoCEN.GetProducto("119214-5162");

                IList<LineaVentaEN> Venta248_1 = new List<LineaVentaEN>();
                Venta248_1.Add(lv278);

                //venta248       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/22/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta248_1);

                      LineaVentaEN lv279 = new LineaVentaEN();
                lv279.Cantidad = 1;
                lv279.Producto = productoCEN.GetProducto("119214-5162");

                IList<LineaVentaEN> Venta249_1 = new List<LineaVentaEN>();
                Venta249_1.Add(lv279);

                //venta249       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/22/2015 16:02:32", System.Globalization.CultureInfo.InvariantCulture), Venta249_1);

                      LineaVentaEN lv280 = new LineaVentaEN();
                lv280.Cantidad = 1;
                lv280.Producto = productoCEN.GetProducto("CV-CS104-MIL");

                IList<LineaVentaEN> Venta250_1 = new List<LineaVentaEN>();
                Venta250_1.Add(lv280);

                //venta250       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/22/2015 17:24:11", System.Globalization.CultureInfo.InvariantCulture), Venta250_1);

                      LineaVentaEN lv281 = new LineaVentaEN();
                lv281.Cantidad = 1;
                lv281.Producto = productoCEN.GetProducto("CV-CS104-MIL");

                IList<LineaVentaEN> Venta251_1 = new List<LineaVentaEN>();
                Venta251_1.Add(lv281);

                //venta251       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/23/2015 09:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta251_1);

                      LineaVentaEN lv282 = new LineaVentaEN();
                lv282.Cantidad = 1;
                lv282.Producto = productoCEN.GetProducto("CV-CS104-MIL");

                IList<LineaVentaEN> Venta252_1 = new List<LineaVentaEN>();
                Venta252_1.Add(lv282);

                //venta252       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/23/2015 11:08:30", System.Globalization.CultureInfo.InvariantCulture), Venta252_1);

                      LineaVentaEN lv283 = new LineaVentaEN();
                lv283.Cantidad = 1;
                lv283.Producto = productoCEN.GetProducto("119217-9500");

                IList<LineaVentaEN> Venta253_1 = new List<LineaVentaEN>();
                Venta253_1.Add(lv283);

                //venta253       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/23/2015 12:15:20", System.Globalization.CultureInfo.InvariantCulture), Venta253_1);

                      LineaVentaEN lv284 = new LineaVentaEN();
                lv284.Cantidad = 1;
                lv284.Producto = productoCEN.GetProducto("119217-9500");

                IList<LineaVentaEN> Venta254_1 = new List<LineaVentaEN>();
                Venta254_1.Add(lv284);

                //venta254       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/23/2015 13:18:50", System.Globalization.CultureInfo.InvariantCulture), Venta254_1);

                  LineaVentaEN lv285 = new LineaVentaEN();
                lv285.Cantidad = 1;
                lv285.Producto = productoCEN.GetProducto("119156-9500");

                IList<LineaVentaEN> Venta255_1 = new List<LineaVentaEN>();
                Venta255_1.Add(lv285);

                //venta255       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/24/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta255_1);

                      LineaVentaEN lv286 = new LineaVentaEN();
                lv286.Cantidad = 1;
                lv286.Producto = productoCEN.GetProducto("119156-9500");

                IList<LineaVentaEN> Venta256_1 = new List<LineaVentaEN>();
                Venta256_1.Add(lv286);

                //venta256       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/24/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta256_1);

                      LineaVentaEN lv287 = new LineaVentaEN();
                lv287.Cantidad = 1;
                lv287.Producto = productoCEN.GetProducto("119218-3000");

                IList<LineaVentaEN> Venta257_1 = new List<LineaVentaEN>();
                Venta257_1.Add(lv287);

                //venta257      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/24/2015 17:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta257_1);

                      LineaVentaEN lv288 = new LineaVentaEN();
                lv288.Cantidad = 1;
                lv288.Producto = productoCEN.GetProducto("119218-3000");

                IList<LineaVentaEN> Venta258_1 = new List<LineaVentaEN>();
                Venta258_1.Add(lv288);

                //venta258       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/25/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta258_1);

                      LineaVentaEN lv289 = new LineaVentaEN();
                lv289.Cantidad = 1;
                lv289.Producto = productoCEN.GetProducto("120514-5015");

                IList<LineaVentaEN> Venta259_1 = new List<LineaVentaEN>();
                Venta259_1.Add(lv289);

                //venta259       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/25/2015 11:15:30", System.Globalization.CultureInfo.InvariantCulture), Venta259_1);


                      LineaVentaEN lv290 = new LineaVentaEN();
                lv290.Cantidad = 1;
                lv290.Producto = productoCEN.GetProducto("120514-5015");

                IList<LineaVentaEN> Venta260_1 = new List<LineaVentaEN>();
                Venta260_1.Add(lv290);

                //venta260       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/26/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta260_1);

                      LineaVentaEN lv291 = new LineaVentaEN();
                lv291.Cantidad = 1;
                lv291.Producto = productoCEN.GetProducto("120514-5015");

                IList<LineaVentaEN> Venta261_1 = new List<LineaVentaEN>();
                Venta261_1.Add(lv291);

                //venta261       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/27/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta261_1);

                      LineaVentaEN lv292 = new LineaVentaEN();
                lv292.Cantidad = 1;
                lv292.Producto = productoCEN.GetProducto("119153-9501");

                IList<LineaVentaEN> Venta262_1 = new List<LineaVentaEN>();
                Venta262_1.Add(lv292);

                //venta262       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/28/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta262_1);

                      LineaVentaEN lv293 = new LineaVentaEN();
                lv293.Cantidad = 1;
                lv293.Producto = productoCEN.GetProducto("119153-9501");

                IList<LineaVentaEN> Venta263_1 = new List<LineaVentaEN>();
                Venta263_1.Add(lv293);

                //venta263       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/29/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta263_1);

                      LineaVentaEN lv294 = new LineaVentaEN();
                lv294.Cantidad = 1;
                lv294.Producto = productoCEN.GetProducto("120518-7012");

                IList<LineaVentaEN> Venta264_1 = new List<LineaVentaEN>();
                Venta264_1.Add(lv294);

                //venta264       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/29/2015 18:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta264_1);

                      LineaVentaEN lv295 = new LineaVentaEN();
                lv295.Cantidad = 1;
                lv295.Producto = productoCEN.GetProducto("120518-7012");

                IList<LineaVentaEN> Venta265_1 = new List<LineaVentaEN>();
                Venta265_1.Add(lv295);

                //venta265       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("09/30/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta265_1);

                      LineaVentaEN lv296 = new LineaVentaEN();
                lv296.Cantidad = 1;
                lv296.Producto = productoCEN.GetProducto("CV-CWR3616-CLM");

                IList<LineaVentaEN> Venta266_1 = new List<LineaVentaEN>();
                Venta266_1.Add(lv296);

                //Octubre--------------------------------------------------------------------

                //venta266        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta266_1);

                      LineaVentaEN lv297 = new LineaVentaEN();
                lv297.Cantidad = 1;
                lv297.Producto = productoCEN.GetProducto("CV-CWR3616-CLM");

                IList<LineaVentaEN> Venta267_1 = new List<LineaVentaEN>();
                Venta267_1.Add(lv297);

                //venta267        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta267_1);

                      LineaVentaEN lv298 = new LineaVentaEN();
                lv298.Cantidad = 2;
                lv298.Producto = productoCEN.GetProducto("CV-CWQ3206-VLT");

                IList<LineaVentaEN> Venta268_1 = new List<LineaVentaEN>();
                Venta268_1.Add(lv298);

                //venta268        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta268_1);

                      LineaVentaEN lv299 = new LineaVentaEN();
                lv299.Cantidad = 2;
                lv299.Producto = productoCEN.GetProducto("CV-CWQ3206-VLT");

                IList<LineaVentaEN> Venta269_1 = new List<LineaVentaEN>();
                Venta269_1.Add(lv299);

                //venta269
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta269_1);

                      LineaVentaEN lv300 = new LineaVentaEN();
                lv300.Cantidad = 2;
                lv300.Producto = productoCEN.GetProducto("CV-CKQ3107-MNT");

                IList<LineaVentaEN> Venta270_1 = new List<LineaVentaEN>();
                Venta270_1.Add(lv300);

                //venta270        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta270_1);

                      LineaVentaEN lv301 = new LineaVentaEN();
                lv301.Cantidad = 2;
                lv301.Producto = productoCEN.GetProducto("CV-CKQ3107-MNT");

                IList<LineaVentaEN> Venta271_1 = new List<LineaVentaEN>();
                Venta271_1.Add(lv301);

                //venta271        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta271_1);

                      LineaVentaEN lv302 = new LineaVentaEN();
                lv302.Cantidad = 2;
                lv302.Producto = productoCEN.GetProducto("F50490");

                IList<LineaVentaEN> Venta272_1 = new List<LineaVentaEN>();
                Venta272_1.Add(lv302);

                //venta272        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta272_1);

                      LineaVentaEN lv303 = new LineaVentaEN();
                lv303.Cantidad = 2;
                lv303.Producto = productoCEN.GetProducto("F50490");

                IList<LineaVentaEN> Venta273_1 = new List<LineaVentaEN>();
                Venta273_1.Add(lv303);

                //venta273       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta273_1);

                      LineaVentaEN lv304 = new LineaVentaEN();
                lv304.Cantidad = 2;
                lv304.Producto = productoCEN.GetProducto("F50632");

                IList<LineaVentaEN> Venta274_1 = new List<LineaVentaEN>();
                Venta274_1.Add(lv304);


                //venta274        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta274_1);


                      LineaVentaEN lv305 = new LineaVentaEN();
                lv305.Cantidad = 2;
                lv305.Producto = productoCEN.GetProducto("F50632");

                IList<LineaVentaEN> Venta275_1 = new List<LineaVentaEN>();
                Venta275_1.Add(lv305);

                //venta275        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta275_1);

                      LineaVentaEN lv306 = new LineaVentaEN();
                lv306.Cantidad = 2;
                lv306.Producto = productoCEN.GetProducto("F50632");

                IList<LineaVentaEN> Venta276_1 = new List<LineaVentaEN>();
                Venta276_1.Add(lv306);

                //venta276       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta276_1);


                      LineaVentaEN lv307 = new LineaVentaEN();
                lv307.Cantidad = 2;
                lv307.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta277_1 = new List<LineaVentaEN>();
                Venta277_1.Add(lv307);

                //venta277       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta277_1);

                      LineaVentaEN lv308 = new LineaVentaEN();
                lv308.Cantidad = 2;
                lv308.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta278_1 = new List<LineaVentaEN>();
                Venta278_1.Add(lv308);

                //venta278       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta278_1);

                      LineaVentaEN lv309 = new LineaVentaEN();
                lv309.Cantidad = 2;
                lv309.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta279_1 = new List<LineaVentaEN>();
                Venta279_1.Add(lv309);

                //venta279       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta279_1);

                      LineaVentaEN lv310 = new LineaVentaEN();
                lv310.Cantidad = 2;
                lv310.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta280_1 = new List<LineaVentaEN>();
                Venta280_1.Add(lv310);

                //venta280       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta280_1);

                      LineaVentaEN lv311 = new LineaVentaEN();
                lv311.Cantidad = 2;
                lv311.Producto = productoCEN.GetProducto("D67175");

                IList<LineaVentaEN> Venta281_1 = new List<LineaVentaEN>();
                Venta281_1.Add(lv311);

                //venta281       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta281_1);
            
                      LineaVentaEN lv312 = new LineaVentaEN();
                lv312.Cantidad = 2;
                lv312.Producto = productoCEN.GetProducto("D67175");

                IList<LineaVentaEN> Venta282_1 = new List<LineaVentaEN>();
                Venta282_1.Add(lv312);

                //venta282       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta282_1);

                  LineaVentaEN lv313 = new LineaVentaEN();
                lv313.Cantidad = 2;
                lv313.Producto = productoCEN.GetProducto("D67175");

                IList<LineaVentaEN> Venta283_1 = new List<LineaVentaEN>();
                Venta283_1.Add(lv313);

                //venta283       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta283_1);

                      LineaVentaEN lv314 = new LineaVentaEN();
                lv314.Cantidad = 2;
                lv314.Producto = productoCEN.GetProducto("120547-9000");

                IList<LineaVentaEN> Venta284_1 = new List<LineaVentaEN>();
                Venta284_1.Add(lv314);

                //venta284       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("10/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta284_1);

                      LineaVentaEN lv315 = new LineaVentaEN();
                lv315.Cantidad = 2;
                lv315.Producto = productoCEN.GetProducto("120547-9000");

                IList<LineaVentaEN> Venta285_1 = new List<LineaVentaEN>();
                Venta285_1.Add(lv315);


                //Noviembre------------------------------------------------------------------

                //venta285        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta285_1);

                      LineaVentaEN lv316 = new LineaVentaEN();
                lv316.Cantidad = 2;
                lv316.Producto = productoCEN.GetProducto("Q33931");

                IList<LineaVentaEN> Venta286_1 = new List<LineaVentaEN>();
                Venta286_1.Add(lv316);    

                //venta286        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta286_1);

                      LineaVentaEN lv317 = new LineaVentaEN();
                lv317.Cantidad = 2;
                lv317.Producto = productoCEN.GetProducto("Q33931");

                IList<LineaVentaEN> Venta287_1 = new List<LineaVentaEN>();
                Venta287_1.Add(lv317);

                //venta287        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta287_1);

                      LineaVentaEN lv318 = new LineaVentaEN();
                lv318.Cantidad = 2;
                lv318.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta288_1 = new List<LineaVentaEN>();
                Venta288_1.Add(lv318);

                //venta288        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta288_1);


                      LineaVentaEN lv319 = new LineaVentaEN();
                lv319.Cantidad = 2;
                lv319.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta289_1 = new List<LineaVentaEN>();
                Venta289_1.Add(lv319);

                //venta289
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta289_1);

                      LineaVentaEN lv320 = new LineaVentaEN();
                lv320.Cantidad = 2;
                lv320.Producto = productoCEN.GetProducto("119150-9500");

                IList<LineaVentaEN> Venta290_1 = new List<LineaVentaEN>();
                Venta290_1.Add(lv320);

                //venta290        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta290_1);

                      LineaVentaEN lv321 = new LineaVentaEN();
                lv321.Cantidad = 2;
                lv321.Producto = productoCEN.GetProducto("119150-9500");

                IList<LineaVentaEN> Venta291_1 = new List<LineaVentaEN>();
                Venta291_1.Add(lv321);

                //venta291        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta291_1);

                      LineaVentaEN lv322 = new LineaVentaEN();
                lv322.Cantidad = 2;
                lv322.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta292_1 = new List<LineaVentaEN>();
                Venta292_1.Add(lv322);

                //venta292        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta292_1);

                      LineaVentaEN lv323 = new LineaVentaEN();
                lv323.Cantidad = 2;
                lv323.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta293_1 = new List<LineaVentaEN>();
                Venta293_1.Add(lv323);

                //venta293       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta293_1);

                      LineaVentaEN lv324 = new LineaVentaEN();
                lv324.Cantidad = 2;
                lv324.Producto = productoCEN.GetProducto("G65302");

                IList<LineaVentaEN> Venta294_1 = new List<LineaVentaEN>();
                Venta294_1.Add(lv324);

                //venta294        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta294_1);

                      LineaVentaEN lv325 = new LineaVentaEN();
                lv325.Cantidad = 2;
                lv325.Producto = productoCEN.GetProducto("G65302");

                IList<LineaVentaEN> Venta295_1 = new List<LineaVentaEN>();
                Venta295_1.Add(lv325);

                //venta295        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta295_1);

                      LineaVentaEN lv326 = new LineaVentaEN();
                lv326.Cantidad = 2;
                lv326.Producto = productoCEN.GetProducto("D67002");

                IList<LineaVentaEN> Venta296_1 = new List<LineaVentaEN>();
                Venta296_1.Add(lv326);


                //venta296       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta296_1);

                      LineaVentaEN lv327 = new LineaVentaEN();
                lv327.Cantidad = 2;
                lv327.Producto = productoCEN.GetProducto("D67002");

                IList<LineaVentaEN> Venta297_1 = new List<LineaVentaEN>();
                Venta297_1.Add(lv327);

                //venta297       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta297_1);

                      LineaVentaEN lv328 = new LineaVentaEN();
                lv328.Cantidad = 2;
                lv328.Producto = productoCEN.GetProducto("Q33691");

                IList<LineaVentaEN> Venta298_1 = new List<LineaVentaEN>();
                Venta298_1.Add(lv328);

                //venta298       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta298_1);

                      LineaVentaEN lv329 = new LineaVentaEN();
                lv329.Cantidad = 2;
                lv329.Producto = productoCEN.GetProducto("Q33691");

                IList<LineaVentaEN> Venta299_1 = new List<LineaVentaEN>();
                Venta299_1.Add(lv329);

                //venta299       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta299_1);


                      LineaVentaEN lv330 = new LineaVentaEN();
                lv330.Cantidad = 2;
                lv330.Producto = productoCEN.GetProducto("120517-5036");

                IList<LineaVentaEN> Venta300_1 = new List<LineaVentaEN>();
                Venta300_1.Add(lv330);

                //venta300       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta300_1);

                      LineaVentaEN lv331 = new LineaVentaEN();
                lv331.Cantidad = 2;
                lv331.Producto = productoCEN.GetProducto("120517-5036");

                IList<LineaVentaEN> Venta301_1 = new List<LineaVentaEN>();
                Venta301_1.Add(lv331);

                //venta301       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta301_1);


                      LineaVentaEN lv332 = new LineaVentaEN();
                lv332.Cantidad = 2;
                lv332.Producto = productoCEN.GetProducto("120517-5036");

                IList<LineaVentaEN> Venta302_1 = new List<LineaVentaEN>();
                Venta302_1.Add(lv332);

                //venta302       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta302_1);


                      LineaVentaEN lv333 = new LineaVentaEN();
                lv333.Cantidad = 2;
                lv333.Producto = productoCEN.GetProducto("F50491");

                IList<LineaVentaEN> Venta303_1 = new List<LineaVentaEN>();
                Venta303_1.Add(lv333);

                //venta303       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta303_1);


                      LineaVentaEN lv334 = new LineaVentaEN();
                lv334.Cantidad = 2;
                lv334.Producto = productoCEN.GetProducto("F50491");

                IList<LineaVentaEN> Venta304_1 = new List<LineaVentaEN>();
                Venta304_1.Add(lv334);

                //Venta304       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta304_1);


                      LineaVentaEN lv335 = new LineaVentaEN();
                lv335.Cantidad = 2;
                lv335.Producto = productoCEN.GetProducto("F50491");

                IList<LineaVentaEN> Venta305_1 = new List<LineaVentaEN>();
                Venta305_1.Add(lv335);

                //venta305       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta305_1);


                      LineaVentaEN lv336 = new LineaVentaEN();
                lv336.Cantidad = 2;
                lv336.Producto = productoCEN.GetProducto("119159-9500");

                IList<LineaVentaEN> Venta306_1 = new List<LineaVentaEN>();
                Venta306_1.Add(lv336);

                //venta306       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta306_1);

                      LineaVentaEN lv337 = new LineaVentaEN();
                lv337.Cantidad = 2;
                lv337.Producto = productoCEN.GetProducto("119159-9500");

                IList<LineaVentaEN> Venta307_1 = new List<LineaVentaEN>();
                Venta307_1.Add(lv337);

                //venta307       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta307_1);


                      LineaVentaEN lv338 = new LineaVentaEN();
                lv338.Cantidad = 2;
                lv338.Producto = productoCEN.GetProducto("119159-9500");

                IList<LineaVentaEN> Venta308_1 = new List<LineaVentaEN>();
                Venta308_1.Add(lv338);

                //venta308      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta308_1);


                      LineaVentaEN lv339 = new LineaVentaEN();
                lv339.Cantidad = 2;
                lv339.Producto = productoCEN.GetProducto("F50632");

                IList<LineaVentaEN> Venta309_1 = new List<LineaVentaEN>();
                Venta309_1.Add(lv339);

                //venta309       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta309_1);


                      LineaVentaEN lv340 = new LineaVentaEN();
                lv340.Cantidad = 2;
                lv340.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta310_1 = new List<LineaVentaEN>();
                Venta310_1.Add(lv340);

                //venta310       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta310_1);


                      LineaVentaEN lv341 = new LineaVentaEN();
                lv341.Cantidad = 2;
                lv341.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta311_1 = new List<LineaVentaEN>();
                Venta311_1.Add(lv341);

                //venta311      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("11/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta311_1);

                      LineaVentaEN lv342 = new LineaVentaEN();
                lv342.Cantidad = 2;
                lv342.Producto = productoCEN.GetProducto("Z73944");

                IList<LineaVentaEN> Venta312_1 = new List<LineaVentaEN>();
                Venta312_1.Add(lv342);

                //Diciembre------------------------------------------------------------------

                //venta312        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta312_1);


                      LineaVentaEN lv343 = new LineaVentaEN();
                lv343.Cantidad = 2;
                lv343.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta313_1 = new List<LineaVentaEN>();
                Venta313_1.Add(lv343);

                //venta313        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta313_1);


                      LineaVentaEN lv344 = new LineaVentaEN();
                lv344.Cantidad = 2;
                lv344.Producto = productoCEN.GetProducto("M20162");

                IList<LineaVentaEN> Venta314_1 = new List<LineaVentaEN>();
                Venta314_1.Add(lv344);

                //venta314        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta314_1);

                      LineaVentaEN lv345 = new LineaVentaEN();
                lv345.Cantidad = 2;
                lv345.Producto = productoCEN.GetProducto("119150-9500");

                IList<LineaVentaEN> Venta315_1 = new List<LineaVentaEN>();
                Venta315_1.Add(lv345);

                //venta315        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta315_1);

                      LineaVentaEN lv346 = new LineaVentaEN();
                lv346.Cantidad = 2;
                lv346.Producto = productoCEN.GetProducto("119150-9500");

                IList<LineaVentaEN> Venta316_1 = new List<LineaVentaEN>();
                Venta316_1.Add(lv346);

                //venta316
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta316_1);

                      LineaVentaEN lv347 = new LineaVentaEN();
                lv347.Cantidad = 2;
                lv347.Producto = productoCEN.GetProducto("119148-9000");

                IList<LineaVentaEN> Venta317_1 = new List<LineaVentaEN>();
                Venta317_1.Add(lv347);

                //venta317        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta317_1);

                      LineaVentaEN lv348 = new LineaVentaEN();
                lv348.Cantidad = 2;
                lv348.Producto = productoCEN.GetProducto("119148-9000");

                IList<LineaVentaEN> Venta318_1 = new List<LineaVentaEN>();
                Venta318_1.Add(lv348);

                //venta318        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta318_1);

                      LineaVentaEN lv349 = new LineaVentaEN();
                lv349.Cantidad = 2;
                lv349.Producto = productoCEN.GetProducto("120547-9000");

                IList<LineaVentaEN> Venta319_1 = new List<LineaVentaEN>();
                Venta319_1.Add(lv349);

                //venta319        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta319_1);


                      LineaVentaEN lv350 = new LineaVentaEN();
                lv350.Cantidad = 2;
                lv350.Producto = productoCEN.GetProducto("120547-9000");

                IList<LineaVentaEN> Venta320_1 = new List<LineaVentaEN>();
                Venta320_1.Add(lv350);

                //venta320       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta320_1);

                      LineaVentaEN lv351 = new LineaVentaEN();
                lv351.Cantidad = 2;
                lv351.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                IList<LineaVentaEN> Venta321_1 = new List<LineaVentaEN>();
                Venta321_1.Add(lv351);

                //venta321        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta321_1);


                      LineaVentaEN lv352 = new LineaVentaEN();
                lv352.Cantidad = 2;
                lv352.Producto = productoCEN.GetProducto("CV-CKQ3214-PPL");

                IList<LineaVentaEN> Venta322_1 = new List<LineaVentaEN>();
                Venta322_1.Add(lv352);
                
                //venta322        
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta322_1);

                      LineaVentaEN lv353 = new LineaVentaEN();
                lv353.Cantidad = 2;
                lv353.Producto = productoCEN.GetProducto("D67175");

                IList<LineaVentaEN> Venta323_1 = new List<LineaVentaEN>();
                Venta323_1.Add(lv353);

                //venta323       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta323_1);

                      LineaVentaEN lv354 = new LineaVentaEN();
                lv354.Cantidad = 2;
                lv354.Producto = productoCEN.GetProducto("D67175");

                IList<LineaVentaEN> Venta324_1 = new List<LineaVentaEN>();
                Venta324_1.Add(lv354);

                //venta324       

                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta324_1);

                      LineaVentaEN lv355 = new LineaVentaEN();
                lv355.Cantidad = 2;
                lv355.Producto = productoCEN.GetProducto("Q33931");

                IList<LineaVentaEN> Venta325_1 = new List<LineaVentaEN>();
                Venta325_1.Add(lv355);


                //venta325       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta325_1);

                      LineaVentaEN lv356 = new LineaVentaEN();
                lv356.Cantidad = 2;
                lv356.Producto = productoCEN.GetProducto("Q33931");

                IList<LineaVentaEN> Venta326_1 = new List<LineaVentaEN>();
                Venta326_1.Add(lv356);

                //venta326       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta326_1);

                      LineaVentaEN lv357 = new LineaVentaEN();
                lv357.Cantidad = 2;
                lv357.Producto = productoCEN.GetProducto("O07606");

                IList<LineaVentaEN> Venta327_1 = new List<LineaVentaEN>();
                Venta327_1.Add(lv357);

                //venta327       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta327_1);

                      LineaVentaEN lv358 = new LineaVentaEN();
                lv358.Cantidad = 2;
                lv358.Producto = productoCEN.GetProducto("O07606");

                IList<LineaVentaEN> Venta328_1 = new List<LineaVentaEN>();
                Venta328_1.Add(lv358);

                //venta328       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta328_1);

                      LineaVentaEN lv359 = new LineaVentaEN();
                lv359.Cantidad = 2;
                lv359.Producto = productoCEN.GetProducto("D67836");

                IList<LineaVentaEN> Venta329_1 = new List<LineaVentaEN>();
                Venta329_1.Add(lv359);

                //venta329       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta329_1);

                      LineaVentaEN lv360 = new LineaVentaEN();
                lv360.Cantidad = 2;
                lv360.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta330_1 = new List<LineaVentaEN>();
                Venta330_1.Add(lv360);

                //venta330       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta330_1);

                      LineaVentaEN lv361 = new LineaVentaEN();
                lv361.Cantidad = 2;
                lv361.Producto = productoCEN.GetProducto("O07596");

                IList<LineaVentaEN> Venta331_1 = new List<LineaVentaEN>();
                Venta331_1.Add(lv361);

                //Vent120       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta331_1);

                      LineaVentaEN lv362 = new LineaVentaEN();
                lv362.Cantidad = 2;
                lv362.Producto = productoCEN.GetProducto("O07596");

                IList<LineaVentaEN> Venta332_1 = new List<LineaVentaEN>();
                Venta332_1.Add(lv362);

                //venta332       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta332_1);

                      LineaVentaEN lv363 = new LineaVentaEN();
                lv363.Cantidad = 2;
                lv363.Producto = productoCEN.GetProducto("G65302");

                IList<LineaVentaEN> Venta333_1 = new List<LineaVentaEN>();
                Venta333_1.Add(lv363);

                //venta333       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta333_1);


                      LineaVentaEN lv364 = new LineaVentaEN();
                lv364.Cantidad = 2;
                lv364.Producto = productoCEN.GetProducto("G65302");

                IList<LineaVentaEN> Venta334_1 = new List<LineaVentaEN>();
                Venta334_1.Add(lv364);

                //venta334       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta334_1);

                      LineaVentaEN lv365 = new LineaVentaEN();
                lv365.Cantidad = 2;
                lv365.Producto = productoCEN.GetProducto("G65202");

                IList<LineaVentaEN> Venta335_1 = new List<LineaVentaEN>();
                Venta335_1.Add(lv365);

                //venta335      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta335_1);

                      LineaVentaEN lv366 = new LineaVentaEN();
                lv366.Cantidad = 2;
                lv366.Producto = productoCEN.GetProducto("G65202");

                IList<LineaVentaEN> Venta336_1 = new List<LineaVentaEN>();
                Venta336_1.Add(lv366);

                //venta336       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta336_1);

                      LineaVentaEN lv367 = new LineaVentaEN();
                lv367.Cantidad = 2;
                lv367.Producto = productoCEN.GetProducto("120862-9500");

                IList<LineaVentaEN> Venta337_1 = new List<LineaVentaEN>();
                Venta337_1.Add(lv367);

                //venta337       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta337_1);

                      LineaVentaEN lv368 = new LineaVentaEN();
                lv368.Cantidad = 2;
                lv368.Producto = productoCEN.GetProducto("120862-9500");

                IList<LineaVentaEN> Venta338_1 = new List<LineaVentaEN>();
                Venta338_1.Add(lv368);
                

                //venta338      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta338_1);

                      LineaVentaEN lv369 = new LineaVentaEN();
                lv369.Cantidad = 2;
                lv369.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta339_1 = new List<LineaVentaEN>();
                Venta339_1.Add(lv369);

                //venta339       
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/25/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta339_1);

                      LineaVentaEN lv370 = new LineaVentaEN();
                lv370.Cantidad = 2;
                lv370.Producto = productoCEN.GetProducto("Q21672");

                IList<LineaVentaEN> Venta340_1 = new List<LineaVentaEN>();
                Venta340_1.Add(lv370);

                //venta340      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/25/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta340_1);

                      LineaVentaEN lv371 = new LineaVentaEN();
                lv371.Cantidad = 2;
                lv371.Producto = productoCEN.GetProducto("CV-113823-AS5B");

                IList<LineaVentaEN> Venta341_1 = new List<LineaVentaEN>();
                Venta341_1.Add(lv371);

                //venta341      
                ventaCP.RestarStockCrearVentaHacerMovimiento(toni.Email, DateTime.Parse("12/29/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta341_1);


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
