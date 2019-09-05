using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WizerTest.API.Data.DTOs;
using WizerTest.Data.Entities;
using WizerTest.Services.Repository.Interfaces;

namespace WizerTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet(Name = "GetBooks")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        public IActionResult GetBooks()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var books = _bookRepository.GetBooks().ToList();

            var booksDTO = new List<BookDto>();
            foreach (var book in books)
            {
                booksDTO.Add(new BookDto
                {
                    Id = book.Id,
                    Title = book.Title

                });
            }

            return Ok(booksDTO);
        }

        [HttpGet("{bookId}", Name = "GetBook")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        public IActionResult GetBook(int bookId)
        {
            var book = _bookRepository.GetBook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookDTO = new BookDto()
            {
                Id = book.Id,
                Title = book.Title
            };

            return Ok(bookDTO);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Book))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateBook(BookDto bookDto)
        {
            var bookToCreate = new Book
            {
                Title = bookDto.Title
            };

            var createdbook = _bookRepository.CreateBook(bookToCreate);
            return StatusCode(201);

        }

        [HttpPut("{bookId}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult UpdateBook(int bookId, Book Updatedbookinfo)
        {
            var bookToUpdate = new Book
            {
                Title = Updatedbookinfo.Title
            };

            var updatedCategory = _bookRepository.UpdateBook(bookToUpdate);
            return StatusCode(201);

        }

        //api/categoories/categoryId
        [HttpDelete("{bookId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCategory(int bookId)
        {
            var categoryToDelete = _bookRepository.GetBook(bookId);

            if (!ModelState.IsValid)
                return BadRequest();



            var deletedcategory = _bookRepository.DeleteBook(categoryToDelete);

            return NoContent();


        }
    }
}
