using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Test
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
