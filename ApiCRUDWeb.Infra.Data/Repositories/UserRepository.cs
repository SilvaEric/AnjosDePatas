using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDWeb.Domain.Entities;
using ApiCRUDWeb.Domain.Interfaces;
using ApiCRUDWeb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUDWeb.Infra.Data.Repositories
{
	public class UserRepository : IUserRepository
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
			try
			{
				var _user = await _context.Users
					.Where(u => u.EmailAdress.ToLower() == email.ToLower() && u.Password.ToLower() == password.ToLower())
					.FirstOrDefaultAsync();
				return _user;
			}

			catch
			{
				throw new InvalidOperationException("Erro ao obter usuarios");
			}
		}

		public async Task<User> GetUser(Guid id)
		{

			var user = await _context.Users.Include(u => u.Pets)
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
			user.Password,
			user.UserDateOfBirth,
			user.PhoneNumber,
			user.Role);

			await _context.SaveChangesAsync();

			return user;
		}

		public async Task<bool> EmailExist(string email)
		{
			return await _context.Users.AnyAsync(x => x.EmailAdress.ToLower() == email.ToLower());
		}
	}
}
