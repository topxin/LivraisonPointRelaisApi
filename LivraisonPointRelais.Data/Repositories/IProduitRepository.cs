using System;
using System.Threading.Tasks;
using LivraisonPointRelais.Data.QueryParameters;
using LivraisonPointRelais.Data.QueryParameters.ParametersHelper;
using LivraisonPointRelais.Model.Entites;

namespace LivraisonPointRelais.Data.Repositories
{
    public interface IProduitRepository
    {
        Task<PagedList<Produit>> GetProduitsAsync(ProduitsParameters parameters);
        Task<Produit> GetProduitAsync(Guid produitId);
        void CreateProduit(Produit produit);
        void UpdateProduit(Produit produit);
        void DeleteProduit(Produit produit);
    }
}