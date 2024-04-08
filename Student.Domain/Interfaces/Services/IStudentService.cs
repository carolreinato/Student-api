using FluentValidation.Results;
using Student.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Interfaces.Services
{
    public interface IStudentService
    {
        Task<StudentResponse> GetAsync(CancellationToken cancellationToken, StudentRequest request);
        Task<ValidationResult> InsertAsync(CancellationToken cancellationToken, AddStudentRequest request);
    }
}
