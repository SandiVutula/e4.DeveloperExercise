using e4.WebApi.Model;
using e4.WebApi.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Web.Http.ModelBinding;


namespace e4.WebApi.Controllers
{
    public class StudentController : ApiController
    {
        private readonly StudentService _service;

        public StudentController()
        {
            _service = new StudentService();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetAllStudent")]
        public IHttpActionResult GetStudents()
        {
            var students = _service.GetAllStudents().Take(3);
            return Json(students);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetStudent")]
        public IHttpActionResult GetStudent(int id)
        {
            var student = _service.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Json(student);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AddStudent")]
        public IHttpActionResult AddStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.AddStudent(student);
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("DeleteStudent")]
        public IHttpActionResult DeleteStudent(int id)
        {
            var student = _service.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            _service.DeleteStudent(id);
            return Ok();
        }
    }
}
