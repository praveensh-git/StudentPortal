using System.ComponentModel.DataAnnotations;


namespace StudentPortal.Models.Entitie
{
    public class Student
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Pease Enter Name")]
        [RegularExpression(@"^[a-zA-Z .]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage ="Should be Proper EmailAddress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Please enter a valid phone number.")]
        public long Phone { get; set; }
        [Range(1,100,ErrorMessage ="Percentage must be 1 to 100")]
        public int Percentage { get; set; }
        
    }
}
