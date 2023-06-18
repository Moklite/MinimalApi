using Domain.Models;

namespace MinimalApi.Filiters
{
    public class StudentValidationFilters : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync
            (EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            var student = context.GetArgument<Student>(1);
            if (string.IsNullOrEmpty(student.Name) && string.IsNullOrEmpty(student.Class))
                return await Task.FromResult(Results.BadRequest("Student not valid"));

            return await next(context);
        }
    }
}
