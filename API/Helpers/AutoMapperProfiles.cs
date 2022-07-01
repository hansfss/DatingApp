using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using AutoMapper;
using System.Linq;
using API.Extensions;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile//helps us map from one object to another
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, options => options.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))//populating photoUrl prop in MemberDto
                .ForMember(dest => dest.Age, opt => opt.MapFrom(SearchOption => SearchOption.DateOfBirth.CalculateAge()));//calculating the age of each MemberDto
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}