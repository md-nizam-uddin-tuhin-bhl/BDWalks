using AutoMapper;
using BDWalksAPI.CustomActionFilter;
using BDWalksAPI.Data;
using BDWalksAPI.DTO;
using BDWalksAPI.Models.Domain;
using BDWalksAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BDWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        private readonly IRegionReposity _region;
        private readonly IMapper _mapper;
        public RegionsController(IRegionReposity region, IMapper mapper)
        {
            _region = region;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var RegionDomain = await _region.GetAllAsync();
            return Ok(_mapper.Map<List<RegionDto>>(RegionDomain));
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var RegionDomoin = await _region.GetByIdAsync(id);
            if (RegionDomoin == null) return NotFound();
            return Ok(_mapper.Map<RegionDto>(RegionDomoin));
        }

        [HttpPost]
        [ValidateModelAdttribute]
        public async Task<IActionResult> Create(AddRegionRequestDto requestDto)
        {
           
            var RegionDomoin = _mapper.Map<Region>(requestDto);
            await _region.CreatAsync(RegionDomoin);
            var RegionDto = _mapper.Map<RegionDto>(RegionDomoin);
            return CreatedAtAction(nameof(GetById), new { id = RegionDto.Id }, RegionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModelAdttribute]
        public async Task<IActionResult> update(Guid id, UpdateRegionRequestDto requestDto)
        {
            var RegionDomoin = _mapper.Map<Region>(requestDto);
            if (RegionDomoin == null) return NotFound();
            await _region.UpdateAsync(id, RegionDomoin);
            var RegionDto = _mapper.Map<RegionDto>(RegionDomoin);
            return Ok(RegionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var RegionDomoin = await _region.DeleteAsync(id);
            if (RegionDomoin == null) return NotFound();
            var RegionDto = _mapper.Map<RegionDto>(RegionDomoin);
            return Ok(RegionDto);
        }

    }
}