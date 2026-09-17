using Microsoft.AspNetCore.Mvc;
using WebHW2.Models;

namespace WebHW2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static readonly List<Student> students = new()
        {
            new Student
            {
                Id = 1,
                Name = "Almat",
                Age = 34
            },

            new Student
            {
                Id = 2,
                Name = "Alfred",
                Age = 38
            }
        };


        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            return Ok(students);
        }


        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }


        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            student.Id = students.Count + 1;

            students.Add(student);

            return Ok(student);
        }
    }
}