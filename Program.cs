using System;
using AgendaClinica.Servicio;

namespace AgendaClinica
{
    // Clase principal del programa
    class Program
    {
        // Método principal que se ejecuta cuando iniciamos la aplicación
        static void Main(string[] args)
        {
            // Instanciamos el servicio de Agenda
            Agenda agenda = new Agenda();
            
            // Variable para controlar si el usuario quiere salir
            bool salir = false;

            // Bucle que mantiene el menú principal activo
            while (!salir)
            {
                // Mostramos el menú principal
                Console.WriteLine("==================================================");
                Console.WriteLine("    SISTEMA DE AGENDA DE TURNOS DE PACIENTES      ");
                Console.WriteLine("==================================================");
                Console.WriteLine("  1. Registrar nuevo turno");
                Console.WriteLine("  2. Ver historial de turnos");
                Console.WriteLine("  3. Ver cuadrícula de la agenda diaria");
                Console.WriteLine("  4. Buscar turno por paciente");
                Console.WriteLine("  5. Salir");
                Console.WriteLine("==================================================");
                // Solicitamos la opción del usuario
                Console.Write("Seleccione una opción: ");

                // Leemos la opción ingresada
                string opcion = Console.ReadLine();

                // Evaluamos la opción del usuario
                switch (opcion)
                {
                    // Opción 1: Registrar nuevo turno
                    case "1":
                        agenda.AgregarTurno();
                        break;
                    // Opción 2: Ver historial de turnos
                    case "2":
                        agenda.MostrarHistorial();
                        break;
                    // Opción 3: Ver agenda diaria
                    case "3":
                        agenda.MostrarAgendaDiaria();
                        break;
                    // Opción 4: Buscar turno por paciente
                    case "4":
                        agenda.BuscarTurno();
                        break;
                    // Opción 5: Salir del programa
                    case "5":
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;
                    // Opción inválida
                    default:
                        Console.WriteLine("\n[ERROR] Opción inválida. Intente de nuevo.\n");
                        break;
                }

                // Esperamos entrada del usuario para continuar
                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
