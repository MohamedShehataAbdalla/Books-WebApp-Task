
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books_WebApp.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Category")]
        public bool Active { get; set; }

        //public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}