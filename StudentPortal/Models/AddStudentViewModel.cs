using StudentPortal.Models.Entitie;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class AddStudentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Percentage is required.")]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
        public decimal Percentage { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
