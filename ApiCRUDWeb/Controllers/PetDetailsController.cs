
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiCRUDWeb.Domain.Entities;
using ApiCRUDWeb.Domain.Interfaces;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Aplication.DTOs;

namespace ApiCRUDWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class PetDetailsController : ControllerBase
	{
		private readonly IPetDetailsService _petDetailsService;

		public PetDetailsController(IPetDetailsService petDetailsService)
		{
			_petDetailsService = petDetailsService;
		}

		[HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[Authorize]
		public async Task<IActionResult> RegisterAsync(PetDetailsDTO petDetails, Guid petId)
		{
			var register = await _petDetailsService.AddPetDetails(petDetails, petId);
			if(register is null)
			{
				return BadRequest() ;
			}
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpPut("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[Authorize]
		public async Task<IActionResult> UpdateAsync(PetDetailsDTO petDetails, Guid petId)
		{
			
			var query = await _petDetailsService.UpdatePetDetails(petDetails, petId);
			if(query == null)
			{
				return NoContent();
			}
			return Ok(query);
		}
	}
}
