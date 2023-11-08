using Intranet.DBContexts;
using Intranet.Models;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _dbContext;
        public StudentRepository(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteStudent(int studentId)
        {
            var student = _dbContext.Students.Find(studentId);
            _dbContext.Students.Remove(student);
            Save();
        }
        public Student GetStudentById(int studentId)
        {
            var stud = _dbContext.Students.Find(studentId);
            _dbContext.Entry(stud).Reference(s => s.StudentMajor).Load();
            return stud;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _dbContext.Students.Include(s => s.StudentMajor).ToList();
        }
        public void InsertStudent(Student student)
        {
            _dbContext.Add(student);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            _dbContext.Entry(student).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}