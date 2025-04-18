using AutoMapper;
using AzeWalksAPI.Data;
using AzeWalksAPI.Models.Domain;
using AzeWalksAPI.Models.DTO;
using AzeWalksAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzeWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AzeWalksDbContext azewalksDbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private object dbContext;

        public RegionsController(AzeWalksDbContext azewalksDbContext, IRegionRepository regionRepository,
            IMapper mapper)
        {
            this.azewalksDbContext = azewalksDbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await regionRepository.GetAllAsync();

            //var regionDto = new List<RegionDto>();
            //foreach (var region in regionsDomain)
            //{
            //    regionDto.Add(new RegionDto()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageUrl = region.RegionImageUrl
            //    });
            //}

            var regionDto = mapper.Map<List<RegionDto>>(regionsDomain);

            return Ok(regionDto);
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region = await regionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            //var regiondto = new RegionDto
            //{
            //    Id = region.Id,
            //    Code = region.Code,
            //    Name = region.Name,
            //    RegionImageUrl = region.RegionImageUrl
            //};

            var regionDto = mapper.Map<RegionDto>(region); 

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionDto addregionDto)
        {
            //var regionDomain = new Region
            //{
            //    Code = addregionDto.Code,
            //    Name = addregionDto.Name,
            //    RegionImageUrl = addregionDto.RegionImageUrl
            //};
            var regionDomain = mapper.Map<Region>(addregionDto);

            regionDomain = await regionRepository.CreateAsync(regionDomain);
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return CreatedAtAction(nameof(GetRegionById), new {id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegion(Guid id,[FromBody] UpdateRegionDto updateregionDto)
        {
            //var regionDomain = new Region
            //{
            //    Code = updateregionDto.Code,
            //    Name = updateregionDto.Name,
            //    RegionImageUrl = updateregionDto.RegionImageUrl
            //};
            var regionDomain = mapper.Map<Region>(updateregionDto);

            regionDomain = await regionRepository.UpdateAsync(id, regionDomain);

            if(regionDomain == null)
            {
                return NotFound();
            }

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var regionDomain = await regionRepository.DeleteAsync(id);

            if(regionDomain == null)
            {
                return NotFound();
            }

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }
    }
}
