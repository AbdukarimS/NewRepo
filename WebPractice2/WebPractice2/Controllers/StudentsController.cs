using Microsoft.AspNetCore.Mvc;
using WebPractice2.Models;

namespace WebPractice2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new()
        {
            new Student
            {
                Id = 1,
                Name = "Almat",
                Group = "CS-2001"
            },

            new Student
            {
                Id = 2,
                Name = "Muhit",
                Group = "CS-2003"
            },

            new Student
            {
                Id = 3,
                Name = "Azamat",
                Group = "CS-2002"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            students.Add(student);

            return Ok(student);
        }
    }
}