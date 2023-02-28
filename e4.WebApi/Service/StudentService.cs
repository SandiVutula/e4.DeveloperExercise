using e4.WebApi.Model;
using e4.WebApi.Repository;

namespace e4.WebApi.Service
{
    public class StudentService : IDisposable
    {
        private readonly StudentRepository _repository;

        public StudentService()
        {
            _repository = new StudentRepository();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _repository.GetAllStudents();
        }

        public Student GetStudentById(int id)
        {
            return _repository.GetStudentById(id);
        }

        public void AddStudent(Student student)
        {
            _repository.AddStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }

}
