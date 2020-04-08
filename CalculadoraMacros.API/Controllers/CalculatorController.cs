  
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CalculadoraMacros.API.Data;
using CalculadoraMacros.API.Dtos;
using CalculadoraMacros.API.Helpers;
using CalculadoraMacros.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace CalculadoraMacros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalcRepository _repo;
        private readonly IMapper _mapper;

        public CalculatorController(ICalcRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
          
            var user = await _repo.GetUser(currentUserId);
            var userToReturn = _mapper.Map<UserForDisplayDto>(user);

            return Ok(userToReturn);
        }
        public async Task<ActionResult> GetMacros(M)
    }
}