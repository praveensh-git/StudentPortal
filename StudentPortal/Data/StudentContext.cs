using Microsoft.EntityFrameworkCore;
using StudentPortal.Models.Entitie;

namespace StudentPortal.Data
{
   public  class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options):base(options) 
        {
            
        }
        public DbSet<Student>Students { get; set; }
        public DbSet<Student11> Students11 { get; set; }
    }
}
