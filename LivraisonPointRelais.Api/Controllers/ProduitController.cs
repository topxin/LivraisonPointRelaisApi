using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LivraisonPointRelais.Data.Dto;
using LivraisonPointRelais.Data.QueryParameters;
using LivraisonPointRelais.Data.Repositories;
using LivraisonPointRelais.Extensions.ExtensionMethodes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LivraisonPointRelais.Api.Controllers
{
    [ApiController]
    [Route("api/produits")]
    public class ProduitController: ControllerBase
    {
        private readonly IProduitRepository _produitRepository;
        private readonly IMapper _mapper;

        public ProduitController(IProduitRepository produitRepository, IMapper mapper)
        {
            _produitRepository = (IProduitRepository) produitRepository.ThrowExceptionIfNull();
            _mapper = (IMapper) mapper.ThrowExceptionIfNull();
        }

        [HttpGet]
        public async Task<IActionResult> GetProduits([FromQuery] ProduitsParameters produitsParameters)
        {
            var produits = await _produitRepository.GetProduitsAsync(produitsParameters);
            var produitsDto = _mapper.Map<IEnumerable<ProduitDto>>(produits);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(produits.GetMetadata()));
            return Ok(produitsDto);
        }

        [HttpGet("{produitId}")]
        public async Task<IActionResult> GetProduit([FromRoute] Guid produitId)
        {
            var produit = await _produitRepository.GetProduitAsync(produitId);

            if (produit == null)
            {
                return NotFound();
            }

            var produitDto = _mapper.Map<ProduitDto>(produit);
            return Ok(produitDto);
        }
    }
}
