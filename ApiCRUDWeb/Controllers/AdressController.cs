using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCRUDWeb.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class AdressController : ControllerBase
	{
		private readonly IAdressService _adressService;

		public AdressController(IAdressService adressService)
		{
			_adressService = adressService;
		}

		[HttpPost("[action]")]
		
		public async Task<IActionResult> Register(AdressDTO adressDTO)
		{
			var userId = Guid.Parse(User.Identity.Name);

			var adressAdded = await _adressService.AddAdress(adressDTO, userId);

			if (adressAdded is null)
				return BadRequest("não foi possivel adicionar o Endereço");

			return Created($"User/Get", adressAdded);

		}
	}
}
