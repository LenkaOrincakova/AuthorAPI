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

    public class AuthorsController:ControllerBase
    {
        private IAuthorsService authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            this.authorsService = authorsService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Author>>> GetAuthors([FromQuery] int? id)
        {
            try
            {
                IList<Author> authors = await authorsService.GetAuthorsAsync();
                return Ok(authors);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor([FromBody] Author author)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Author added = await authorsService.AddAuthorAsync(author);
                return Created($"/{added.Id}", added);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
