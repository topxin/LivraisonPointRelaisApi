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
    public class ClientRepository: IClientRepository
    {
        private readonly LivraisonPointRelaisDbContext _context;

        public ClientRepository(LivraisonPointRelaisDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<PagedList<Client>> GetClientsAsync(ClientsParameters parameters)
        {
            var clients = _context.Clients as IQueryable<Client>;
            if (!string.IsNullOrWhiteSpace(parameters.Nom))
            {
                clients = clients.Where(c => c.Nom == parameters.Nom);
            }

            if (!string.IsNullOrWhiteSpace(parameters.Prenom))
            {
                clients = clients.Where(c => c.Prenom == parameters.Prenom);
            }

            if (!string.IsNullOrWhiteSpace(parameters.Searching))
            {
                var searchingTextFormatted = parameters.Searching.Trim().ToLower();
                clients = clients.Where(c => c.Nom.ToLower().Contains(searchingTextFormatted) 
                                             || c.Prenom.Contains(searchingTextFormatted));
            }

            clients = !string.IsNullOrWhiteSpace(parameters.OrderBy) ? clients.ApplySort(parameters.OrderBy) : clients.OrderBy(c => c.Nom);

            return PagedList<Client>.ToPagedList(await clients.ToListAsync(), parameters.PageNumber, parameters.PageSize);
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