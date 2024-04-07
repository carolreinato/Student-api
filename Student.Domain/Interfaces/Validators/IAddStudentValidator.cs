using FluentValidation.Results;
using Student.Domain.DTOs;

namespace Student.Domain.Interfaces.Validators
{
    public interface IAddStudentValidator
    {
        ValidationResult Validate(AddStudentRequest request);
    }
}
