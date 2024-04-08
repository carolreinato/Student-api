using FizzWare.NBuilder;
using Moq.AutoMock;
using Student.Domain.DTOs;
using Student.Service.Services;
using Student.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Student.Test.UnitTest.Validators
{
    public class StudentValidatorTest
    {
        private readonly StudentValidator _validator;
        private readonly AutoMocker _mocker;

        public StudentValidatorTest()
        {
            _mocker = new AutoMocker();
            _validator = _mocker.CreateInstance<StudentValidator>();
        }

        [Fact]
        public void StudentValidator_ShouldValidRequestWithoutErrors()
        {
            var request = CreateStudentRequest();

            var response = _validator.Validate(request);

            Xunit.Assert.True(response.IsValid);
        }

        [Fact]
        public void StudentValidator_ShouldValidRequestWithErrors()
        {
            var request = CreateStudentRequest();
            request.Hash = Guid.Empty;

            var response = _validator.Validate(request);

            Xunit.Assert.False(response.IsValid);
        }

        private StudentRequest CreateStudentRequest()
        {
            return Builder<StudentRequest>
                .CreateNew()
                .Build();
        }
    }
}
