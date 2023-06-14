using Task.Models;

namespace Task.Repository
{
    public interface ISubjectRepository
    {
        Subject GetSubject(int id);
        Subject Create(Subject subject);
        Subject Update(Subject subject);
        Subject Delete(int id);
        IQueryable<Subject> GetAllSubjects();
    }
}
