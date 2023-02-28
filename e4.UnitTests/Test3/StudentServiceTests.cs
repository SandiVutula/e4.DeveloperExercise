using e4.WebApi.Model;
using e4.WebApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e4.UnitTests.Test3
{
    public class StudentServiceTests : IDisposable
    {
        private readonly StudentService _service;

        public StudentServiceTests()
        {
            _service = new StudentService();
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        [Fact]
        public void TestGetAllStudents()
        {
            // Arrange
            var expected = new List<Student>
        {
            new Student { Id = 1, Name = "Sandisiwe", Email = "vutulas@gmail.com" },
            new Student { Id = 2, Name = "Anda", Email = "vutu@gdma.com" },
            new Student { Id = 3, Name = "Yanga", Email = "yanga@e4.com" }
        };

            // Act
            var actual = _service.GetAllStudents();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetStudentById()
        {
            // Arrange
            var expected = new Student { Id = 1, Name = "Sandisiwe", Email = "vutulas@gmail.com" };

            // Act
            var actual = _service.GetStudentById(1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAddStudent()
        {
            // Arrange
            var student = new Student { Name = "Alice", Email = "vutulas@gmail.com" };

            // Act
            _service.AddStudent(student);
            var actual = _service.GetStudentById(student.Id);

            // Assert
            Assert.Equal(student, actual);
        }

        [Fact]
        public void TestDeleteStudent()
        {
            // Arrange
            var id = 1;

            // Act
            _service.DeleteStudent(id);
            var actual = _service.GetStudentById(id);

            // Assert
            Assert.Null(actual);
        }
    }

}
