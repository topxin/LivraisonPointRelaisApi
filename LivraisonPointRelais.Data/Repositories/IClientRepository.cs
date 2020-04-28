using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HistoriqueAffectation.Model.Entites;

namespace HistoriqueAffectation.Data.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();

        Task<Client> GetClientAsync(Guid clientId);

        void CreateClient(Client client);

        void UpdateClient(Client client);
        void DeleteClient(Client client);
    }
}
