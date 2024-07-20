
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Interfaces;
using ApiCRUDWeb.Models;

namespace ApiCRUDWeb.Aplication.Services
{
	public class UserService : IUserService
	{
		private readonly IUserMapper _mapper;
		private readonly IUserRepository _repository;

		public UserService(IUserMapper mapper, IUserRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<UserDTO> AddUser(UserDTO userDTO)
		{
			var user = _mapper.MapToUser(userDTO);

			using var hmac = new HMACSHA512();
			byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
			byte[] passwordSalt = hmac.Key;
			user.AlteratePassword(passwordSalt, passwordHash);

			var userAdded = await _repository.AddUser(user);
			return _mapper.MapToUserDTO(userAdded);
		}

		public async Task<UserDTO> GetUser(Guid id)
		{
			var user = await _repository.GetUser(id);
			return _mapper.MapToUserDTO(user);
		}

		public async Task<UserDTO> Login(LoginModel loginModel)
		{
			var user = await _repository.Login(loginModel.Email, loginModel.Password);
			return _mapper.MapToUserDTO(user);
		}

		public async Task<UserDTO> UpdateUserAsync(UserDTO userDTO, Guid id)
		{
			var user = _mapper.MapToUser(userDTO);
			var userUpdated = await _repository.UpdateUserAsync(user, id);
			return _mapper.MapToUserDTO(userUpdated);
		}
	}
}
