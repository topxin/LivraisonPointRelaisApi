using System;
using System.Linq;
using System.Threading.Tasks;
using LivraisonPointRelais.Data.QueryParameters;
using LivraisonPointRelais.Data.QueryParameters.ParametersHelper;
using LivraisonPointRelais.Extensions.ExtensionMethodes;
using LivraisonPointRelais.Model.Data;
using LivraisonPointRelais.Model.Entites;
using Microsoft.EntityFrameworkCore;

namespace LivraisonPointRelais.Data.Repositories
{
    public class PointRelaisRepository: IPointRelaisRepository
    {
        private readonly LivraisonPointRelaisDbContext _context;

        public PointRelaisRepository(LivraisonPointRelaisDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<PagedList<PointRelais>> GetPointsRelaisAsync(PointRelaisParameters parameters)
        {
            var pointsRelais = _context.PointsRelais as IQueryable<PointRelais>;
            if (!string.IsNullOrWhiteSpace(parameters.IdPointRelais))
            {
                pointsRelais = pointsRelais.Where(p => p.IdPointRelais== parameters.IdPointRelais);
            }

            pointsRelais = !string.IsNullOrWhiteSpace(parameters.OrderBy) ? pointsRelais.ApplySort(parameters.OrderBy) : pointsRelais.OrderBy(p => p.LibelleCommercial);

            return PagedList<PointRelais>.ToPagedList(await pointsRelais.ToListAsync(), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PointRelais> GetPointRelaisAsync(Guid pointRelaisId)
        {
            pointRelaisId.ThrowExceptionIfNull();
            return await _context.PointsRelais.FirstOrDefaultAsync(p => p.Id == pointRelaisId);
        }

        public void CreatePointRelais(PointRelais pointRelais)
        {
            pointRelais.ThrowExceptionIfNull();
            pointRelais.Id = new Guid();
            _context.PointsRelais.Add(pointRelais);
        }

        public void UpdatePointRelais(PointRelais pointRelais)
        {
            //non necessaire car tracked par EfCore
        }

        public void DeletePointRelais(PointRelais pointRelais)
        {
            pointRelais.ThrowExceptionIfNull();
            _context.PointsRelais.Remove(pointRelais);
        }

        public async Task<bool> PointRelaisExistAsync(Guid pointRelaisId)
        {
            pointRelaisId.ThrowExceptionIfNull();
            return await _context.PointsRelais.AnyAsync(p => p.Id == pointRelaisId);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
