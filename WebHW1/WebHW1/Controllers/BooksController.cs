using Microsoft.AspNetCore.Mvc;
using WebHW1.Models;

namespace WebHW1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Капитанская дочка",
                Author = "Александр Пушкин",
                Year = 1755
            },
            new Book
            {
                Id = 2,
                Title = "Муму",
                Author = "Иван Тургенев",
                Year = 1803
            },
            new Book
            {
                Id = 3,
                Title = "Абайдың қара сөздері",
                Author = "Абай Құнанбайұлы",
                Year = 1890
            }
        };

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            return Ok(books);
        }

        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            book.Id = books.Count + 1;

            books.Add(book);

            return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
        }
    }
}