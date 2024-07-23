using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Mappings
{
	internal class UserMapper : IUserMapper
	{
		private readonly IAdressMapper _mapper;

		public UserMapper(IAdressMapper mapper)
		{
			_mapper = mapper;
		}

		public User MapToUser(UserDTO userDTO)
		{
			return new User
			(
				userDTO.UserName,
				userDTO.EmailAdress,
				userDTO.UserDateOfBirth,
				userDTO.PhoneNumber,
				userDTO.Role
			);
		}

		public UserDTO MapToUserDTO(User user)
		{
			AdressDTO? adress = null;

			if (user.Adress is not null)
				adress = _mapper.MapToAdressDTO(user.Adress);


			return new UserDTO
			{
				UserName = user.UserName,
				EmailAdress = user.EmailAdress,
				Password = "Oculted",
				UserDateOfBirth = user.UserDateOfBirth,
				PhoneNumber = user.PhoneNumber,
				Role = user.Role,
				Adress = adress
			};
		}
	}
}
