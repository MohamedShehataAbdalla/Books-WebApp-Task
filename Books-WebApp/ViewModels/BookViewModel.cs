using Books_WebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace Books_WebApp.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Text)]
        public string Author { get; set; }

        [DisplayName("Category")]
        public byte CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}