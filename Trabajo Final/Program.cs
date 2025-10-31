namespace Trabajo_Final
{
    internal class Program
    {
        /*TRABAJO FINAL
          Integrantes:
            -Aileen Sofía Graldo Andrade
            -Oscar Daniel Obando Vallejo 
        */

        static int[] numHabitacion = new int[20];
        static string[] tipoHabitacion = new string[3];
        static double[] precioHabitacion = new double[3];
        static bool[] disponible = new bool[20];
        static int totalHabitaciones = 0;

        static string[] nombreHuesped = new string[20];
        static string[] documentoHuesped = new string[20];
        static string[] telefonoHuesped = new string[20];
        static int totalHuespedes = 0;

        static void Main()
        {
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE RESERVAS DEL HOTEL ===");
                Console.WriteLine("1. Gestión de Habitaciones");
                Console.WriteLine("2. Gestión de Huéspedes");
                Console.WriteLine("3. Gestión de Reservas");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        GestionHabitaciones();
                        break;
                    case "2":
                        GestionHuespedes();
                        break;
                    case "3":
                        Console.WriteLine("Módulo de Reservas en desarrollo...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != "4");
        }

        // ------------------ GESTIÓN DE HABITACIONES ------------------
        static void GestionHabitaciones()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE HABITACIONES ===");
                Console.WriteLine("1. Registrar habitación");
                Console.WriteLine("2. Ver lista de habitaciones");
                Console.WriteLine("3. Editar habitación");
                Console.WriteLine("4. Ver disponibilidad");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": RegistrarHabitacion(); break;
                    case "2": VerListaHabitaciones(); break;
                    case "3": EditarHabitacion(); break;
                    case "4": VerDisponibilidad(); break;
                    case "5": break;
                    default:
                        Console.WriteLine("Opción no válida");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != "5");
        }

        static void RegistrarHabitacion()
        {
            if (totalHabitaciones >= 20)
            {
                Console.WriteLine("No se pueden registrar más habitaciones.");
                Console.ReadKey();
                return;
            }

            Console.Write("Número de habitación: ");
            numHabitacion[totalHabitaciones] = int.Parse(Console.ReadLine());
            Console.Write("Tipo (Individual/Doble/Suite): ");
            tipoHabitacion[totalHabitaciones] = Console.ReadLine();
            Console.Write("Precio por noche: ");
            precioHabitacion[totalHabitaciones] = double.Parse(Console.ReadLine());
            disponible[totalHabitaciones] = true;

            totalHabitaciones++;
            Console.WriteLine("Habitación registrada correctamente.");
            Console.ReadKey();
        }

        static void VerListaHabitaciones()
        {
            Console.WriteLine("=== LISTA DE HABITACIONES ===");
            for (int i = 0; i < totalHabitaciones; i++)
            {
                string estado = disponible[i] ? "Disponible" : "Ocupada";
                Console.WriteLine($"Habitación {numHabitacion[i]} - {tipoHabitacion[i]} - Precio: {precioHabitacion[i]} - {estado}");
            }
            Console.ReadKey();

        }

        static void EditarHabitacion()
        {
            Console.Write("Ingrese el número de habitación a editar: ");
            int numero = int.Parse(Console.ReadLine());
            bool encontrada = false;

            for (int i = 0; i < totalHabitaciones; i++)
            {
                if (numHabitacion[i] == numero)
                {
                    Console.Write("Nuevo tipo: ");
                    tipoHabitacion[i] = Console.ReadLine();
                    Console.Write("Nuevo precio: ");
                    precioHabitacion[i] = double.Parse(Console.ReadLine());
                    Console.WriteLine("Habitación actualizada correctamente.");
                    encontrada = true;
                    break;
                }
            }

            if (!encontrada)
                Console.WriteLine("Habitación no encontrada.");

            Console.ReadKey();
        }

        static void VerDisponibilidad()
        {
            Console.WriteLine("=== DISPONIBILIDAD DE HABITACIONES ===");
            for (int i = 0; i < totalHabitaciones; i++)
            {
                if (disponible[i])
                    Console.WriteLine($"Habitación {numHabitacion[i]} disponible ({tipoHabitacion[i]})");
            }
            Console.ReadKey();
        }

        // ------------------ GESTIÓN DE HUÉSPEDES ------------------
        static void GestionHuespedes()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE HUÉSPEDES ===");
                Console.WriteLine("1. Registrar huésped");
                Console.WriteLine("2. Ver lista de huéspedes");
                Console.WriteLine("3. Editar información de huésped");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": RegistrarHuesped(); break;
                    case "2": VerListaHuespedes(); break;
                    case "3": EditarHuesped(); break;
                    case "4": break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != "4");
        }

        static void RegistrarHuesped()
        {
            if (totalHuespedes >= 20)
            {
                Console.WriteLine("No se pueden registrar más huéspedes.");
                Console.ReadKey();
                return;
            }

            Console.Write("Nombre del huésped: ");
            nombreHuesped[totalHuespedes] = Console.ReadLine();
            Console.Write("Documento de identidad: ");
            documentoHuesped[totalHuespedes] = Console.ReadLine();
            Console.Write("Teléfono: ");
            telefonoHuesped[totalHuespedes] = Console.ReadLine();

            totalHuespedes++;
            Console.WriteLine("Huésped registrado correctamente.");
            Console.ReadKey();
        }

        static void VerListaHuespedes()
        {
            Console.WriteLine("=== LISTA DE HUÉSPEDES ===");
            for (int i = 0; i < totalHuespedes; i++)
            {
                Console.WriteLine($"{i + 1}. {nombreHuesped[i]} - Doc: {documentoHuesped[i]} - Tel: {telefonoHuesped[i]}");
            }
            Console.ReadKey();
        }

        static void EditarHuesped()
        {
            Console.Write("Ingrese el documento del huésped a editar: ");
            string doc = Console.ReadLine();
            bool encontrado = false;

            for (int i = 0; i < totalHuespedes; i++)
            {
                if (documentoHuesped[i] == doc)
                {
                    Console.Write("Nuevo nombre: ");
                    nombreHuesped[i] = Console.ReadLine();
                    Console.Write("Nuevo teléfono: ");
                    telefonoHuesped[i] = Console.ReadLine();
                    Console.WriteLine("Datos actualizados correctamente.");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
                Console.WriteLine("Huésped no encontrado.");

            Console.ReadKey();
        }
    }
}

