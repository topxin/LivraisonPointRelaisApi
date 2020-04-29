using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivraisonPointRelais.Data.QueryParameters;
using LivraisonPointRelais.Extensions.ExtensionMethodes;
using LivraisonPointRelais.Model.Data;
using LivraisonPointRelais.Model.Entites;
using Microsoft.EntityFrameworkCore;

namespace LivraisonPointRelais.Data.Repositories
{
    public class ProduitRepository:IProduitRepository
    {
        private readonly LivraisonPointRelaisDbContext _context;

        public ProduitRepository(LivraisonPointRelaisDbContext context)
        {
            _context = context??throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Produit>> GetProduitsAsync(ProduitsParameters parameters)
        {
            return await _context.Produits
                .Skip((parameters.PageNumber-1)*parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        public async Task<Produit> GetProduitAsync(Guid produitId)
        {
            produitId.ThrowExceptionIfNull();
            return await _context.Produits.FirstOrDefaultAsync(l => l.Id == produitId);
        }

        public void CreateProduit(Produit produit)
        {
            produit.ThrowExceptionIfNull();
            produit.Id = new Guid();
            _context.Produits.Add(produit);
        }

        public void UpdateProduit(Produit produit)
        {
            //non necessaire car tracked par EfCore
        }

        public void DeleteProduit(Produit produit)
        {
            produit.ThrowExceptionIfNull();
            _context.Produits.Remove(produit);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}