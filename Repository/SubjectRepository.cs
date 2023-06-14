using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Models;

namespace Task.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public Subject Create(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return subject;

        }

        public Subject Delete(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
            return subject;
        }

        public IQueryable<Subject> GetAllSubjects()
        {
            return _context.Subjects;
        }

        public Subject GetSubject(int id)
        {
            return _context.Subjects.Find(id);
        }

        public Subject Update(Subject updatedSubject)
        {
            var subject = _context.Subjects.Attach(updatedSubject);

            subject.State = EntityState.Modified;
            _context.SaveChanges();
            return updatedSubject;
        }
    }
}
