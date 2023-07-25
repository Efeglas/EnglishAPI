using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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
        public ICollection<Word> Words { get; } = new List<Word>();

        [DefaultValue(true)]
        public bool Visible { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
