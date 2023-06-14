using Task.Models;

namespace Task.Repository
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);
        Student Create(Student student);
        Student Update(Student student);
        Student Delete(int id);
        IQueryable<Student> GetAllStudents();
    }
}
