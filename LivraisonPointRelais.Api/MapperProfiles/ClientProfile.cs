using AutoMapper;
using HistoriqueAffectation.Data.Dto;
using HistoriqueAffectation.Model.Entites;

namespace HistoriqueAffectation.Api.MapperProfiles
{
    public class ClientProfile: Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Nom} {src.Prenom}"))
                .ForMember(
                    dest => dest.Sexe,
                    opt => opt.MapFrom(src => src.Sexe));
        }
    }
}