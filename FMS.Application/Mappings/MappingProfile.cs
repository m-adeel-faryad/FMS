using AutoMapper;
using FMS.Application.Dto;
using FMS.Domain.Models;

namespace FMS.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddAccount, Account>().ReverseMap();
        CreateMap<UpdateAccount, Account>().ReverseMap();
        CreateMap<GetById, Account>().ReverseMap();
    }
}
