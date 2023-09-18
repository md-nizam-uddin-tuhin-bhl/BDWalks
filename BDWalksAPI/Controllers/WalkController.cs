using AutoMapper;
using BDWalksAPI.CustomActionFilter;
using BDWalksAPI.DTO;
using BDWalksAPI.Models.Domain;
using BDWalksAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BDWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class WalkController : ControllerBase
    {
        private readonly IWalksReposity _reposity;
        private readonly IMapper _mapper;

        public WalkController(IWalksReposity reposity, IMapper mapper)
        {
            _reposity = reposity;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? SortBy, [FromQuery] bool? isAcending,[FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 1000)
        {
            var walksDomain = await _reposity.GetAllAsync(filterOn,filterQuery,SortBy,isAcending??true,pageNumber,pageSize);
            return Ok(_mapper.Map<List<WalkDto>>(walksDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walksDomain = await _reposity.GetByIdAsync(id);
            if(walksDomain == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDto>(walksDomain));
        }
        [HttpPost]
        [ValidateModelAdttribute]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto requestDto)
        {
             var walk = _mapper.Map<Walk>(requestDto);
             await _reposity.CreateAsync(walk);
             return Ok(_mapper.Map<WalkDto>(walk));
        }
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModelAdttribute]
        public async Task<IActionResult> Update([FromRoute] Guid id ,[FromBody] UpdateWalksRequestDto updateWalks)
        {
            var walk = _mapper.Map<Walk>(updateWalks);
            walk = await _reposity.UpdateAsync(id,walk);
            if (walk == null) return NotFound();
            return Ok(_mapper.Map<WalkDto>(walk));

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var WalksDomoin = await _reposity.DeleteAsync(id);
            if (WalksDomoin == null) return NotFound();
            var WalksDto = _mapper.Map<WalkDto>(WalksDomoin);
            return Ok(WalksDto);
        }
    }
}
