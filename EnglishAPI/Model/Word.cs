using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishAPI.Model
{
    public class Word
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public Category Category { get; set; } = null!;
        public User User { get; set; } = null!;
        
        [Column(TypeName = "varchar(50)")]
        public string En { get; set; }
        [Column(TypeName = "varchar(50)")]
        
        public string Hu { get; set; }

        [DefaultValue(true)]
        public bool Visible { get; set; } = true;
    }
}
