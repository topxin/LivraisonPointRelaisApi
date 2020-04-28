using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HistoriqueAffectation.Data.Dto;
using HistoriqueAffectation.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HistoriqueAffectation.Api.Controllers
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
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientRepository.GetClientsAsync();
            var clientDtos = _mapper.Map<IEnumerable<ClientDto>>(clients);
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