using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Mappings
{
	public class UserMapper : IUserMapper
	{
		public User MapToUser(UserDTO userDTO)
		{
			return new User
			(
				userDTO.UserName,
				userDTO.EmailAdress,
				userDTO.Password,
				userDTO.UserDateOfBirth,
				userDTO.PhoneNumber,
				userDTO.Role
			);
		}

		public UserDTO MapToUserDTO(User user)
		{
			return new UserDTO
			{
				UserName = user.UserName,
				EmailAdress = user.EmailAdress,
				Password = user.Password,
				UserDateOfBirth = user.UserDateOfBirth,
				PhoneNumber = user.PhoneNumber,
				Role = user.Role
			};
		}
	}
}
