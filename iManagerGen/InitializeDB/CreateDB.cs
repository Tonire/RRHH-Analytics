
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
                ILineaVentaCAD _ILineaVenta = new LineaVentaCAD ();
                LineaVentaCEN lineaVentaCEN = new LineaVentaCEN (_ILineaVenta);
                IVentaCAD _IVentaCAD = new VentaCAD ();
                VentaCEN ventaCEN = new VentaCEN (_IVentaCAD);
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
                pedido1.FechaRealizacion = DateTime.Parse ("01/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                int pedido = pedidoCEN.CrearPedido (pedido1.Estado, pedido1.FechaRealizacion, toni.Email, Pedido01_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (pedido, DateTime.Parse ("01/07/2015 12:50:12", System.Globalization.CultureInfo.InvariantCulture));
                double totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);



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
                pedido3.FechaRealizacion = DateTime.Parse ("03/14/2015 10:36:41", System.Globalization.CultureInfo.InvariantCulture);
                int ped3 = pedidoCEN.CrearPedido (pedido3.Estado, pedido3.FechaRealizacion, toni.Email, Pedido03_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (ped3, DateTime.Parse ("03/19/2015 09:19:56", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);



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
                pedido12.FechaRealizacion = DateTime.Parse ("12/14/2015 15:16:11", System.Globalization.CultureInfo.InvariantCulture);
                int ped12 = pedidoCEN.CrearPedido (pedido12.Estado, pedido12.FechaRealizacion, toni.Email, Pedido12_1);
                pedidoCP.AumentarStockConfirmarPedidoHacerMovimiento (ped12, DateTime.Parse ("12/17/2015 08:27:45", System.Globalization.CultureInfo.InvariantCulture));
                totalGastosAnyo = movimientosCEN.GetMovimientoTotalAnyo (2015, IManagerGenNHibernate.Enumerated.IManager.TipoMovimientoEnum.gasto);



                #endregion

                #region LineasVenta

                //LineaVentas 1
                LineaVentaEN lv1 = new LineaVentaEN ();
                lv1.Cantidad = 1;
                lv1.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv2 = new LineaVentaEN ();
                lv2.Cantidad = 2;
                lv2.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv3 = new LineaVentaEN ();
                lv3.Cantidad = 1;
                lv3.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta01_1 = new List<LineaVentaEN>();
                Venta01_1.Add (lv1);
                Venta01_1.Add (lv2);
                Venta01_1.Add (lv3);


                //LineaVentas 2
                LineaVentaEN lv4 = new LineaVentaEN ();
                lv4.Cantidad = 1;
                lv4.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv5 = new LineaVentaEN ();
                lv5.Cantidad = 2;
                lv5.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv6 = new LineaVentaEN ();
                lv6.Cantidad = 1;
                lv6.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta02_1 = new List<LineaVentaEN>();
                Venta02_1.Add (lv4);
                Venta02_1.Add (lv5);
                Venta02_1.Add (lv6);

                //LineaVentas 3
                LineaVentaEN lv7 = new LineaVentaEN ();
                lv7.Cantidad = 1;
                lv7.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv8 = new LineaVentaEN ();
                lv8.Cantidad = 2;
                lv8.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv9 = new LineaVentaEN ();
                lv9.Cantidad = 1;
                lv9.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta03_1 = new List<LineaVentaEN>();
                Venta03_1.Add (lv7);
                Venta03_1.Add (lv8);
                Venta03_1.Add (lv9);



                //LineaVentas 4
                LineaVentaEN lv10 = new LineaVentaEN ();
                lv10.Cantidad = 1;
                lv10.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv11 = new LineaVentaEN ();
                lv11.Cantidad = 2;
                lv11.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv12 = new LineaVentaEN ();
                lv12.Cantidad = 1;
                lv12.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta04_1 = new List<LineaVentaEN>();
                Venta04_1.Add (lv10);
                Venta04_1.Add (lv11);
                Venta04_1.Add (lv12);

                //LineaVentas 5
                LineaVentaEN lv13 = new LineaVentaEN ();
                lv13.Cantidad = 1;
                lv13.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv14 = new LineaVentaEN ();
                lv14.Cantidad = 2;
                lv14.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv15 = new LineaVentaEN ();
                lv15.Cantidad = 1;
                lv15.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta05_1 = new List<LineaVentaEN>();
                Venta05_1.Add (lv13);
                Venta05_1.Add (lv14);
                Venta05_1.Add (lv15);

                //LineaVentas 6
                LineaVentaEN lv16 = new LineaVentaEN ();
                lv16.Cantidad = 1;
                lv16.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv17 = new LineaVentaEN ();
                lv17.Cantidad = 2;
                lv17.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv18 = new LineaVentaEN ();
                lv18.Cantidad = 1;
                lv18.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta06_1 = new List<LineaVentaEN>();
                Venta06_1.Add (lv16);
                Venta06_1.Add (lv17);
                Venta06_1.Add (lv18);

                //LineaVentas 7
                LineaVentaEN lv19 = new LineaVentaEN ();
                lv19.Cantidad = 1;
                lv19.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv20 = new LineaVentaEN ();
                lv20.Cantidad = 2;
                lv20.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv21 = new LineaVentaEN ();
                lv21.Cantidad = 1;
                lv21.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta07_1 = new List<LineaVentaEN>();
                Venta07_1.Add (lv19);
                Venta07_1.Add (lv20);
                Venta07_1.Add (lv21);

                //LineaVentas 8
                LineaVentaEN lv22 = new LineaVentaEN ();
                lv22.Cantidad = 1;
                lv22.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv23 = new LineaVentaEN ();
                lv23.Cantidad = 2;
                lv23.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv24 = new LineaVentaEN ();
                lv24.Cantidad = 1;
                lv24.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta08_1 = new List<LineaVentaEN>();
                Venta08_1.Add (lv22);
                Venta08_1.Add (lv23);
                Venta08_1.Add (lv24);


                //LineaVentas 9
                LineaVentaEN lv25 = new LineaVentaEN ();
                lv25.Cantidad = 1;
                lv25.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv26 = new LineaVentaEN ();
                lv26.Cantidad = 2;
                lv26.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv27 = new LineaVentaEN ();
                lv27.Cantidad = 1;
                lv27.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta09_1 = new List<LineaVentaEN>();
                Venta09_1.Add (lv25);
                Venta09_1.Add (lv26);
                Venta09_1.Add (lv27);

                //LineaVentas 10
                LineaVentaEN lv28 = new LineaVentaEN ();
                lv28.Cantidad = 1;
                lv28.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv29 = new LineaVentaEN ();
                lv29.Cantidad = 2;
                lv29.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv30 = new LineaVentaEN ();
                lv30.Cantidad = 1;
                lv30.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta10_1 = new List<LineaVentaEN>();
                Venta10_1.Add (lv28);
                Venta10_1.Add (lv29);
                Venta10_1.Add (lv30);


                //LineaVentas 11
                LineaVentaEN lv31 = new LineaVentaEN ();
                lv31.Cantidad = 1;
                lv31.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv32 = new LineaVentaEN ();
                lv32.Cantidad = 2;
                lv32.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv33 = new LineaVentaEN ();
                lv33.Cantidad = 1;
                lv33.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta11_1 = new List<LineaVentaEN>();
                Venta11_1.Add (lv31);
                Venta11_1.Add (lv32);
                Venta11_1.Add (lv33);

                //LineaVentas 12
                LineaVentaEN lv34 = new LineaVentaEN ();
                lv34.Cantidad = 1;
                lv34.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv35 = new LineaVentaEN ();
                lv35.Cantidad = 2;
                lv35.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv36 = new LineaVentaEN ();
                lv36.Cantidad = 1;
                lv36.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta12_1 = new List<LineaVentaEN>();
                Venta12_1.Add (lv34);
                Venta12_1.Add (lv35);
                Venta12_1.Add (lv36);


                //LineaVentas 13
                LineaVentaEN lv37 = new LineaVentaEN ();
                lv37.Cantidad = 1;
                lv37.Producto = productoCEN.GetProducto ("O07592");
                LineaVentaEN lv38 = new LineaVentaEN ();
                lv38.Cantidad = 2;
                lv38.Producto = productoCEN.GetProducto ("120547-9000");
                LineaVentaEN lv39 = new LineaVentaEN ();
                lv39.Cantidad = 1;
                lv39.Producto = productoCEN.GetProducto ("120518-7012");

                IList<LineaVentaEN> Venta13_1 = new List<LineaVentaEN>();
                Venta13_1.Add (lv37);
                Venta13_1.Add (lv38);
                Venta13_1.Add (lv39);

                #endregion

                #region Ventas

                //Enero

                //Venta1
                VentaEN venta1 = new VentaEN ();
                venta1.FechaVenta = DateTime.Parse ("01/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta01_1);


                //Venta2
                VentaEN venta2 = new VentaEN ();
                venta2.FechaVenta = DateTime.Parse ("01/05/2015 16:56:22", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/05/2015 16:56:22", System.Globalization.CultureInfo.InvariantCulture), Venta02_1);

                //Venta3
                VentaEN venta3 = new VentaEN ();
                venta3.FechaVenta = DateTime.Parse ("01/08/2015 11:02:11", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/08/2015 11:02:11", System.Globalization.CultureInfo.InvariantCulture), Venta03_1);

                //Venta4
                VentaEN venta4 = new VentaEN ();
                venta4.FechaVenta = DateTime.Parse ("01/09/2015 12:02:10", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/09/2015 12:02:10", System.Globalization.CultureInfo.InvariantCulture), Venta04_1);

                //Venta5
                VentaEN venta5 = new VentaEN ();
                venta5.FechaVenta = DateTime.Parse ("01/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta05_1);

                //Venta6
                VentaEN venta6 = new VentaEN ();
                venta6.FechaVenta = DateTime.Parse ("01/09/2015 18:00:10", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/09/2015 18:00:10", System.Globalization.CultureInfo.InvariantCulture), Venta06_1);

                //Venta7
                VentaEN venta7 = new VentaEN ();
                venta7.FechaVenta = DateTime.Parse ("01/12/2015 10:45:10", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/12/2015 10:45:10", System.Globalization.CultureInfo.InvariantCulture), Venta07_1);

                //Venta8
                VentaEN venta8 = new VentaEN ();
                venta8.FechaVenta = DateTime.Parse ("01/12/2015 13:12:50", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/12/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta08_1);

                //Venta9
                VentaEN venta9 = new VentaEN ();
                venta9.FechaVenta = DateTime.Parse ("01/14/2015 14:02:10", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/14/2015 14:02:10", System.Globalization.CultureInfo.InvariantCulture), Venta09_1);

                //Venta10
                VentaEN venta10 = new VentaEN ();
                venta10.FechaVenta = DateTime.Parse ("01/14/2015 19:30:25", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/14/2015 19:30:25", System.Globalization.CultureInfo.InvariantCulture), Venta10_1);

                //Venta11
                VentaEN venta11 = new VentaEN ();
                venta11.FechaVenta = DateTime.Parse ("01/16/2015 09:30:12", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/16/2015 09:30:12", System.Globalization.CultureInfo.InvariantCulture), Venta11_1);

                //Venta12
                VentaEN venta12 = new VentaEN ();
                venta12.FechaVenta = DateTime.Parse ("01/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta12_1);

                //Venta13
                VentaEN venta13 = new VentaEN ();
                venta13.FechaVenta = DateTime.Parse ("01/18/2015 14:22:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/18/2015 14:22:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta13
                VentaEN venta14 = new VentaEN ();
                venta14.FechaVenta = DateTime.Parse ("01/18/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/18/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta15
                VentaEN venta15 = new VentaEN ();
                venta15.FechaVenta = DateTime.Parse ("01/19/2015 11:28:10", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/19/2015 11:28:10", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta16
                VentaEN venta16 = new VentaEN ();
                venta16.FechaVenta = DateTime.Parse ("01/19/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/19/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta17
                VentaEN venta17 = new VentaEN ();
                venta17.FechaVenta = DateTime.Parse ("01/19/2015 18:10:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/19/2015 18:10:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta18
                VentaEN venta18 = new VentaEN ();
                venta18.FechaVenta = DateTime.Parse ("01/20/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/20/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta19
                VentaEN venta19 = new VentaEN ();
                venta19.FechaVenta = DateTime.Parse ("01/21/2015 10:00:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/21/2015 10:00:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta20
                VentaEN venta20 = new VentaEN ();
                venta20.FechaVenta = DateTime.Parse ("01/21/2015 13:00:13", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/21/2015 13:00:13", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta21
                VentaEN venta21 = new VentaEN ();
                venta21.FechaVenta = DateTime.Parse ("01/22/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/22/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta22
                VentaEN venta22 = new VentaEN ();
                venta22.FechaVenta = DateTime.Parse ("01/22/2015 16:02:32", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/22/2015 16:02:32", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta23
                VentaEN venta23 = new VentaEN ();
                venta23.FechaVenta = DateTime.Parse ("01/22/2015 17:24:11", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/22/2015 17:24:11", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta24
                VentaEN venta24 = new VentaEN ();
                venta24.FechaVenta = DateTime.Parse ("01/23/2015 09:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/23/2015 09:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta25
                VentaEN venta25 = new VentaEN ();
                venta25.FechaVenta = DateTime.Parse ("01/23/2015 11:08:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/23/2015 11:08:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta26
                VentaEN venta26 = new VentaEN ();
                venta26.FechaVenta = DateTime.Parse ("01/23/2015 12:15:20", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/23/2015 12:15:20", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta28
                VentaEN venta28 = new VentaEN ();
                venta28.FechaVenta = DateTime.Parse ("01/23/2015 13:18:50", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/23/2015 13:18:50", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta29
                VentaEN venta29 = new VentaEN ();
                venta29.FechaVenta = DateTime.Parse ("01/24/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/24/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta30
                VentaEN venta30 = new VentaEN ();
                venta30.FechaVenta = DateTime.Parse ("01/24/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/24/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta31
                VentaEN venta31 = new VentaEN ();
                venta31.FechaVenta = DateTime.Parse ("01/24/2015 17:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/24/2015 17:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta32
                VentaEN venta32 = new VentaEN ();
                venta32.FechaVenta = DateTime.Parse ("01/25/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/25/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta33
                VentaEN venta33 = new VentaEN ();
                venta33.FechaVenta = DateTime.Parse ("01/25/2015 11:15:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/25/2015 11:15:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);


                //Venta34
                VentaEN venta34 = new VentaEN ();
                venta34.FechaVenta = DateTime.Parse ("01/26/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/26/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);


                //Venta35
                VentaEN venta36 = new VentaEN ();
                venta36.FechaVenta = DateTime.Parse ("01/27/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/27/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);


                //Venta37
                VentaEN venta37 = new VentaEN ();
                venta37.FechaVenta = DateTime.Parse ("01/28/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/28/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta38
                VentaEN venta38 = new VentaEN ();
                venta38.FechaVenta = DateTime.Parse ("01/29/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/29/2015 15:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);


                //Venta39
                VentaEN venta39 = new VentaEN ();
                venta39.FechaVenta = DateTime.Parse ("01/29/2015 18:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/29/2015 18:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);


                //Venta40
                VentaEN venta40 = new VentaEN ();
                venta40.FechaVenta = DateTime.Parse ("01/30/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("01/30/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);


                //Febrero------------------------------------------------------------------------

                //Venta41
                VentaEN venta41 = new VentaEN ();
                venta41.FechaVenta = DateTime.Parse ("02/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta01_1);


                //Venta42
                VentaEN venta42 = new VentaEN ();
                venta42.FechaVenta = DateTime.Parse ("02/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta02_1);

                //Venta43
                VentaEN venta43 = new VentaEN ();
                venta43.FechaVenta = DateTime.Parse ("02/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta03_1);

                //Venta44
                VentaEN venta44 = new VentaEN ();
                venta44.FechaVenta = DateTime.Parse ("02/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta04_1);

                //Venta45
                VentaEN venta45 = new VentaEN ();
                venta45.FechaVenta = DateTime.Parse ("02/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta05_1);

                //Venta46
                VentaEN venta46 = new VentaEN ();
                venta46.FechaVenta = DateTime.Parse ("02/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta06_1);

                //Venta47
                VentaEN venta47 = new VentaEN ();
                venta47.FechaVenta = DateTime.Parse ("02/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta07_1);

                //Venta48
                VentaEN venta48 = new VentaEN ();
                venta48.FechaVenta = DateTime.Parse ("02/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta08_1);

                //Venta49
                VentaEN venta49 = new VentaEN ();
                venta49.FechaVenta = DateTime.Parse ("02/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta09_1);

                //Venta50
                VentaEN venta50 = new VentaEN ();
                venta50.FechaVenta = DateTime.Parse ("02/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta10_1);

                //Venta51
                VentaEN venta51 = new VentaEN ();
                venta51.FechaVenta = DateTime.Parse ("02/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta11_1);

                //Venta52
                VentaEN venta52 = new VentaEN ();
                venta52.FechaVenta = DateTime.Parse ("02/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta12_1);

                //Venta53
                VentaEN venta53 = new VentaEN ();
                venta53.FechaVenta = DateTime.Parse ("02/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta54
                VentaEN venta54 = new VentaEN ();
                venta54.FechaVenta = DateTime.Parse ("02/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta55
                VentaEN venta55 = new VentaEN ();
                venta55.FechaVenta = DateTime.Parse ("02/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta56
                VentaEN venta56 = new VentaEN ();
                venta56.FechaVenta = DateTime.Parse ("02/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta57
                VentaEN venta57 = new VentaEN ();
                venta57.FechaVenta = DateTime.Parse ("02/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta58
                VentaEN venta58 = new VentaEN ();
                venta18.FechaVenta = DateTime.Parse ("02/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta59
                VentaEN venta59 = new VentaEN ();
                venta19.FechaVenta = DateTime.Parse ("02/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta60
                VentaEN venta60 = new VentaEN ();
                venta60.FechaVenta = DateTime.Parse ("02/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta61
                VentaEN venta61 = new VentaEN ();
                venta61.FechaVenta = DateTime.Parse ("02/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta62
                VentaEN venta62 = new VentaEN ();
                venta22.FechaVenta = DateTime.Parse ("02/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta63
                VentaEN venta63 = new VentaEN ();
                venta63.FechaVenta = DateTime.Parse ("02/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta64
                VentaEN venta64 = new VentaEN ();
                venta64.FechaVenta = DateTime.Parse ("02/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta65
                VentaEN venta65 = new VentaEN ();
                venta65.FechaVenta = DateTime.Parse ("02/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta66
                VentaEN venta66 = new VentaEN ();
                venta66.FechaVenta = DateTime.Parse ("02/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta67
                VentaEN venta67 = new VentaEN ();
                venta67.FechaVenta = DateTime.Parse ("02/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta68
                VentaEN venta68 = new VentaEN ();
                venta68.FechaVenta = DateTime.Parse ("02/24/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/24/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta69
                VentaEN venta69 = new VentaEN ();
                venta69.FechaVenta = DateTime.Parse ("02/26/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/26/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta70
                VentaEN venta70 = new VentaEN ();
                venta70.FechaVenta = DateTime.Parse ("02/27/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/27/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta71
                VentaEN venta71 = new VentaEN ();
                venta71.FechaVenta = DateTime.Parse ("02/27/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/27/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta72
                VentaEN venta72 = new VentaEN ();
                venta72.FechaVenta = DateTime.Parse ("02/27/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/27/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);


                //Venta73
                VentaEN venta73 = new VentaEN ();
                venta73.FechaVenta = DateTime.Parse ("02/27/2015 20:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("02/27/2015 20:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);


                //Marzo-------------------------------------------------------------------------------------

                //Venta74
                VentaEN venta74 = new VentaEN ();
                venta74.FechaVenta = DateTime.Parse ("03/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta01_1);


                //Venta75
                VentaEN venta75 = new VentaEN ();
                venta75.FechaVenta = DateTime.Parse ("03/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta02_1);

                //Venta76
                VentaEN venta76 = new VentaEN ();
                venta76.FechaVenta = DateTime.Parse ("03/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta03_1);

                //Venta77
                VentaEN venta77 = new VentaEN ();
                venta77.FechaVenta = DateTime.Parse ("03/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta04_1);

                //Venta78
                VentaEN venta78 = new VentaEN ();
                venta78.FechaVenta = DateTime.Parse ("03/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta05_1);

                //Venta79
                VentaEN venta79 = new VentaEN ();
                venta79.FechaVenta = DateTime.Parse ("03/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta06_1);

                //Venta80
                VentaEN venta80 = new VentaEN ();
                venta80.FechaVenta = DateTime.Parse ("03/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta07_1);

                //Venta81
                VentaEN venta81 = new VentaEN ();
                venta81.FechaVenta = DateTime.Parse ("03/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta08_1);

                //Venta82
                VentaEN venta82 = new VentaEN ();
                venta82.FechaVenta = DateTime.Parse ("03/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta09_1);

                //Venta83
                VentaEN venta83 = new VentaEN ();
                venta83.FechaVenta = DateTime.Parse ("03/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta10_1);

                //Venta84
                VentaEN venta84 = new VentaEN ();
                venta84.FechaVenta = DateTime.Parse ("03/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta11_1);

                //Venta85
                VentaEN venta85 = new VentaEN ();
                venta85.FechaVenta = DateTime.Parse ("03/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta12_1);

                //Venta86
                VentaEN venta86 = new VentaEN ();
                venta86.FechaVenta = DateTime.Parse ("03/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta87
                VentaEN venta87 = new VentaEN ();
                venta87.FechaVenta = DateTime.Parse ("03/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta88
                VentaEN venta88 = new VentaEN ();
                venta88.FechaVenta = DateTime.Parse ("03/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta89
                VentaEN venta89 = new VentaEN ();
                venta89.FechaVenta = DateTime.Parse ("03/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta90
                VentaEN venta90 = new VentaEN ();
                venta90.FechaVenta = DateTime.Parse ("03/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta91
                VentaEN venta91 = new VentaEN ();
                venta91.FechaVenta = DateTime.Parse ("03/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta92
                VentaEN venta92 = new VentaEN ();
                venta19.FechaVenta = DateTime.Parse ("03/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Vent93
                VentaEN venta93 = new VentaEN ();
                venta93.FechaVenta = DateTime.Parse ("03/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta94
                VentaEN venta94 = new VentaEN ();
                venta94.FechaVenta = DateTime.Parse ("03/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta95
                VentaEN venta95 = new VentaEN ();
                venta95.FechaVenta = DateTime.Parse ("03/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta96
                VentaEN venta96 = new VentaEN ();
                venta96.FechaVenta = DateTime.Parse ("03/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta97
                VentaEN venta97 = new VentaEN ();
                venta97.FechaVenta = DateTime.Parse ("03/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta98
                VentaEN venta98 = new VentaEN ();
                venta98.FechaVenta = DateTime.Parse ("03/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta99
                VentaEN venta99 = new VentaEN ();
                venta66.FechaVenta = DateTime.Parse ("03/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta100
                VentaEN venta100 = new VentaEN ();
                venta100.FechaVenta = DateTime.Parse ("03/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("03/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Abril----------------------------------------------------------------------


                //Venta101
                VentaEN venta101 = new VentaEN ();
                venta101.FechaVenta = DateTime.Parse ("04/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/01/2015 13:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta01_1);


                //Venta102
                VentaEN venta102 = new VentaEN ();
                venta102.FechaVenta = DateTime.Parse ("04/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/01/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta02_1);

                //Venta103
                VentaEN venta103 = new VentaEN ();
                venta103.FechaVenta = DateTime.Parse ("04/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/02/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta03_1);

                //Venta104
                VentaEN venta104 = new VentaEN ();
                venta104.FechaVenta = DateTime.Parse ("04/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/03/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta04_1);

                //Venta105
                VentaEN venta105 = new VentaEN ();
                venta105.FechaVenta = DateTime.Parse ("04/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/03/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta05_1);

                //Venta106
                VentaEN venta106 = new VentaEN ();
                venta106.FechaVenta = DateTime.Parse ("04/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/03/2015 16:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta06_1);

                //Venta107
                VentaEN venta107 = new VentaEN ();
                venta107.FechaVenta = DateTime.Parse ("04/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/04/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta07_1);

                //Venta108
                VentaEN venta108 = new VentaEN ();
                venta108.FechaVenta = DateTime.Parse ("04/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/05/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta08_1);

                //Venta109
                VentaEN venta109 = new VentaEN ();
                venta109.FechaVenta = DateTime.Parse ("04/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/06/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta09_1);

                //Venta110
                VentaEN venta110 = new VentaEN ();
                venta110.FechaVenta = DateTime.Parse ("04/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/06/2015 14:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta10_1);

                //Venta111
                VentaEN venta111 = new VentaEN ();
                venta111.FechaVenta = DateTime.Parse ("04/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/07/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta11_1);

                //Venta112
                VentaEN venta112 = new VentaEN ();
                venta112.FechaVenta = DateTime.Parse ("04/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/08/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta12_1);

                //Venta113
                VentaEN venta113 = new VentaEN ();
                venta113.FechaVenta = DateTime.Parse ("04/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/09/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta114
                VentaEN venta114 = new VentaEN ();
                venta114.FechaVenta = DateTime.Parse ("04/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/09/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta115
                VentaEN venta115 = new VentaEN ();
                venta88.FechaVenta = DateTime.Parse ("04/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/10/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta116
                VentaEN venta116 = new VentaEN ();
                venta89.FechaVenta = DateTime.Parse ("04/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/10/2015 12:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta117
                VentaEN venta117 = new VentaEN ();
                venta117.FechaVenta = DateTime.Parse ("04/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/11/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta118
                VentaEN venta118 = new VentaEN ();
                venta118.FechaVenta = DateTime.Parse ("04/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/12/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta119
                VentaEN venta119 = new VentaEN ();
                venta119.FechaVenta = DateTime.Parse ("04/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/13/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Vent120
                VentaEN venta120 = new VentaEN ();
                venta120.FechaVenta = DateTime.Parse ("04/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/14/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta121
                VentaEN venta121 = new VentaEN ();
                venta121.FechaVenta = DateTime.Parse ("04/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/16/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta122
                VentaEN venta122 = new VentaEN ();
                venta122.FechaVenta = DateTime.Parse ("04/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/17/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta123
                VentaEN venta123 = new VentaEN ();
                venta123.FechaVenta = DateTime.Parse ("04/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/18/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta124
                VentaEN venta124 = new VentaEN ();
                venta124.FechaVenta = DateTime.Parse ("04/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/20/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta125
                VentaEN venta125 = new VentaEN ();
                venta125.FechaVenta = DateTime.Parse ("04/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta126
                VentaEN venta126 = new VentaEN ();
                venta126.FechaVenta = DateTime.Parse ("04/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/21/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta127
                VentaEN venta127 = new VentaEN ();
                venta127.FechaVenta = DateTime.Parse ("04/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/23/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);


                //Venta128
                VentaEN venta128 = new VentaEN ();
                venta128.FechaVenta = DateTime.Parse ("04/25/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/25/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta129
                VentaEN venta129 = new VentaEN ();
                venta129.FechaVenta = DateTime.Parse ("04/26/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/26/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);

                //Venta130
                VentaEN venta130 = new VentaEN ();
                venta130.FechaVenta = DateTime.Parse ("04/29/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture);
                ventaCP.RestarStockCrearVentaHacerMovimiento (toni.Email, DateTime.Parse ("04/29/2015 10:12:30", System.Globalization.CultureInfo.InvariantCulture), Venta13_1);


                //Mayo-----------------------------------------------------------------------

                //Junio----------------------------------------------------------------------

                //Julio----------------------------------------------------------------------

                //Agosto---------------------------------------------------------------------

                //Septiembre-----------------------------------------------------------------

                //Octubre--------------------------------------------------------------------

                //Noviembre------------------------------------------------------------------

                //Diciembre------------------------------------------------------------------


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
