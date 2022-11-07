using System.ComponentModel.DataAnnotations;

namespace FuncionesLinq.Models
{
    public class Inscritos
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Administrador")]
        public int Addby { get; set; }
        [Required]
        [Display(Name = "Alumno")]
        public int Idalumno { get; set; }
        [Required]
        [Display(Name = "Curso")]
        public int Idcurso { get; set; }
        public bool Status { get; set; } = true;
        public DateTime FechaAdd { get; set; } = DateTime.Now;
        
    }
}
