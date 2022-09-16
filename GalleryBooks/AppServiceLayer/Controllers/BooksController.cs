
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;

namespace AppServiceLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepositoryDAL<Books> booksRepositoryDAL;

        public BooksController(IBooksRepositoryDAL<Books> booksRepositoryDAL)
        {

            this.booksRepositoryDAL = booksRepositoryDAL;
        }
        [HttpGet]

        [Route("GetAll")]
        [Consumes("application/json")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = booksRepositoryDAL.GetAllBooks();
                return Ok(books);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetBookById/{id?}")]
        //[Consumes("application/json")]
        public IActionResult GetBookByID(int? id)
        {
            try
            {
                var books = booksRepositoryDAL.GetBookById(id ?? 1256);
                return Ok(books);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return BadRequest();
        }
    }
}
