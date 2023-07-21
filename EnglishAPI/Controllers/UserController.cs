using EnglishAPI.Model;
using EnglishAPI.RequestModels;
using EnglishAPI.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace EnglishAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        //[HttpPost(template: "Login/{id:int}")]
        [HttpPost(template: "Login")]
        public ActionResult Login([FromBody] LoginRequestModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var db = new MyDbContext();
            var user = db.Users.Where<User>(u => u.Username == model.Username).FirstOrDefault();

            PasswordHasher<User> pwh = new PasswordHasher<User>();
            
            if (user != null && pwh.VerifyHashedPassword(user, user.Password, model.Password) == PasswordVerificationResult.Success)
            {
                Response.Cookies.Append("username", user.Username, new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(1),
                    Path = "/",
                });
                Response.Cookies.Append("userid", user.Id.ToString(), new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(1),
                    Path = "/",
                });

                return Ok(new MyResponse("Successful login"));
            }
            else {
                return Unauthorized();
            }           
        }

        [HttpPost(template: "Register")]
        public ActionResult Register([FromBody] RegisterRequestModel model) {          
         
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                if (model.Valid().Count > 0)
                {
                    return BadRequest(new MyResponse(model.Valid()));
                }

                var db = new MyDbContext();
                var user = db.Users.Where<User>(u => u.Username == model.Username).FirstOrDefault();

                if (user == null)
                {

                    PasswordHasher<User> pwh = new PasswordHasher<User>();
                    string hash = pwh.HashPassword(null, model.Password);

                    User newUser = new User(model.Username, hash);
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return Ok(new MyResponse("Successfully registered"));
                }
                else {
                    return BadRequest(new MyResponse("Username already exists"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        //[HttpGet]
        //public LoginResponse GetLogin(int id)
        //{
        //    return new LoginResponse(false, "Successful login", "data");
        //}
    }
}
