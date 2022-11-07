using FuncionesLinq.Models;

namespace UniversidadInterfaces.Interfaces
{
    public interface Iestudios
    {
        string cursosPorCategoria(int c);

        string alumnosConCursos(int c);

    }
}
