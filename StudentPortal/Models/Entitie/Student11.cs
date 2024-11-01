using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models.Entitie
{
    public class Student11
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public int Percentage { get; set; }
        
        public int? StudentId {  get; set; }
        public Student Student { get; set; }

        List<Student>Students { get; set; }
        
    }
}
