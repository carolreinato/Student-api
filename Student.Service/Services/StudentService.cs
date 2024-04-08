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
        private readonly IAddStudentValidator _addStudentValidator;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository,
            IStudentValidator studentValidator,
            IAddStudentValidator addStudentValidator,
            IMapper mapper)
        {
            _studentRepository = studentRepository;
            _studentValidator = studentValidator;
            _addStudentValidator = addStudentValidator;
            _mapper = mapper;
        }

        public async Task<StudentResponse> GetAsync(CancellationToken cancellationToken, StudentRequest request)
        {
            ValidationResult validationResult = _studentValidator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var student = await _studentRepository.GetStudentByHash(cancellationToken, request.Hash);

            return _mapper.Map<StudentResponse>(student);
        }

        public async Task<ValidationResult> InsertAsync(CancellationToken cancellationToken, AddStudentRequest request)
        {
            ValidationResult validationResult = _addStudentValidator.Validate(request);

            if (!validationResult.IsValid)
                return validationResult;

            var newStudent = _mapper.Map<Domain.Entities.Student>(request);
            newStudent.Hash = Guid.NewGuid();

            var id = await _studentRepository.InsertStudent(cancellationToken, newStudent);

            if (id == 0)
                throw new ValidationException("Can't insert student");

            return validationResult;
        }
    }
}
