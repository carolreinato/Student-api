using FluentValidation;
using Student.Domain.DTOs;
using Student.Domain.Interfaces.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Service.Validators
{
    public class StudentValidator : AbstractValidator<StudentRequest>, IStudentValidator
    {
        public StudentValidator()
        {
            RuleFor(x => x.Hash).NotEmpty().NotNull();
        }
    }
}
