using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Students.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Data
{
    public class StudentContext : DbContext
    {
        private readonly IConfiguration _config;

        public StudentContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Student> Students { get; set; }

        //public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        //{
        //}
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Student>();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:StudentContextDb"]);
        }
    }
}
