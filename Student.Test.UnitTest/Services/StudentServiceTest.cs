using AutoMapper;
using FizzWare.NBuilder;
using Moq;
using Moq.AutoMock;
using Student.Domain.DTOs;
using Student.Domain.Interfaces.Repositories;
using Student.Domain.Interfaces.Validators;
using Student.Service.AutoMapper;
using Student.Service.Services;
using System.Threading;
using Xunit;

namespace Student.Test.UnitTest.Services
{
    public class StudentServiceTest
    {
        private readonly StudentService _service;
        private readonly AutoMocker _mocker;
        private readonly Guid _hashStudent;
        private readonly CancellationToken _cancellationToken;

        public StudentServiceTest()
        {
            _mocker = new AutoMocker();
            _mocker.Use(LoadMapper());
            _service = _mocker.CreateInstance<StudentService>();
            _hashStudent = Guid.NewGuid();
            _cancellationToken = CancellationToken.None;
        }

        public static IMapper LoadMapper()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StudentAutoMapper>();
            });
            return mapper.CreateMapper();
        }

        [Fact]
        public async Task GetStudent_ReturnsStudent()
        {
            var request = CreateStudentRequest(_hashStudent);
            var repoMock = _mocker.GetMock<IStudentRepository>();
            var validationMock = _mocker.GetMock<IStudentValidator>();

            repoMock.Setup(x => x.GetStudentByHash(_cancellationToken, It.IsAny<Guid>()))
                .ReturnsAsync(CreateStudent);

            validationMock.Setup(x => x.Validate(It.IsAny<StudentRequest>())).Returns(new FluentValidation.Results.ValidationResult());

            var response = await _service.GetAsync(_cancellationToken, request);

            Xunit.Assert.NotNull(response);
            Xunit.Assert.Equal(response.Hash, _hashStudent);
        }

        [Fact]
        public async Task GetStudent_DoNotReturnsStudent()
        {
            var request = CreateStudentRequest(Guid.NewGuid());
            var repoMock = _mocker.GetMock<IStudentRepository>();
            var validationMock = _mocker.GetMock<IStudentValidator>();

            repoMock.Setup(x => x.GetStudentByHash(_cancellationToken, It.IsAny<Guid>()))
                .ReturnsAsync(CreateStudent);

            validationMock.Setup(x => x.Validate(It.IsAny<StudentRequest>())).Returns(new FluentValidation.Results.ValidationResult());

            var response = await _service.GetAsync(_cancellationToken, request);

            Xunit.Assert.NotNull(response);
            Xunit.Assert.Equal(response.Hash, _hashStudent);
        }

        [Fact]
        public async Task AddStudent_ShouldInsertStudent()
        {
            var request = CreateAddStudentRequest();

            var repoMock = _mocker.GetMock<IStudentRepository>();
            var validationMock = _mocker.GetMock<IAddStudentValidator>();

            repoMock.Setup(x => x.InsertStudent(_cancellationToken, It.IsAny<Domain.Entities.Student>()))
                .ReturnsAsync(1).Verifiable();

            validationMock.Setup(x => x.Validate(It.IsAny<AddStudentRequest>())).Returns(new FluentValidation.Results.ValidationResult());

            var response = await _service.InsertAsync(_cancellationToken, request);

            Xunit.Assert.NotNull(response);
            repoMock.Verify(x => x.InsertStudent(_cancellationToken, It.IsAny<Domain.Entities.Student>()), Times.Once());
        }

        private StudentRequest CreateStudentRequest(Guid hash)
        {
            return Builder<StudentRequest>
                .CreateNew()
                    .With(x => x.Hash = hash)
                .Build();
        }

        private AddStudentRequest CreateAddStudentRequest()
        {
            return Builder<AddStudentRequest>
                .CreateNew()
                .Build();
        }

        private Domain.Entities.Student CreateStudent()
        {
            return Builder<Domain.Entities.Student>
                .CreateNew()
                    .With(x => x.Hash = _hashStudent)
                .Build();
        }
    }
}
