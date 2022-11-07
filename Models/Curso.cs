using System.ComponentModel.DataAnnotations;

namespace FuncionesLinq.Models
{
    public enum Nivel { Basic, Medium, Advanced, Expert }
    public enum Categoria { FrontEnd, BackEnd, FullStack }
    public class Curso
    {
        public int Id { get; set; }
        [Required]
        public string? CursoName { get; set; }
        public string? Descripcion { get; set; }
        public Nivel nIvel { get; set; }
        public Categoria Categoria { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
