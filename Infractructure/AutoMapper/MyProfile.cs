using AutoMapper;
using Domain.DTOs.BranchDTO;
using Domain.DTOs.CarDTO;
using Domain.DTOs.CustomerDTO;
using Domain.DTOs.RentalDTO;
using Domain.Entities;

namespace Infractructure.AutoMapper;

public class MyProfile : Profile
{
    public MyProfile()
    {
        CreateMap<Car, GetCarDTO>();
        CreateMap<CreateCarDTO, Car>();
        CreateMap<UpdateCarDTO, Car>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));


        CreateMap<Branch, GetBranchDTO>();
        CreateMap<CreateBranchDTO, Branch>();
        CreateMap<UpdateBranchDTO, Branch>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));


        CreateMap<RegisterCustomerDTO, Customer>();
        CreateMap<UpdateCustomerDTO, Customer>()
            .ForAllMembers(opt => opt.Condition((src, dest, member) => member != null));


        CreateMap<CreateRentalDTO, Rental>();
        CreateMap<Rental, GetRentalDTO>();
    }
}
