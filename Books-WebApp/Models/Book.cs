using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Books_WebApp.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        [MaxLength(250)]
        public string Author { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Category")]
        public byte CategoryId { get; set; }
        public Category Categories { get; set; }
    }
}