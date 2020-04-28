using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HistoriqueAffectation.Model.Entites;

namespace HistoriqueAffectation.Data.Repositories
{
    public interface IProduitRepository
    {
        Task<IEnumerable<Produit>> GetProduitsAsync();
        Task<Produit> GetProduitAsync(Guid produitId);
        void CreateProduit(Produit produit);
        void UpdateProduit(Produit produit);
        void DeleteProduit(Produit produit);
    }
}