using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Models;

namespace Task.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }
        public Teacher Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public Teacher Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }
            return teacher;
        }

        public IQueryable<Teacher> GetAllTeachers()
        {
            return _context.Teachers;
        }

        public Teacher GetTeacher(int id)
        {
            return _context.Teachers.Find(id);
        }

        public Teacher Update(Teacher updatedTeacher)
        {
            var teacher = _context.Teachers.Attach(updatedTeacher);

            teacher.State = EntityState.Modified;
            _context.SaveChanges();
            return updatedTeacher;
        }
    }
}
