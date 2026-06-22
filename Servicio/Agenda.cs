using System;
using AgendaClinica.Modelo;

namespace AgendaClinica.Servicio
{
    // Clase que controla toda la lógica del sistema de agenda
    class Agenda
    {
        // Vector que guarda todos los turnos registrados (máximo 50)
        private Turno[] vectorTurnos = new Turno[50];
        // Contador de turnos registrados
        private int contadorTurnos = 0;

        // Matriz de 5 horas x 3 médicos para controlar disponibilidad diaria
        private string[,] matrizAgenda = new string[5, 3];

        // Nombres de los médicos disponibles
        private string[] medicos = { "Dr. Perez", "Dra. Gomez", "Dr. Lopez" };
        // Horarios disponibles del día
        private string[] horas = { "08:00 AM", "09:00 AM", "10:00 AM", "11:00 AM", "12:00 PM" };

        // Constructor que inicializa la matriz con todos los horarios disponibles
        public Agenda()
        {
            // Recorremos todas las filas
            for (int i = 0; i < 5; i++)
            {
                // Recorremos todas las columnas
                for (int j = 0; j < 3; j++)
                {
                    // Marcamos cada celda como disponible al inicio
                    matrizAgenda[i, j] = "Disponible";
                }
            }
        }

        // Método para registrar un nuevo turno
        public void AgregarTurno()
        {
            // Validamos que haya espacio en el vector de turnos
            if (contadorTurnos >= 50)
            {
                Console.WriteLine("\n[ERROR] No hay espacio disponible para más turnos en el vector.");
                return;
            }

            Console.WriteLine("\n=== REGISTRO DE NUEVO TURNO ===");
            
            // Solicitamos el nombre del paciente
            Console.Write("Nombre del paciente: ");
            string nombre = Console.ReadLine();
            
            // Solicitamos la edad del paciente
            Console.Write("Edad del paciente: ");
            int edad;
            int.TryParse(Console.ReadLine(), out edad);
            
            // Solicitamos el teléfono del paciente
            Console.Write("Teléfono del paciente: ");
            string telefono = Console.ReadLine();

            // Mostramos los médicos disponibles
            Console.WriteLine("\nSeleccione el Médico:");
            for (int i = 0; i < medicos.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + medicos[i]);
            }
            Console.Write("Opción (1-3): ");
            int opcionMedico;
            int.TryParse(Console.ReadLine(), out opcionMedico);
            int medicoIndex = opcionMedico - 1;

            // Validamos que la opción del médico sea válida
            if (medicoIndex < 0 || medicoIndex >= 3)
            {
                Console.WriteLine("\n[ERROR] Opción de médico no válida.");
                return;
            }

            // Mostramos los horarios disponibles
            Console.WriteLine("\nSeleccione el Horario disponible:");
            for (int i = 0; i < horas.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + horas[i]);
            }
            Console.Write("Opción (1-5): ");
            int opcionHora;
            int.TryParse(Console.ReadLine(), out opcionHora);
            int horaIndex = opcionHora - 1;

            // Validamos que la opción de hora sea válida
            if (horaIndex < 0 || horaIndex >= 5)
            {
                Console.WriteLine("\n[ERROR] Opción de horario no válida.");
                return;
            }

            // Validamos que el horario esté disponible
            if (matrizAgenda[horaIndex, medicoIndex] != "Disponible")
            {
                Console.WriteLine("\n[ERROR] Ese horario ya está asignado al paciente: " + matrizAgenda[horaIndex, medicoIndex]);
                return;
            }

            // Guardamos el nombre del paciente en la matriz para marcar el horario como ocupado
            matrizAgenda[horaIndex, medicoIndex] = nombre;

            // Creamos un nuevo objeto Paciente con los datos ingresados
            Paciente nuevoPaciente = new Paciente(nombre, edad, telefono);
            
            // Creamos un nuevo objeto HorarioConsulta
            HorarioConsulta nuevoHorario = new HorarioConsulta();
            nuevoHorario.Dia = "Hoy";
            nuevoHorario.Hora = horas[horaIndex];

            // Creamos un nuevo objeto Turno con todos los datos
            Turno nuevoTurno = new Turno(nuevoPaciente, medicos[medicoIndex], nuevoHorario);

            // Guardamos el turno en el vector
            vectorTurnos[contadorTurnos] = nuevoTurno;
            // Incrementamos el contador
            contadorTurnos++;

            Console.WriteLine("\n[OK] Turno registrado con éxito.");
        }

        // Método que muestra el historial de todos los turnos registrados
        public void MostrarHistorial()
        {
            Console.WriteLine("\n=== HISTORIAL DE TURNOS REGISTRADOS ===");
            
            // Validamos si hay turnos registrados
            if (contadorTurnos == 0)
            {
                Console.WriteLine("No hay turnos registrados.");
                return;
            }

            // Recorremos y mostramos todos los turnos del vector
            for (int i = 0; i < contadorTurnos; i++)
            {
                Console.Write("Turno #" + (i + 1) + " | ");
                vectorTurnos[i].MostrarDetalleTurno();
            }
        }

        // Método que muestra la agenda diaria en formato de tabla
        public void MostrarAgendaDiaria()
        {
            Console.WriteLine("\n=== AGENDA DIARIA DE TURNOS ===");
            
            // Dibujamos la cabecera de la tabla
            Console.WriteLine("{0,-12} | {1,-15} | {2,-15} | {3,-15}", "Horario", medicos[0], medicos[1], medicos[2]);
            // Dibujamos una línea separadora
            Console.WriteLine(new string('-', 68));

            // Recorremos y mostramos cada fila de la matriz (horas y médicos)
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0,-12} | {1,-15} | {2,-15} | {3,-15}", 
                    horas[i], 
                    matrizAgenda[i, 0], 
                    matrizAgenda[i, 1], 
                    matrizAgenda[i, 2]);
            }
            Console.WriteLine();
        }

        // Método que busca un turno específico por nombre de paciente
        public void BuscarTurno()
        {
            Console.WriteLine("\n=== BUSCAR TURNO POR PACIENTE ===");
            // Solicitamos el nombre del paciente a buscar
            Console.Write("Ingrese el nombre exacto del paciente: ");
            string nombreBuscado = Console.ReadLine();
            // Variable para saber si encontramos el turno
            bool encontrado = false;

            // Recorremos el vector buscando el nombre
            for (int i = 0; i < contadorTurnos; i++)
            {
                // Comparamos el nombre sin importar mayúsculas o minúsculas
                if (vectorTurnos[i].PacienteInfo.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\n[ENCONTRADO] Detalles del turno:");
                    vectorTurnos[i].MostrarDetalleTurno();
                    encontrado = true;
                }
            }

            // Si no encontró el turno, mostramos un mensaje
            if (!encontrado)
            {
                Console.WriteLine("\nNo se encontró ningún turno registrado para: '" + nombreBuscado + "'");
            }
        }
    }
}
