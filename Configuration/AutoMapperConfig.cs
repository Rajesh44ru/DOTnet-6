using AutoMapper;
using TestWEBAPI.Entities;
using TestWEBAPI.Models;

namespace TestWEBAPI.Configuration
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<StudentDTO,Student>().ReverseMap();
            // for creating different Property
            //CreateMap<Student,StudentDTO>().ForMember(n=>n.StudentName,opt=>opt.MapFrom(x=>x.StudentName)).ReverseMap();
            //CreateMap<Student,StudentDTO>().ReverseMap().ForMember(n=>n.StudentName,opt=>opt.MapFrom(x=>x.StudentName));

            // Ignore
            // CreateMap<StudentDTO,Student>().ReverseMap().ForMember(n=>n.StudentName,opt=>opt.Ignore());
            // tranforming the prorperty
            //CreateMap<StudentDTO, Student>().ReverseMap().AddTransform<string>(n=>string.IsNullOrEmpty(n)?"no Data Found":n);
            //bug Fix
            //CreateMap<StudentDTO, Student>().ReverseMap().ForMember(n => n.Address, opt => opt.MapFrom(x => string.IsNullOrEmpty(x.Address) ? " NO Address Found" : x.Address));
            //CreateMap<Student, StudentDTO>().ReverseMap().ForMember(p => p.StudentName, opt => opt.MapFrom(z => string.IsNullOrEmpty(z.StudentName) ? " NO Student Name Found" : z.StudentName);

        }
    }
}
