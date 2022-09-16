using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AppServiceLayer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminRepositoryDAL<Admins> adminRepositoryDAL;
        public AdminController(IAdminRepositoryDAL<Admins> adminRepositoryDAL)
        {
            this.adminRepositoryDAL = adminRepositoryDAL;
        }
        [HttpPost]
        [Route("Save")]
        //[Consumes("application/json")]
        public IActionResult SaveAdmin([FromBody] Admins admin)
        {
            try
            {
                var saved = adminRepositoryDAL.SaveAdmin(admin);
                if (saved)
                {
                    return Ok();
                }


            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("Login", Name = "Login")]
        // [Consumes("application/json")]
        public IActionResult Login([FromBody] Admins admin)
        {

            try
            {

                var IsValid = adminRepositoryDAL.ValidateAdmin(admin);
                if (IsValid)
                {

                    return Ok();
                }


            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("UpdatesBooks")]
        [Consumes("application/json")]
        public IActionResult UpdateBook([FromBody] Books book)
        {
            var result = adminRepositoryDAL.UpdateBook(book);
            if (result)
            {
                return Accepted();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Logout")]
        //[Consumes("application/json")]
        public bool Logout()
        {

            try
            {


                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
          
        }
       
       [HttpPost]


       [Route("Savebook")]
        [Consumes("application/json")]
        public IActionResult SaveBook([FromBody] Books book)
        {
            try
            {
                var saved = adminRepositoryDAL.SaveBook(book);
                if(saved)
                {
                    return Ok(); 
                }


            }
            catch (Exception ex)
            { 
                return Ok(); 
            }
            return BadRequest();
        }


        [HttpDelete]
        [Route("Delete/{id}", Name = "Delete")]
        [Consumes("application/json")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var IsDeleted = adminRepositoryDAL.DeleteBook(id);
                if (IsDeleted)
                {
                    return Ok();
                }






            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return BadRequest();
        }



    }
}

