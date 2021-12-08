using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using Students.Data.Entites;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Students.Data
{
    public class StudentSeeder
    {
        private readonly StudentContext _ctx;
        private readonly IWebHostEnvironment _env;

        public StudentSeeder(StudentContext ctx, IWebHostEnvironment env)
        {
            _ctx = ctx;
            _env = env;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Students.Any())
            {
                //Need to create the Sample Data
                var filePath = Path.Combine(_env.ContentRootPath, "Data/students.json");
                var json = File.ReadAllText(filePath);
                var students = JsonSerializer.Deserialize<IEnumerable<Student>>(json);

                _ctx.Students.AddRange(students);
                _ctx.SaveChanges();
            }
        }
    }
}
