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
        static string[] tipoHabitacion = new string[20];
        static double[] precioHabitacion = new double[20];
        static bool[] disponible = new bool[20];
        static int totalHabitaciones = 0;

        static string[] nombreHuesped = new string[20];
        static string[] documentoHuesped = new string[20];
        static string[] telefonoHuesped = new string[20];
        static int totalHuespedes = 0;

        static string[] reservaHuesped = new string[20];
        static int[] reservaHabitacion = new int[20];
        static int totalReservas = 0;

        static void Main()
        {
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE RESERVAS HOTEL AILEENS ===");
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
                        GestionReservas();
                        break;
                    case "4":
                        Console.WriteLine("Gracias por elegirnos, hasta luego. :D");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != "4");
        }

        // Gestión de Habitaciones
        static void GestionHabitaciones()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine(" GESTIÓN DE HABITACIONES ");
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
            Console.Clear();
            Console.WriteLine("=== REGISTRAR HABITACIÓN ===");

            if (totalHabitaciones >= 20)
            {
                Console.WriteLine("No se pueden registrar más habitaciones.");
                Console.ReadKey();
                return;
            }

            // --- VALIDAR NÚMERO DE HABITACIÓN ---
            int numero;
            bool valido = false;
            do
            {
                Console.Write("Ingrese el número de la habitación: ");
                string entrada = Console.ReadLine();

                // Validar que sea un número positivo
                if (int.TryParse(entrada, out numero) && numero > 0)
                {
                    // Comprobar si ya existe
                    bool existe = false;
                    for (int i = 0; i < totalHabitaciones; i++)
                    {
                        if (numHabitacion[i] == numero)
                        {
                            existe = true;
                            break;
                        }
                    }

                    if (existe)
                    {
                        Console.WriteLine("Ese número de habitación ya está registrado. Intente con otro.");
                    }
                    else
                    {
                        valido = true;
                    }
                }
                else
                {
                    Console.WriteLine("Número inválido. Ingrese solo números positivos.");
                }

            } while (!valido);

            // --- VALIDAR TIPO DE HABITACIÓN ---
            string tipo = "";
            do
            {
                Console.Write("Ingrese el tipo de habitación (Individual, Doble, Suite): ");
                tipo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tipo))
                {
                    Console.WriteLine("El tipo no puede estar vacío.");
                }
            } while (string.IsNullOrWhiteSpace(tipo));

            // --- VALIDAR PRECIO ---
            double precio;
            valido = false;
            do
            {
                Console.Write("Ingrese el precio por noche: ");
                string entradaPrecio = Console.ReadLine();
                if (double.TryParse(entradaPrecio, out precio) && precio > 0)
                {
                    valido = true;
                }
                else
                {
                    Console.WriteLine("Precio inválido. Ingrese un número mayor a 0.");
                }
            } while (!valido);

            // --- GUARDAR EN LOS VECTORES ---
            numHabitacion[totalHabitaciones] = numero;
            tipoHabitacion[totalHabitaciones] = tipo;
            precioHabitacion[totalHabitaciones] = precio;
            disponible[totalHabitaciones] = true;
            totalHabitaciones++;

            Console.WriteLine("Habitación registrada correctamente.");
            Console.ReadKey();
        }

        static void VerListaHabitaciones()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE HABITACIONES ===");
            if (totalHabitaciones == 0)
            {
                Console.WriteLine("No hay habitaciones registradas.");
            }
            else
            {
                for (int i = 0; i < totalHabitaciones; i++)
                {
                    string estado = disponible[i] ? "Disponible" : "Ocupada";
                    Console.WriteLine($"Habitación {numHabitacion[i]} - {tipoHabitacion[i]} - Precio: {precioHabitacion[i]} - {estado}");
                }
            }
            Console.ReadKey();

        }

        static void EditarHabitacion()
        {
            Console.Write("Ingrese el número de habitación a editar: ");
            string entrada = Console.ReadLine();
            int numero;
            if (!int.TryParse(entrada, out numero))
            {
                Console.WriteLine("Número inválido.");
                Console.ReadKey();
                return;
            }

            bool encontrada = false;

            for (int i = 0; i < totalHabitaciones; i++)
            {
                if (numHabitacion[i] == numero)
                {
                    Console.Write("Nuevo tipo: ");
                    string nuevoTipo = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoTipo))
                        tipoHabitacion[i] = nuevoTipo;

                    Console.Write("Nuevo precio: ");
                    string entradaPrecio = Console.ReadLine();
                    double nuevoPrecio;
                    if (double.TryParse(entradaPrecio, out nuevoPrecio) && nuevoPrecio > 0)
                        precioHabitacion[i] = nuevoPrecio;
                    else
                        Console.WriteLine("Precio no modificado (entrada inválida).");

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
            Console.Clear();
            Console.WriteLine("=== DISPONIBILIDAD DE HABITACIONES ===");
            bool alguna = false;
            for (int i = 0; i < totalHabitaciones; i++)
            {
                if (disponible[i])
                {
                    Console.WriteLine($"Habitación {numHabitacion[i]} disponible ({tipoHabitacion[i]})");
                    alguna = true;
                }
            }
            if (!alguna)
                Console.WriteLine("No hay habitaciones disponibles.");
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
            string nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Nombre inválido.");
                Console.ReadKey();
                return;
            }

            Console.Write("Documento de identidad: ");
            string documento = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(documento))
            {
                Console.WriteLine("Documento inválido.");
                Console.ReadKey();
                return;
            }

            // Verificar duplicado por documento
            for (int i = 0; i < totalHuespedes; i++)
            {
                if (documentoHuesped[i] == documento)
                {
                    Console.WriteLine("Ya existe un huésped con ese documento.");
                    Console.ReadKey();
                    return;
                }
            }

            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();

            nombreHuesped[totalHuespedes] = nombre;
            documentoHuesped[totalHuespedes] = documento;
            telefonoHuesped[totalHuespedes] = telefono;
            totalHuespedes++;

            Console.WriteLine("Huésped registrado correctamente.");
            Console.ReadKey();
        }

        static void VerListaHuespedes()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE HUÉSPEDES ===");
            if (totalHuespedes == 0)
            {
                Console.WriteLine("No hay huéspedes registrados.");
            }
            else
            {
                for (int i = 0; i < totalHuespedes; i++)
                {
                    Console.WriteLine($"{i + 1}. {nombreHuesped[i]} - Doc: {documentoHuesped[i]} - Tel: {telefonoHuesped[i]}");
                }
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
                    Console.Write("Nuevo nombre (enter para dejar igual): ");
                    string nuevoNombre = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoNombre))
                        nombreHuesped[i] = nuevoNombre;

                    Console.Write("Nuevo teléfono (enter para dejar igual): ");
                    string nuevoTelefono = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoTelefono))
                        telefonoHuesped[i] = nuevoTelefono;

                    Console.WriteLine("Datos actualizados correctamente.");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
                Console.WriteLine("Huésped no encontrado.");

            Console.ReadKey();
        }

        //------------Gestión de Reservas------------
        static void GestionReservas()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE RESERVAS ===");
                Console.WriteLine("1. Registrar reserva");
                Console.WriteLine("2. Ver reservas");
                Console.WriteLine("3. Cancelar reserva");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": RegistrarReserva(); break;
                    case "2": VerReservas(); break;
                    case "3": CancelarReserva(); break;
                    case "4": break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != "4");
        }

        static void RegistrarReserva()
        {
            if (totalReservas >= 20)
            {
                Console.WriteLine("No se pueden registrar más reservas.");
                Console.ReadKey();
                return;
            }

            Console.Write("Documento del huésped: ");
            string doc = Console.ReadLine();
            int indiceHuesped = -1;

            for (int i = 0; i < totalHuespedes; i++)
            {
                if (documentoHuesped[i] == doc)
                {
                    indiceHuesped = i;
                    break;
                }
            }

            if (indiceHuesped == -1)
            {
                Console.WriteLine("Huésped no registrado.");
                Console.ReadKey();
                return;
            }

            Console.Write("Número de habitación a reservar: ");
            string entradaHab = Console.ReadLine();
            int numero;
            if (!int.TryParse(entradaHab, out numero))
            {
                Console.WriteLine("Número inválido.");
                Console.ReadKey();
                return;
            }

            int indiceHab = -1;

            for (int i = 0; i < totalHabitaciones; i++)
            {
                if (numHabitacion[i] == numero && disponible[i])
                {
                    indiceHab = i;
                    break;
                }
            }

            if (indiceHab == -1)
            {
                Console.WriteLine("Habitación no disponible o inexistente.");
                Console.ReadKey();
                return;
            }

            reservaHuesped[totalReservas] = nombreHuesped[indiceHuesped];
            reservaHabitacion[totalReservas] = numHabitacion[indiceHab];
            disponible[indiceHab] = false;
            totalReservas++;

            Console.WriteLine("Reserva registrada correctamente.");
            Console.ReadKey();
        }

        static void VerReservas()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE RESERVAS ===");
            if (totalReservas == 0)
            {
                Console.WriteLine("No hay reservas registradas.");
            }
            else
            {
                for (int i = 0; i < totalReservas; i++)
                {
                    Console.WriteLine($"{i + 1}. Huésped: {reservaHuesped[i]} - Habitación: {reservaHabitacion[i]}");
                }
            }
            Console.ReadKey();
        }

        static void CancelarReserva()
        {
            Console.Write("Ingrese el número de habitación de la reserva a cancelar: ");
            string entrada = Console.ReadLine();
            int numero;
            if (!int.TryParse(entrada, out numero))
            {
                Console.WriteLine("Número inválido.");
                Console.ReadKey();
                return;
            }

            bool encontrada = false;

            for (int i = 0; i < totalReservas; i++)
            {
                if (reservaHabitacion[i] == numero)
                {
                    for (int j = i; j < totalReservas - 1; j++)
                    {
                        reservaHuesped[j] = reservaHuesped[j + 1];
                        reservaHabitacion[j] = reservaHabitacion[j + 1];
                    }

                    totalReservas--;
                    encontrada = true;

                    for (int k = 0; k < totalHabitaciones; k++)
                    {
                        if (numHabitacion[k] == numero)
                            disponible[k] = true;
                    }

                    Console.WriteLine("Reserva cancelada correctamente.");
                    break;
                }
            }

            if (!encontrada)
                Console.WriteLine("Reserva no encontrada.");

            Console.ReadKey();
        }
    }
}

