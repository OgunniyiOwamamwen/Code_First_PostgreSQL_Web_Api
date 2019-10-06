using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Code_First_PostgreSQL_Web_Api.Models
{
    public class AuthorBiography
    {
        [Key]
        public int AuthorBiographyId { get; set; }
        public string Biography { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
