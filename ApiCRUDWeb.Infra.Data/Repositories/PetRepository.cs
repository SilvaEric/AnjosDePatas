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
	public class PetRepository : IPetRepository
	{
		private readonly AppDbContext _context;
		public PetRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<Pet> AddPet(Pet pet, Guid tutorId)
		{
			var _tutor = _context.Users.Where(t => t.UserId == tutorId)
								.FirstOrDefault();

			if (_tutor is null)
			{
				throw new InvalidOperationException("não foi possivel adicionar o pet na base de dados");
			}

			pet.Tutor = _tutor;
			var _pet = await _context.Pets.AddAsync(pet);
			await _context.SaveChangesAsync();

			return pet;
		}

		public async Task<bool> DeletePet(Guid petId)
		{
			var _pet = await _context.Pets.Where(p => p.PetId == petId).FirstOrDefaultAsync();

			if (_pet is not null)
			{
				_context.Pets.Remove(_pet);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<List<Pet>> GetAllPets(Guid tutorId)
		{

			var _pets = await _context.Pets.Include(p => p.Details)
				.Where(p => p.UserId == tutorId).ToListAsync();

			return _pets;

		}

		public async Task<Pet> GetPet(Guid petId)
		{
			var _pet = await _context.Pets.Include(p => p.Details)
				.Where(pet => pet.PetId == petId)
				.FirstOrDefaultAsync();

			if (_pet is null)
				throw new InvalidOperationException("Esse pet não existe em nossa base de dados");

			return _pet;
		}

		public async Task<Pet> UpdatePet(Pet input)
		{
			var petContext = await _context.Pets.Where(p => p.PetId == input.PetId)
				.SingleOrDefaultAsync();

			if (petContext is null)
				throw new InvalidOperationException("Este Pet não exite na base de dados");

			petContext.Update(input.UserId, input.PetName, input.DateOfBirh, input.Breed);

			await _context.SaveChangesAsync();

			return petContext;
		}
	}
}
