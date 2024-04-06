using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Student.Domain.DTOs;
using Student.Domain.Interfaces.Repositories;
using Student.Domain.Interfaces.Services;
using Student.Domain.Interfaces.Validators;

namespace Student.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentValidator _studentValidator;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository,
            IStudentValidator studentValidator,
            IMapper mapper)
        {
            _studentRepository = studentRepository;
            _studentValidator = studentValidator;
            _mapper = mapper;
        }

        public async Task<StudentResponse> GetAsync(StudentRequest request)
        {
            ValidationResult validationResult = _studentValidator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var student = await _studentRepository.GetStudentByHash(request.Hash);

            return _mapper.Map<StudentResponse>(student);
        }
    }
}
