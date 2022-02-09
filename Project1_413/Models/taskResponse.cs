using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project1_413.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Task { get; set; }
        public string DueDate { get; set; }
        public int Quadrant { get; set; }
        public bool Completed { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
