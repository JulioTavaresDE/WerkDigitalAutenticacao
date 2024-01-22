using Microsoft.AspNetCore.Mvc;
using PrjWerkdigital.Context;
using PrjWerkdigital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace PrjWerkdigital.Controllers
{
    [Route("Controller")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Post(UserModel userModel)
        {
            if (userModel is null)
            {
                return BadRequest();
            }

            _context.Users.Add(userModel);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ReturnUser", new { id = userModel.Id }, userModel);

        }


    }
}
