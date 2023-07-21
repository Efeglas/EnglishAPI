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
            var user = db.Users.Where<User>(u => u.Username == model.Username).First();

            PasswordHasher<User> pwh = new PasswordHasher<User>();
            string hash = pwh.HashPassword(user, "valami");
            
            Console.WriteLine(hash);
            string test = "AQAAAAEAACcQAAAAEF3VsTce8p3Vm1HxpB7rNSXN9ZdrCaMS5UvG4CcKDGHg/TtTFHScXMfhxEA32V2dTQ==";
            if (pwh.VerifyHashedPassword(user, test, "valami") == PasswordVerificationResult.Success)
            {
                Console.WriteLine("OK");
            }
            else {
                Console.WriteLine("NOK");
            }
            //Console.WriteLine(user.Username);
            //Console.WriteLine(user.Password);

            if (model.Username == "admin" && model.Password == "admin")
            {
                Response.Cookies.Append("token", "valamitest", new CookieOptions() { 
                    Expires = DateTime.Now.AddDays(1),
                    Path = "/",                                 
                });
                
                return Ok(new MyResponse("Successful login"));
            }      

            return Unauthorized();         
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
