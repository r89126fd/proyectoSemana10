using SimuladorCajeroAutomatico;
using System;

namespace Grupo8
{
    class Program
    {
        public static void Main(string[] args)
        {
            // La variable sirve para que el codigo continue su ejecucion o se detenga
            // para gestionar la opcion del menu que el usuario seleccione.
            int opcionMenu;
            int opcionGestionUsuario = 0;
            int opcionGestionCuentas = 0;

            //New crea instancia de list, esta variable nos servira para almacenar todos los usuarios que se creen.
            List<Usuario> usuariosCreados = new List<Usuario>();
            List<Cuenta> cuentas = new List<Cuenta>();

            do
            {
                MenuPrincipal();
                
                opcionMenu = Convert.ToInt16(Console.ReadLine());

                if (opcionMenu == 1)
                {
                    // Imprimir el menu Gestion De Usuarios
                    Console.WriteLine();
                    ImprimirMenuGestionDeUsuarios();
                    // Obtener la opción que el usuario escogió
                    opcionGestionUsuario = Convert.ToInt16(Console.ReadLine());

                    //movi toda la logica de la Gestion de Usuarios a un metodo propio
                    switch (opcionGestionUsuario)
                    {

                        case 1:
                            // Registrar un usuario
                            RegistrarUsuario(usuariosCreados);
                            break;
                        case 2:
                            // Darle de baja a un usuario
                            DarDeBajaUsuario(usuariosCreados);
                            break;
                        case 3:
                            // Iniciar sesión
                            IniciarSesion(usuariosCreados, cuentas);
                            break;
                        default:
                            Console.WriteLine("Opción invalida...");
                            Console.WriteLine();
                            break;
                    }
                }
                else if (opcionMenu == 2)
                {
                    //Se hace la Gestión de cuentas bancarias
                    Console.WriteLine();
                    MenuGestionDeCuentasBancarias();
                    opcionGestionCuentas = Convert.ToInt32(Console.ReadLine());
                    int MenuCrearCuenta = 0;

                    switch (opcionGestionCuentas)
                    {
                        case 1: // Agregar Cuenta
                            Console.WriteLine();
                            MenuCrearCuentaCliente();
                            MenuCrearCuenta = Convert.ToInt32(Console.ReadLine());

                            //Se hace la creación de cuentas bancarias
                            Console.WriteLine();
                            Console.WriteLine("==========Agregar de Cuenta==========");
                            Console.Write("Crear ID Número de Cuenta: ");
                            string idCuenta = Console.ReadLine();
                            Console.Write("Crear ID Nombre de propietario: ");
                            string idPropietario = Console.ReadLine();
                            Console.Write("Ingrese monto inicial: ");
                            double balance = Convert.ToDouble(Console.ReadLine());
                            DateTime fechaActual = DateTime.Today;
                            string fecha = fechaActual.ToString("dd/MM/yyyy");
                            Console.WriteLine("Fecha actual: " + fecha);

                            if (MenuCrearCuenta == 1)
                            {
                                CuentaBasica basica = new CuentaBasica(idCuenta, idPropietario, balance, fecha);
                                cuentas.Add(basica);
                                Console.WriteLine("Cuenta creada exitosamente");
                            }
                            else if (MenuCrearCuenta == 2)
                            {
                                CuentaPremium premium = new CuentaPremium(idCuenta, idPropietario, balance, fecha);
                                cuentas.Add(premium);
                                Console.WriteLine("Cuenta creada exitosamente");
                            }
                            else if (MenuCrearCuenta == 3)
                            {
                                Console.WriteLine("Gracias por crear su cuenta con nosotros");
                            }
                            else
                            {
                                Console.WriteLine("Opción Invalida..");
                            }
                            break;
                        case 2: // Baja de Cuenta
                            Console.WriteLine();
                            Console.WriteLine("==========Baja de Cuenta==========");
                            Console.Write("Ingrese Numero de Cuenta: ");
                            idCuenta = Console.ReadLine();
                            Cuenta buscarCuentaExistente = cuentas.Find(c => c.IdCuenta == idCuenta);
                            if (buscarCuentaExistente != null)
                            {
                                cuentas.Remove(buscarCuentaExistente);
                                Console.Write("Cuenta eliminada exitosamente");
                            }
                            else
                            {
                                Console.Write("Lo sentimos, no hemos encontrado su cuenta..");
                            }

                            break;
                        case 3: // Deposito de dinero
                            Console.WriteLine();
                            Console.WriteLine("==========Deposito de dinero==========");
                            Console.Write("Ingrese Número de Cuenta: ");
                            idCuenta = Console.ReadLine();
                            Console.Write("Monto del deposito: ");
                            double deposito = Convert.ToDouble(Console.ReadLine());
                            foreach (Cuenta elemento in cuentas)
                            {
                                if (elemento.IdCuenta.Equals(idCuenta))
                                {
                                    elemento.Deposito(deposito);
                                    Console.WriteLine("Deposito exitoso");
                                }
                            }
                            break;
                        case 4: // Retiro de dinero
                            Console.WriteLine();
                            Console.WriteLine("==========Retiro de dinero==========");
                            Console.Write("Ingrese Numero de Cuenta: ");
                            idCuenta = Console.ReadLine();
                            Console.Write("Monto del Retiro: ");
                            double retiro = Convert.ToDouble(Console.ReadLine());
                            foreach (Cuenta elemento in cuentas)
                            {
                                if (elemento.IdCuenta.Equals(idCuenta))
                                {
                                    elemento.Retiro(retiro);
                                    Console.WriteLine("Retiro exitoso");
                                }
                            }
                            break;
                        case 5: //Verificación de saldo
                            Console.WriteLine();
                            Console.WriteLine("==========Verificar saldo==========");
                            foreach (Cuenta elemento in cuentas)
                            {
                                Console.WriteLine(elemento);
                                Console.WriteLine();
                            }
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            } while (opcionMenu != 0);
            Console.ReadKey();
        }

        public static void MenuPrincipal()
        {
            Console.WriteLine("===============Menu===============");
            Console.WriteLine("1. Gestion Usuario");
            Console.WriteLine("2. Gestion Cuentas");
            Console.Write("Seleccione una opción: ");
        }

        public static void ImprimirMenuGestionDeUsuarios()
        {
            Console.WriteLine("================== Gestion de Usuarios ==================");
            Console.WriteLine("Instrucciones: Ingrese la opcion que desee realizar:");
            Console.WriteLine("1. Registro de usuarios");
            Console.WriteLine("2. Baja de usuarios");
            Console.WriteLine("3. Inicio de sesión");
            Console.WriteLine("0. Salir del sistema");
        }

        //menú para administradores
        public static void MenuAdmin()
        {
            Console.WriteLine("==========Menú de Administrador==========");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Dar de baja un usuario");
            Console.WriteLine("3. Agregar cuenta");
            Console.WriteLine("4. Dar de baja una cuenta");
            Console.WriteLine("5. Salir");
            Console.Write("\nElija una opción: ");
        }

        //menú para clientes
        public static void MenuCliente()
        {
            Console.WriteLine("==========Menú de Cliente==========");
            Console.WriteLine("1. Depositar");
            Console.WriteLine("2. Retirar");
            Console.WriteLine("3. Verificar saldo");
            Console.WriteLine("4. Salir");
            Console.Write("\nElija una opción: ");
        }

        //Menú para gestionar cuentas
        public static void MenuCrearCuentaCliente()
        {
            //DE AQUI EN ADELANTE IMPLEMENTEN LA GESTION DE CUENTAS
            Console.WriteLine("==========Gestion de Cuentas Bancarias==========");
            Console.WriteLine("1. Cuenta Básica");
            Console.WriteLine("2. Cuenta Premium");
            Console.WriteLine("3. Salir");
            Console.Write("\nElija una opción: ");
        }

        //Gestión de cuentas bancarias
        private static void MenuGestionDeCuentasBancarias()
        {
            Console.WriteLine("==========Gestion de cuentas bancarias==========");
            Console.WriteLine("1. Agregar cuenta");
            Console.WriteLine("2. Baja de Cuenta");
            Console.WriteLine("3. Depositar dinero");
            Console.WriteLine("4. Retirar dinero ");
            Console.WriteLine("5. Verificar saldo");
            Console.WriteLine("0. Salir del programa");
            Console.Write("\nElija una opción: ");
        }

        //Registrar usuario
        public static void RegistrarUsuario(List<Usuario> usuariosCreados)
        {
            Console.WriteLine("===========Registrar un usuario==========");
            Usuario usuario = new Usuario();
            Console.Write("Ingrese el nombre del usuario: ");
            usuario.nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido del usuario: ");
            usuario.apellido = Console.ReadLine();
            Console.Write("Ingrese el username del usuario: ");
            usuario.username = Console.ReadLine();
            Console.Write("Ingrese el password del usuario: ");
            usuario.password = Console.ReadLine();
            Console.Write("Ingrese el rol del usuario (admin/cliente): ");
            usuario.rol = Console.ReadLine();

            //Agregamos el usuario creado a la lista
            usuariosCreados.Add(usuario);
            Console.WriteLine("¡Usuario creado exitosamente!");
        }

        // Dar de baja un usuario
        public static void DarDeBajaUsuario(List<Usuario> usuariosCreados)
        {
            Console.WriteLine("==========Darle de baja a un usuario==========");

            //Obtener el username al usuario que se le dara de baja
            Console.Write("Ingrese el username del usuario que se le dara de baja: ");
            string usuarioUsername = Console.ReadLine();

            //Buscar el usuario que se le dara de baja
            bool usuarioEncontrado = false;
            foreach (Usuario usuarioActual in usuariosCreados)
            {
                if (usuarioActual.username == usuarioUsername)
                {
                    usuariosCreados.Remove(usuarioActual);
                    usuarioEncontrado = true;
                    Console.WriteLine("¡Usuario dado de baja exitosamente!");
                    break;
                }
            }
            if (usuarioEncontrado == false)
            {
                Console.WriteLine("No se ha encontrado un usuario con ese username.");
            }
        }

        //Iniciar sesion
        public static void IniciarSesion(List<Usuario> usuariosCreados, List<Cuenta> cuentas)
        {
            Console.WriteLine("==========Iniciar sesión==========");
            Console.Write("Ingrese el username: ");
            string username = Console.ReadLine();
            Console.Write("Ingrese el password: ");
            string password = Console.ReadLine();

            Usuario usuarioActual = usuariosCreados.FirstOrDefault(u => u.username == username && u.password == password);

            if (usuarioActual != null)
            {
                Console.WriteLine("¡Inicio de sesión exitoso!");

                if (usuarioActual.rol == "admin")
                {
                    int opcionAdmin;
                    do
                    {
                        MenuAdmin();
                        opcionAdmin = Convert.ToInt32(Console.ReadLine());
                        GestionarAdmin(opcionAdmin, usuariosCreados, cuentas);
                    } while (opcionAdmin != 5);
                }
                else if (usuarioActual.rol == "cliente")
                {
                    int opcionCliente;
                    do
                    {
                        MenuCliente();
                        opcionCliente = Convert.ToInt32(Console.ReadLine());
                        GestionarCliente(opcionCliente, cuentas, usuarioActual);
                    } while (opcionCliente != 4);
                }
            }
            else
            {
                Console.WriteLine("Usuario o contraseña incorrectos.");
            }
        }

        //gestion para el administrador
        public static void GestionarAdmin(int opcionAdmin, List<Usuario> usuariosCreados, List<Cuenta> cuentas)
        {
            switch (opcionAdmin)
            {
                case 1:
                    RegistrarUsuario(usuariosCreados);
                    break;
                case 2:
                    DarDeBajaUsuario(usuariosCreados);
                    break;
                case 3:
                    Console.WriteLine("==========Agregar cuenta==========");
                    Console.Write("Crear ID Número de Cuenta: ");
                    string idCuenta = Console.ReadLine();
                    Console.Write("Crear ID Nombre de propietario: ");
                    string idPropietario = Console.ReadLine();
                    Console.Write("Ingrese monto inicial: ");
                    double balance = Convert.ToDouble(Console.ReadLine());
                    DateTime fechaActual = DateTime.Today;
                    string fecha = fechaActual.ToString("dd/MM/yyyy");
                    Console.WriteLine("Fecha actual: " + fecha);
                    break;
                case 4:
                    Console.WriteLine("==========Dar de baja cuenta==========");
                    Console.Write("Ingrese Número de Cuenta a dar de baja: ");
                    string numCuenta = Console.ReadLine();

                    // Buscar la cuenta en la lista de cuentas
                    Cuenta cuentaAEliminar = cuentas.FirstOrDefault(c => c.IdCuenta == numCuenta);

                    if (cuentaAEliminar != null)
                    {
                        cuentas.Remove(cuentaAEliminar);
                        Console.WriteLine("Cuenta eliminada exitosamente");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró la cuenta especificada");
                    }
                    break;
                case 5:
                    Console.WriteLine("Sesión cerrada.");
                    break;
                default:
                    Console.WriteLine("Opción invalida...");
                    break;
            }
        }

        //gestiones para el cliente
        public static void GestionarCliente(int opcionCliente, List<Cuenta> cuentas, Usuario usuarioActual)
        {
            string idCuenta;
            double monto;

            switch (opcionCliente)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("==========Depositar dinero==========");
                    Console.Write("Ingrese Numero de Cuenta: ");
                    idCuenta = Console.ReadLine();
                    Console.Write("Monto del depósito: ");
                    monto = Convert.ToDouble(Console.ReadLine());

                    Cuenta cuentaDeposito = cuentas.FirstOrDefault(c => c.IdCuenta == idCuenta && c.IdPropietario == usuarioActual.username);
                    if (cuentaDeposito != null)
                    {
                        cuentaDeposito.Deposito(monto);
                        Console.WriteLine("Depósito exitoso");
                    }
                    else
                    {
                        Console.WriteLine("Cuenta no encontrada o no pertenece al usuario actual.");
                    }
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("==========Retiro de dinero==========");
                    Console.Write("Ingrese Numero de Cuenta: ");
                    idCuenta = Console.ReadLine();
                    Console.Write("Monto del Retiro: ");
                    monto = Convert.ToDouble(Console.ReadLine());

                    Cuenta cuentaRetiro = cuentas.FirstOrDefault(c => c.IdCuenta == idCuenta && c.IdPropietario == usuarioActual.username);
                    if (cuentaRetiro != null)
                    {
                        cuentaRetiro.Retiro(monto);
                        Console.WriteLine("Retiro exitoso");
                    }
                    else
                    {
                        Console.WriteLine("Cuenta no encontrada o no pertenece al usuario actual.");
                    }
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("==========Verificar saldo==========");
                    foreach (Cuenta elemento in cuentas)
                    {
                        if (elemento.IdPropietario == usuarioActual.username)
                        {
                            Console.WriteLine(elemento);
                            Console.WriteLine();
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Sesión cerrada.");
                    break;
                default:
                    Console.WriteLine("Opción invalida...");
                    break;
            }
        }
    }
}