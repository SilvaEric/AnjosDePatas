using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Domain.Interfaces
{
	public interface IUserRepository
	{
		Task<User> AddUser(User user);

		Task<User> GetUser(Guid id);

		Task<bool> EmailExist(string email);

		Task<User> Login(string email, string password);

		Task<User> UpdateUserAsync(User user, Guid id);
	}
}
