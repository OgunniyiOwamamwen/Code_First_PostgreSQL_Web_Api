using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Code_First_PostgreSQL_Web_Api.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AuthorBiography Biography { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
