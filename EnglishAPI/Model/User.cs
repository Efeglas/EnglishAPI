using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnglishAPI.Model
{
    public class User
    {  
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
