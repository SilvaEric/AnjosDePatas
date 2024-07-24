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
	internal class PetDetailsRepository : IPetDetailsRepository
	{
		private readonly AppDbContext _context;
		public PetDetailsRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<PetDetails> AddPetDetails(PetDetails petDetails, Guid petId)
		{
			var _pet = await _context.Pets.Where(p => p.PetId == petId).FirstOrDefaultAsync();
			
			_pet.Details = petDetails;

			await _context.SaveChangesAsync();

			return _pet.Details;
		}

		public async Task<PetDetails> UpdatePetDetails(PetDetails input, Guid petId)
		{
			var petDetailsContext = await _context.PetsDetails.SingleOrDefaultAsync(p => p.PetId == petId);
			
			if (petDetailsContext == null)
				throw new InvalidOperationException("Detalhes do pet não exitem na base de dados");


			petDetailsContext.Update(input.PredominantColor, input.NonPredominantColor, input.Heigth, input.Fur, input.EyesColor, input.TongueColor);

			await _context.SaveChangesAsync();

			return petDetailsContext;
		}
	}
}
