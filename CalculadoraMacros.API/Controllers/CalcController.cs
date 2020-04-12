using Microsoft.AspNetCore.Mvc;
using CalculadoraMacros.API.Dtos;
using CalculadoraMacros.API.Data;
using AutoMapper;
using System.Threading.Tasks;

namespace CalculadoraMacros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly ICalcRepository _repo;
        private readonly IMapper _mapper;

        public CalcController(ICalcRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("GetDiet3")]
        public async Task<IActionResult> GetDiet3(FunnelNormalPlusBodyDto funnel3)
        {
            var funnel = _mapper.Map<FunnelMasterDto>(funnel3);

            funnel.Date = System.DateTime.Now;
            funnel.MeasureDeviceTypeId = CalcRepository.SCALE_NORMALPLUSBODY;
            funnel.CalculatorId = CalcRepository.CALC_FAT;

            var m = await _repo.CalculateMacros(funnel);
            var dietResults = _mapper.Map<MeasurementDto>(m);
            return Ok(dietResults);
        }
    }
}