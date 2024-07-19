using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Interfaces
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
