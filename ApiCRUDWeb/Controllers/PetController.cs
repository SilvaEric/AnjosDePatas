using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Entities;
using ApiCRUDWeb.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCRUDWeb.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize(Roles = "Owner")]
	public class PetController: ControllerBase
	{
		private readonly IPetRepository _petRepository;
		private readonly IPetService _petService;
		private readonly IUserService _userService;

		public PetController(IPetRepository petRepository, IPetService petService, IUserService userService)
		{
			_petRepository = petRepository;
			_petService = petService;
			_userService = userService;
		}

		[HttpGet("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> GetAsync(Guid petId)
		{
			var getPet = await _petService.GetPet(petId);
			if (getPet is null)
			{
				return NoContent();
			}
			return Ok(getPet);
		}

		[HttpGet("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> GetAllAsync()
		{
			var tutorId = Guid.Parse(User.Identity.Name ?? string.Empty);
			var getPet = await _petService.GetAllPets(tutorId);
			if (getPet is null)
			{
				return NoContent();
			}
			return Ok(getPet);
		}


		[HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> RegisterAsync(PetDTO pet)
		{
			var tutorId = Guid.Parse(User.Identity.Name ?? string.Empty);

			var createPet = await _petService.AddPet(pet, tutorId);

			if(createPet is null)
				return BadRequest();
			return Created($"Pet/{createPet.PetName}", createPet);
		}


		[HttpPut("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateAsync( PetDTO input)
		{
			var updatePet = await _petService.UpdatePet(input);
			if (updatePet is null)
			{
				return NotFound();
			}
			return Ok();
		}


		[HttpDelete("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> DeleteAsync(Guid petId)
		{
			if(await _petRepository.DeletePet(petId))
			{
				return Ok();
			}
			return BadRequest();
		}
	}
}
