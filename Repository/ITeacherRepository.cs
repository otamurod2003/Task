using Task.Models;

namespace Task.Repository
{
    public interface ITeacherRepository
    {
        Teacher GetTeacher(int id);
        Teacher Create(Teacher teacher);
        Teacher Update(Teacher teacher);
        Teacher Delete(int id);
        IQueryable<Teacher> GetAllTeachers();
    }
}
