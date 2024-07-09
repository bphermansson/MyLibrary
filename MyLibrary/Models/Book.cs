using MyLibrary.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class Book:iBook
    {
        [Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
	}
}
