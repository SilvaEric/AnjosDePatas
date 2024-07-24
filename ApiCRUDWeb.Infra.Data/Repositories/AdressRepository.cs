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
	internal class AdressRepository : IAdressRepository
	{
		private readonly AppDbContext _context;

		public AdressRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Adress> AddAdress(Adress adress, Guid userId)
		{
			var _user = await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();

			_user.Adress = adress;

			await _context.SaveChangesAsync();

			return _user.Adress;
		}

		public async Task<Adress> UpdateAdress(Adress adress, Guid userId)
		{
			var _adress = await _context.Adress.Where(a => a.UserId == userId).FirstOrDefaultAsync();

			_adress.Update(adress.Country, adress.State, adress.City, adress.Neighborhood, adress.PublicPlace, adress.Complement);

			await _context.SaveChangesAsync();

			return _adress;

		}
	}
}
