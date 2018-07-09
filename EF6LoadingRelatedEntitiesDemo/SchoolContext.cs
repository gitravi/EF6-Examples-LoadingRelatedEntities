using EF6LoadingRelatedEntitiesDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6LoadingRelatedEntitiesDemo
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<SchoolContext>(new SchoolDBInitializer());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }

    public class SchoolDBInitializer : CreateDatabaseIfNotExists<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            List<Standard> defaultStandards = new List<Standard>();
            defaultStandards.Add(new Standard
            {
                Id = 1,
                Name = "First",
                Students = new List<Student> {
                new Student{Id=1, Name="Student 1"},
                new Student{Id=2, Name="Student 2"},
                new Student{Id=3, Name="Student 3"},
                new Student{Id=4, Name="Student 4"},
                new Student{Id=5, Name="Student 5"},
            }
            });
            defaultStandards.Add(new Standard
            {
                Id = 2,
                Name = "Second",
                Students = new List<Student> {
                new Student{Id=6, Name="Student 6"},
                new Student{Id=7, Name="Student 7"},
                new Student{Id=8, Name="Student 8"},
                new Student{Id=9, Name="Student 9"},
                new Student{Id=10, Name="Student 10"},
            }
            });
            defaultStandards.Add(new Standard { Id = 3, Name = "Second" });
            defaultStandards.Add(new Standard { Id = 4, Name = "Third" });
            defaultStandards.Add(new Standard { Id = 5, Name = "Fourth" });
            context.Standards.AddRange(defaultStandards);
            base.Seed(context);
        }
    }
}
