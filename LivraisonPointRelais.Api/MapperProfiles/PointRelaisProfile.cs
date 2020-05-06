using AutoMapper;
using LivraisonPointRelais.Data.Dto;
using LivraisonPointRelais.Model.Entites;

namespace LivraisonPointRelais.Api.MapperProfiles
{
    public class PointRelaisProfile: Profile
    {
        public PointRelaisProfile()
        {
            CreateMap<PointRelais, PointRelaisDto>();
        }
    }
}