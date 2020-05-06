using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LivraisonPointRelais.Data.Dto;
using LivraisonPointRelais.Data.QueryParameters;
using LivraisonPointRelais.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LivraisonPointRelais.Api.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController: ControllerBase
    { 
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetClients([FromQuery] ClientsParameters clientsParameters)
        {
            var clients = await _clientRepository.GetClientsAsync(clientsParameters);
            var clientDtos = _mapper.Map<IEnumerable<ClientDto>>(clients);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(clients.GetMetadata()));
            return Ok(clientDtos);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClient([FromRoute]Guid clientId)
        {
            var client = await _clientRepository.GetClientAsync(clientId);

            if (client == null)
            {
                return NotFound();
            }

            var clientDto = _mapper.Map<ClientDto>(client);
            return Ok(clientDto);
        }
    }
}