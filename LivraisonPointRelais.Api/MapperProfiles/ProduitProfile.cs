using AutoMapper;
using HistoriqueAffectation.Data.Dto;
using HistoriqueAffectation.Model.Entites;

namespace HistoriqueAffectation.Api.MapperProfiles
{
    public class ProduitProfile: Profile
    {
        public ProduitProfile()
        {
            CreateMap<Produit, ProduitDto>()
                .ForMember(
                    dest => dest.InfomationProduit,
                    opt => opt.MapFrom(src => $"{src.SiteMarchandise}-{src.Nom}"));
        }
    }
}