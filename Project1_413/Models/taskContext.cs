using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project1_413.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> yeetings) : base (yeetings)
        {

        }
        public DbSet<TaskResponse> TaskResponses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category
                    {
                        CategoryId = 1,
                        CategoryName = "Home"
                    },
                    new Category
                    {
                        CategoryId = 2,
                        CategoryName = "School"
                    },
                    new Category
                    {
                        CategoryId = 3,
                        CategoryName = "Work"
                    },
                    new Category
                    {
                        CategoryId = 4,
                        CategoryName = "Church"
                    }
                );
            mb.Entity<TaskResponse>().HasData(

                new TaskResponse
                {
                    Id = 1,
                    Task = "test",
                    Completed = false,
                    Quadrant = 1,
                    DueDate = "2009-01-01",
                    CategoryId = 1
                }
            );
        }
    }
}
