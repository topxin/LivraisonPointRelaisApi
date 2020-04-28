using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HistoriqueAffectation.Model.Data;
using HistoriqueAffectation.Model.Entites;
using Microsoft.EntityFrameworkCore;

namespace HistoriqueAffectation.Data.Repositories
{
    public class ClientRepository: IClientRepository
    {
        private readonly LivraisonPointRelaisDbContext _context;

        public ClientRepository(LivraisonPointRelaisDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
           return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientAsync(Guid clientId)
        {
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            return await _context.Clients.FirstOrDefaultAsync(p => p.Id == clientId);
        }

        public void CreateClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            client.Id = new Guid();
            _context.Clients.Add(client);
        }

        public void UpdateClient(Client client)
        {
            //non necessaire car tracked par EfCore
        }

        public void DeleteClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _context.Clients.Remove(client);
        }

        public async Task<bool> ClientExistAsync(Guid clientId)
        {
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            return await _context.Clients.AnyAsync(p => p.Id == clientId);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}