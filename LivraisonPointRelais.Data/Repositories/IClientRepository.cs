using System;
using System.Threading.Tasks;
using LivraisonPointRelais.Data.QueryParameters;
using LivraisonPointRelais.Data.QueryParameters.ParametersHelper;
using LivraisonPointRelais.Model.Entites;

namespace LivraisonPointRelais.Data.Repositories
{
    public interface IClientRepository
    {
        Task<PagedList<Client>> GetClientsAsync(ClientsParameters parameters);

        Task<Client> GetClientAsync(Guid clientId);

        void CreateClient(Client client);

        void UpdateClient(Client client);
        void DeleteClient(Client client);
    }
}
