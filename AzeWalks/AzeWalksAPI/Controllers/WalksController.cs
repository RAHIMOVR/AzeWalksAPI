using AutoMapper;
using AzeWalksAPI.Models.Domain;
using AzeWalksAPI.Models.DTO;
using AzeWalksAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzeWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walkDomain = await walkRepository.GetAllAsync();

            //var walkDto = mapper.Map<List<WalkDto>>(walkDomain);

            return Ok(mapper.Map<List<WalkDto>>(walkDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkDto addwalkDto)
        {
            var walkDomain = mapper.Map<Walk>(addwalkDto);

            await walkRepository.CreateAsync(walkDomain);

            //var walkDto = mapper.Map<WalkDto>(walkDomain);

            return Ok(mapper.Map<WalkDto>(walkDomain));
        }
    }
}
