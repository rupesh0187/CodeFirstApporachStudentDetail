using Microsoft.EntityFrameworkCore;
namespace StudentDetail.Models.Context
{
    public class StudentDBContext : DbContext 
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
