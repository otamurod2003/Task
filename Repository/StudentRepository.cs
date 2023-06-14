using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Models;

namespace Task.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public Student Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return student;
        }

        public IQueryable<Student> GetAllStudents()
        {
            return _context.Students;
        }

        public Student GetStudent(int id)
        {
            var student = _context.Students.Find(id);
            return student;
        }

        public Student Update(Student updatedStudent)
        {
           var student = _context.Students.Attach(updatedStudent);
            student.State = EntityState.Modified;
            return updatedStudent;
        }
    }
}
