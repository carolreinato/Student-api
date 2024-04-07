using FluentValidation.Results;
using Student.Domain.DTOs;

namespace Student.Domain.Interfaces.Validators
{
    public interface IStudentValidator
    {
        ValidationResult Validate(StudentRequest request);
    }
}
