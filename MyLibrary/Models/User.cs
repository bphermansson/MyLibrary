using MyLibrary.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class User:iUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
