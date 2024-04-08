using FizzWare.NBuilder;
using Moq;
using Moq.AutoMock;
using Student.Domain.DTOs;
using Student.Domain.Interfaces.Repositories;
using Student.Service.Services;
using Xunit;

namespace Student.Test.UnitTest.Services
{
    public class StudentServiceTest
    {
        private readonly StudentService _service;
        private readonly AutoMocker _mocker;
        private readonly Guid _hashStudent;

        public StudentServiceTest()
        {
            _mocker = new AutoMocker();
            _service = _mocker.CreateInstance<StudentService>();
            _hashStudent = Guid.NewGuid();
        }

        [Fact]
        public async Task GetStudent_ReturnsStudent()
        {
            var request = CreateStudentRequest(_hashStudent);
            var repoMock = _mocker.GetMock<IStudentRepository>();

            repoMock.Setup(x => x.GetStudentByHash(It.IsAny<Guid>()))
                .ReturnsAsync(CreateStudent);

            var response = await _service.GetAsync(request);

            Xunit.Assert.NotNull(response);
            Xunit.Assert.Equal(response.Hash, _hashStudent);
        }

        [Fact]
        public async Task GetStudent_DoNotReturnsStudent()
        {
            var request = CreateStudentRequest(Guid.NewGuid());
            var repoMock = _mocker.GetMock<IStudentRepository>();

            repoMock.Setup(x => x.GetStudentByHash(It.IsAny<Guid>()))
                .ReturnsAsync(CreateStudent);

            var response = await _service.GetAsync(request);

            Xunit.Assert.NotNull(response);
            Xunit.Assert.NotEqual(response.Hash, _hashStudent);
        }

        private StudentRequest CreateStudentRequest(Guid hash)
        {
            return Builder<StudentRequest>
                .CreateNew()
                    .With(x => x.Hash = hash)
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
