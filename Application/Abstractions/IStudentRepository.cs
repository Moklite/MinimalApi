using Domain.Models;

namespace Application.Abstractions
{
    public interface IStudentRepository
    {
        Task<ICollection<Student>> GetAllStudents();
        Task DeleteStudent (int studentId);
        Task<Student> GetStudentById(int studentId);
        Task<Student> CreateStudent(Student payload);
        Task<Student> UpdateStudent(Student payload, int studentId);
    }
}
