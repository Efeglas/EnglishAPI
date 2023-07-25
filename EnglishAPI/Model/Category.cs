using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishAPI.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public ICollection<Word> Words { get; } = new List<Word>();

        [DefaultValue(true)]
        public bool Visible { get; set; } = true;
    }
}
