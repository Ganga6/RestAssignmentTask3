using BookModelClass;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SimpleRestServiceAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static readonly List<Book> bookList = new List<Book>()
        {
            new Book("The girl",300,"nkskskhdb23jw","Ganga"),
            new Book("the colour ourple",800,"J:K Rolling","162gSuw72gwV3"),
            new Book("The Alcemist",300,"Shiva Khera","7493GS832YHc2"),
            new Book("Capital",250 ,"Karl Marx","2648gd837GBS4"),
            new Book("aama",900,"Laxmi Prashad Devkota","LA12xm19I45po")

        };
       

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookList;
        }
        // GET: api/Books/5
        [HttpGet]
        [Route("{isbn}")]
        public Book Get(string isbn)
        {
            return bookList.Find(i => i.Isbn13== isbn);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            bookList.Add(value);
        }

        // PUT: api/Books/523hjsdjj232
        [HttpPut("{isbn}")]
        public void Put(string isbn, [FromBody] Book value)
        {
            Book bok = Get(isbn);
            if (bok != null)
            {
                bok.Title = value.Title;
                bok.Author = value.Author;
                bok.PageNumber = value.PageNumber;
                bok.Isbn13=value.Isbn13;
            }


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn}")]
        public void Delete(string isbn)
        {
            Book bok = Get(isbn);
            bookList.Remove(bok);
        }



    }
}
