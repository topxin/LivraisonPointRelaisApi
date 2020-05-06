using System;
using System.Threading.Tasks;
using LivraisonPointRelais.Data.QueryParameters;
using LivraisonPointRelais.Data.QueryParameters.ParametersHelper;
using LivraisonPointRelais.Model.Entites;

namespace LivraisonPointRelais.Data.Repositories
{
    public interface IPointRelaisRepository
    {
        Task<PagedList<PointRelais>> GetPointsRelaisAsync(PointRelaisParameters parameters);

        Task<PointRelais> GetPointRelaisAsync(Guid pointRelaisId);

        void CreatePointRelais(PointRelais pointRelais);

        void UpdatePointRelais(PointRelais pointRelais);
        void DeletePointRelais(PointRelais pointRelais);
    }
}