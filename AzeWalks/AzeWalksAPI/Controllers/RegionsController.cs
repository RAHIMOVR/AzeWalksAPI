using AzeWalksAPI.Data;
using AzeWalksAPI.Models.Domain;
using AzeWalksAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzeWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AzeWalksDbContext azewalksDbContext;
        private object dbContext;

        public RegionsController(AzeWalksDbContext azewalksDbContext)
        {
            this.azewalksDbContext = azewalksDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regionsDomain = azewalksDbContext.Regions.ToList();

            var regionDto = new List<RegionDto>();
            foreach (var region in regionsDomain)
            {
                regionDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            return Ok(regionDto);
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRegionById(Guid id)
        {
            var region = azewalksDbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);
        }

        [HttpPost]
        public IActionResult AddRegion([FromBody] AddRegionDto addregionDto)
        {
            var regionDomain = new Region
            {
                Code = addregionDto.Code,
                Name = addregionDto.Name,
                RegionImageUrl = addregionDto.RegionImageUrl
            };

            azewalksDbContext.Regions.Add(regionDomain);
            azewalksDbContext.SaveChanges();

            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetRegionById), new {id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateRegion(Guid id,[FromBody] UpdateRegionDto updateregionDto ) 
        {
            var regionDomain = azewalksDbContext.Regions.FirstOrDefault(x => x.Id == id);

            if(regionDomain == null)
            {
                return NotFound();
            }

            regionDomain.Code = updateregionDto.Code;
            regionDomain.Name = updateregionDto.Name;
            regionDomain.RegionImageUrl = updateregionDto.RegionImageUrl;

            azewalksDbContext.SaveChanges();

            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRegion(Guid id)
        {
            var regionDomain = azewalksDbContext.Regions.FirstOrDefault(x => x.Id == id);

            if(regionDomain == null)
            {
                return NotFound();
            }

            azewalksDbContext.Regions.Remove(regionDomain);
            azewalksDbContext.SaveChanges();

            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(regionDto);
        }
    }
}
