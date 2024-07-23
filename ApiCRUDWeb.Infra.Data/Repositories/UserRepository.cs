﻿using System.Security.Cryptography;
using System.Text;
using ApiCRUDWeb.Domain.Entities;
using ApiCRUDWeb.Domain.Interfaces;
using ApiCRUDWeb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUDWeb.Infra.Data.Repositories
{
	internal class UserRepository : IUserRepository
	{
		private readonly AppDbContext _context;
		public UserRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<User> AddUser(User user)
		{
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
			return user;
		}

		public async Task<User> Login(string email, string password)
		{
			var _user = await _context.Users
					.Where(u => u.EmailAdress.ToLower() == email.ToLower())
					.FirstOrDefaultAsync();

			if (_user is null)
				throw new InvalidOperationException("Email não cadastrado");

			using var hmac = new HMACSHA512(_user.PasswordSalt);
			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
			for (int x = 0; x < computedHash.Length; x++)
			{
				if (computedHash[x] != _user.PasswordHash[x])
                    throw new InvalidOperationException("Senha Incorreta");
            }

			return _user;
		
		}

		public async Task<User> GetUser(Guid id)
		{

			var user = await _context.Users.Include(u => u.Adress)
				.FirstOrDefaultAsync(u => u.UserId == id);

			if (user is not null)
			{
				return user;
			}

			throw new InvalidOperationException("Não foi possivel encontrar o usuário");

		}

		public async Task<User> UpdateUserAsync(User user, Guid id)
		{
			var _user = await _context.Users.Where(u => u.UserId == id)
				.FirstOrDefaultAsync();

			_user.Update(user.UserName,
			user.EmailAdress,
			user.UserDateOfBirth,
			user.PhoneNumber,
			user.Role);

			await _context.SaveChangesAsync();

			return _user;
		}

		public async Task<bool> EmailExist(string email)
		{
			return await _context.Users.AnyAsync(x => x.EmailAdress.ToLower() == email.ToLower());
		}
	}
}
