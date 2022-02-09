using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project1_413.Models
{
    public class taskContext : DbContext
    {
        public taskContext(DbContextOptions<taskContext> yeetings) : base (yeetings)
        {

        }
        public DbSet<taskResponse> taskResponses { get; set; }
        public DbSet<category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<category>().HasData(
                    new category
                    {
                        CategoryId = 1,
                        Category = "Home"
                    },
                    new category
                    {
                        CategoryId = 2,
                        Category = "School"
                    },
                    new category
                    {
                        CategoryId = 3,
                        Category = "Work"
                    },
                    new category
                    {
                        CategoryId = 4,
                        Category = "Church"
                    }
                );
            mb.Entity<taskResponse>().HasData(

                new taskResponse
                {
                    Id = 1,
                    task = "test",
                    completed = false,
                    quadrant = 1,
                    dueDate = "2009-01-01",
                    CategoryId = 1
                }
            );
        }
    }
}
