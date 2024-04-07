using AutoMapper;
using Student.Domain.DTOs;

namespace Student.Service.AutoMapper
{
    public class StudentAutoMapper : Profile
    {
        public StudentAutoMapper()
        {
            CreateMap<StudentResponse, Domain.Entities.Student>()
                .ReverseMap();

            CreateMap<AddStudentRequest, Domain.Entities.Student>()
                .ReverseMap();
        }
    }
}
