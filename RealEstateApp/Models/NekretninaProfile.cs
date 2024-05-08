using AutoMapper;

namespace RealEstateApp.Models
{
    public class NekretninaProfile : Profile
    {
        public NekretninaProfile()
        {
            CreateMap<Nekretnina, NekretninaDTO>();
        }
    }
}
