using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SocialDbContext _ctx;
        public StudentRepository(SocialDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Student> CreateStudent(Student payload)
        {
            Student  student = new Student();
            student.Name = payload.Name;
            student.Class= payload.Class;
            _ctx.Students.Add(student);
            await _ctx.SaveChangesAsync();
            return student;
        }

        public async Task DeleteStudent(int studentId)
        {
            var student = _ctx.Students.FirstOrDefaultAsync(p => p.Id == studentId);
            if (student == null) return;
            _ctx.Remove(student);
            await _ctx.SaveChangesAsync();
        }

        public async Task<ICollection<Student>> GetAllStudents()
        {
            return await _ctx.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _ctx.Students.FirstOrDefaultAsync(p => p.Id == studentId);
        }

        public async Task<Student> UpdateStudent(Student payload, int studentId)
        {
            var check = _ctx.Students.FirstOrDefaultAsync(p => p.Id == studentId);
            if (check == null) { return null; }
            Student student= new Student();
            student.Name = payload.Name;
            student.Class= payload.Class;
            await _ctx.SaveChangesAsync();
            return student;
        }
    }
}
