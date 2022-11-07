using FuncionesLinq.Models;
using UniversidadInterfaces.Interfaces;

namespace UniversidadInterfaces.Servicios
{
    public class estudios : Iestudios
    {
        public string cursosPorCategoria(int cantidad)
        {
            string mensaje = string.Empty;
            if (cantidad > 0)
                mensaje = "En hora buena, hay resultados";
            else
                mensaje = "Lo siento, no hay resultados";

            return mensaje;
        }


        public string alumnosConCursos(int cantidad)
        {
            string mensaje = string.Empty;
            if (cantidad > 0)
                mensaje = "En hora buena, hay resultados";
            else
                mensaje = "Lo siento, no hay resultados";

            return mensaje;
        }


    }
}
