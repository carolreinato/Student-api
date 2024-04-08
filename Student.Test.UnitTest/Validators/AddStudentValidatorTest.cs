using FizzWare.NBuilder;
using Moq.AutoMock;
using Student.Domain.DTOs;
using Student.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Student.Test.UnitTest.Validators
{
    public class AddStudentValidatorTest
    {
        private readonly AddStudentValidator _validator;
        private readonly AutoMocker _mocker;

        public AddStudentValidatorTest()
        {
            _mocker = new AutoMocker();
            _validator = _mocker.CreateInstance<AddStudentValidator>();
        }

        [Fact]
        public void StudentValidator_ShouldValidRequestWithoutErrors()
        {
            var request = CreateAddStudentRequest("somedumbname", "somedumbemail@dumbemail.com");

            var response = _validator.Validate(request);

            Xunit.Assert.True(response.IsValid);
            Xunit.Assert.Empty(response.Errors);
        }

        [Fact]
        public void StudentValidator_ShouldValidRequestWithErrors()
        {
            var request = CreateAddStudentRequest(string.Empty, "somedumbemail");

            var response = _validator.Validate(request);

            Xunit.Assert.False(response.IsValid);
            Xunit.Assert.Equal(2, response.Errors.Count);
            Xunit.Assert.Equal("Name", response.Errors[0].PropertyName);
            Xunit.Assert.Equal("Email", response.Errors[1].PropertyName);
        }

        private AddStudentRequest CreateAddStudentRequest(string name, string email)
        {
            return Builder<AddStudentRequest>
                .CreateNew()
                    .With(x => x.Name = name)
                    .With(x => x.Email = email)
                .Build();
        }
    }
}
