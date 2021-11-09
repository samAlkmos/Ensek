using AutoMapper;
using Ensek.DTO.DTOs;
using Ensek.Entity.Entities;

namespace Ensek.Helper.Helpers
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Account, AccountDTO>().ReverseMap();
                CreateMap<MeterReadingModel, MeterReadingDTO>().ReverseMap();

            }
        }
    }
}
