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
    public class AddStudentValidator : AbstractValidator<AddStudentRequest>, IAddStudentValidator 
    {
        public AddStudentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull().WithMessage("Email is not valid.");
        }
    }
}
