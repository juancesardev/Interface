using System.ComponentModel.DataAnnotations;

namespace FuncionesLinq.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public int Edad { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
