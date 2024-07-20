using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Interfaces
{
	public interface IPetService
	{
		Task<List<PetDTO>> GetAllPets(Guid tutorId);

		Task<PetDTO> GetPet(Guid petId);

		Task<PetDTO> UpdatePet(PetDTO input, Guid petId);

		Task<PetDTO> AddPet(PetDTO petDTO, Guid tutorId);

	}
}
