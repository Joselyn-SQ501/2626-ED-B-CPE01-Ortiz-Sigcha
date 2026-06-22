using System;

namespace AgendaClinica.Modelo
{
    // Clase que representa una cita médica
    class Turno
    {
        // Almacena la información del paciente
        public Paciente PacienteInfo { get; set; }
        
        // Almacena el nombre del médico
        public string Medico { get; set; }
        
        // Almacena la fecha y hora de la consulta
        public HorarioConsulta Horario { get; set; }

        // Constructor que inicializa los datos del turno
        public Turno(Paciente paciente, string medico, HorarioConsulta horario)
        {
            PacienteInfo = paciente;
            Medico = medico;
            Horario = horario;
        }

        // Método que muestra los detalles del turno
        public void MostrarDetalleTurno()
        {
            Console.Write("Paciente: ");
            PacienteInfo.MostrarInformacion();
            Console.WriteLine(" | Médico: " + Medico + " | Hora: " + Horario.Hora);
        }
    }
}
