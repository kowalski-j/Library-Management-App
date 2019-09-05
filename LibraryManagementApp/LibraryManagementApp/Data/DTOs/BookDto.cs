using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WizerTest.API.Data.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
