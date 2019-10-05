using Microsoft.AspNetCore.Mvc;
using CalculadoraMacros.API.Dto;
using CalculadoraMacros.API.Data;
namespace CalculadoraMacros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunnelController :ControllerBase
    {
        private readonly ICalcRepository _repo;

        public FunnelController(ICalcRepository repo)
        {
            _repo = repo;
        }
    }
}