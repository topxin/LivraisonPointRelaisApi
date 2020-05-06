using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LivraisonPointRelais.Data.Dto;
using LivraisonPointRelais.Data.QueryParameters;
using LivraisonPointRelais.Data.Repositories;
using LivraisonPointRelais.Model.Entites;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LivraisonPointRelais.Api.Controllers
{
    [ApiController]
    [Route("api/pointsRelais")]
    public class PointRelaisController: ControllerBase
    {
        private readonly IPointRelaisRepository _ponitRelaisRepository;
        private readonly IMapper _mapper;

        public PointRelaisController(IPointRelaisRepository ponitRelaisRepository, IMapper mapper)
        {
            _ponitRelaisRepository =
                ponitRelaisRepository ?? throw new ArgumentException(nameof(ponitRelaisRepository));
            _mapper = mapper?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetPointsRelais([FromQuery] PointRelaisParameters parameters)
        {
            var pointsRelais = await _ponitRelaisRepository.GetPointsRelaisAsync(parameters);
            var pointsRelaisDto = _mapper.Map<IEnumerable<PointRelaisDto>>(pointsRelais);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pointsRelais.GetMetadata()));
            return Ok(pointsRelaisDto);
        }

        [HttpGet("{pointRelaisId}")]
        public async Task<IActionResult> GetPointRelais([FromRoute] Guid pointRelaisId)
        {
            var pointRelais = await _ponitRelaisRepository.GetPointRelaisAsync(pointRelaisId);
            if (pointRelais == null)
            {
                return NotFound();
            }

            var pointRelaisDto = _mapper.Map<PointRelais>(pointRelais);
            return Ok(pointRelaisDto);
        }
    }
}