using AutoMapper;
using LivraisonPointRelais.Data.Dto;
using LivraisonPointRelais.Model.Entites;

namespace LivraisonPointRelais.Api.MapperProfiles
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