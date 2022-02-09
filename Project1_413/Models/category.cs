using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1_413.Models
{
    public class category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
