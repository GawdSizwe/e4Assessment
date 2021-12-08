using Microsoft.Extensions.Logging;
using Students.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _ctx;
        private readonly ILogger<StudentRepository> _logger;

        public StudentRepository(StudentContext ctx, ILogger<StudentRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _ctx.Students
                   .ToList();
        }

        public IEnumerable<Student> GetAllStudentsByGrade(string grade)
        {
            return _ctx.Students
                       .Where(s => s.Grade == grade)
                       .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void DeleteStudent(int id)
        {
            Student deleteEntity = (Student)_ctx.Students
                       .Where(s => s.Id == id);
            _ctx.Students.Remove(deleteEntity);
        }

        public bool CheckIfExists(int id)
        {
            return _ctx.Students
                       .Any(s => s.Id == id);
        }

    }
}
