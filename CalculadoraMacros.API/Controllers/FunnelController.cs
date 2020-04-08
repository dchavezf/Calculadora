using Microsoft.AspNetCore.Mvc;
using CalculadoraMacros.API.Dtos;
using CalculadoraMacros.API.Data;
using AutoMapper;
using System.Threading.Tasks;

namespace CalculadoraMacros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunnelController :ControllerBase
    {
        private readonly ICalcRepository _repo;
        private readonly IMapper _mapper;

        public FunnelController(ICalcRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

         [HttpPost("GetDiet")]
        public async Task<IActionResult> GetDiet(UserForFunnelDto userForFunnelDto)
        {
            var m = await _repo.CalculateMacros(userForFunnelDto);
            var dietResults=_mapper.Map<MeasurementDto>(m);
            return Ok(dietResults);
        }
    }
}