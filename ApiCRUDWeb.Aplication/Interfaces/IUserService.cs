using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Services;
using ApiCRUDWeb.Models;

namespace ApiCRUDWeb.Aplication.Interfaces
{
	public interface IUserService
	{
		Task<UserDTO> AddUser(UserDTO user);

		Task<UserDTO> GetUser(Guid id);

		Task<UserDTO> Login(LoginModel loginModel);

		Task<UserDTO> UpdateUserAsync(UserDTO user, Guid id);
	}
}
