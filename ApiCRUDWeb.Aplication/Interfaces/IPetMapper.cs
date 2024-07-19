using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Interfaces
{
	public interface IPetMapper
	{
		Pet MapToPet(PetDTO PetDTO);
		PetDTO MapToPetDTO(Pet Pet);
	}
}
