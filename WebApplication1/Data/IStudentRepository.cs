using Students.Data.Entites;
using System.Collections.Generic;

namespace Students.Data
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> GetAllStudentsByGrade(string grade);
        bool SaveAll();
        void AddEntity(object model);
        void DeleteStudent(int id);
        bool CheckIfExists(int id);
    }
}