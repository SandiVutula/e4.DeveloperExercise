using e4.WebApi.Model;

namespace e4.WebApi.Repository
{
    public class StudentRepository : IDisposable
    {
        private readonly StudentDbContext _context;

        public StudentRepository()
        {
            _context = new StudentDbContext();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
