using ApiCRUDWeb.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Models;

namespace ApiCRUDWeb.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IUserRepository _userRepository;
		private readonly ITokenService _tokenService;

		public UserController(IUserService userService, IUserRepository userRepository, ITokenService tokenService)
		{
			_userService = userService;
			_userRepository = userRepository;
			_tokenService = tokenService;
		}

		[HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> RegisterAsync( UserDTO User)
		{
			var emailInUse = await _userRepository.EmailExist(User.EmailAdress);

			if (emailInUse)
				return BadRequest("O email fornecido ja está em uso");
			
			var createUser = await _userService.AddUser(User);
			if(createUser is null)
			{
				return BadRequest();
			}
			return Created($"User/Get", createUser);
		}

		[HttpGet("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[Authorize]
		public async Task<IActionResult> GetAsync()
		{
			var userId = Guid.Parse(User.Identity.Name);
			var getUser = await _userService.GetUser(userId);
			if(getUser is null)
			{
				return NoContent();
			}
			return Ok(getUser);
		}

		[HttpPost("[action]")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Login(LoginModel loginModel)
		{
			var userExists = await _userRepository.EmailExist(loginModel.Email);
			if (! userExists)
				return NotFound("O email fornecido não existe na base de dados, faça um registro");

			var user = await _userRepository.Login(loginModel.Email, loginModel.Password);

			var token = _tokenService.GenerateToken(user);

			return Ok(new
			{
				token = token
			});
		}

		[HttpPut("[action]")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[Authorize]
		public async Task<IActionResult> Update(UserDTO user)
		{
			var userId = Guid.Parse(User.Identity.Name);
			var updateUser = await _userService.UpdateUserAsync(user, userId);


			return Created($"User/Get", updateUser);
		}
	}
}
