using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project1_413.Models
{
    public class taskResponse
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string task { get; set; }
        public string dueDate { get; set; }
        public int quadrant { get; set; }
        public bool completed { get; set; }

        public int CategoryId { get; set; }
        public category Category { get; set; }
    }
}
