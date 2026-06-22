using System;

namespace AgendaClinica.Modelo
{
    // Clase que representa a un paciente de la clínica
    class Paciente
    {
        // Almacena el nombre del paciente
        public string Nombre { get; set; }
        
        // Almacena la edad del paciente
        public int Edad { get; set; }
        
        // Almacena el teléfono del paciente
        public string Telefono { get; set; }

        // Constructor que inicializa los datos del paciente
        public Paciente(string nombre, int edad, string telefono)
        {
            Nombre = nombre;
            Edad = edad;
            Telefono = telefono;
        }

        // Método que muestra la información del paciente en pantalla
        public void MostrarInformacion()
        {
            Console.Write(Nombre + " (" + Edad + " años, Tel: " + Telefono + ")");
        }
    }
}
