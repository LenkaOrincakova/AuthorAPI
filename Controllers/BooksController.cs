using AuthorAPI.Data;
using AuthorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private IAuthorsService authorsService;

        public BooksController(IAuthorsService authorsService)
        {
            this.authorsService = authorsService;
        }

        //get,

        [HttpGet]
        public async Task<ActionResult<IList<Book>>> GetBooks([FromQuery] int id)
        {
            try
            {
                IList<Book> books = await authorsService.GetBooksAsync();
                return Ok(books);
            }
            catch(Exception e) 
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
       // post, 

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook([FromBody] Book book)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Book added = await authorsService.AddBooksAsync(book);
                return Created($"/{added.ISBN}", added);

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        //delete

        [HttpDelete]
        [Route("{isbn:int}")]
        public async Task<ActionResult> DeleteBook([FromRoute] int isbn)
        {
            try
            {
                await authorsService.RemoveBookAsync(isbn);
                return Ok();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
