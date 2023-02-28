using e4.WebApi.Model;
using System.Data.Entity;

namespace e4.WebApi
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
