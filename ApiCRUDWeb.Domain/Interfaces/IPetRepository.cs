using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Domain.Interfaces
{
	public interface IPetRepository
	{
		Task<List<Pet>> GetAllPets(Guid tutorId);

		Task<Pet> GetPet(Guid petId);

		Task<Pet> UpdatePet(Pet input);

		Task<Pet> AddPet(Pet pet, Guid tutorId);

		Task<bool> DeletePet(Guid petId);
	}
}
