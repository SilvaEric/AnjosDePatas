using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Interfaces
{
	public interface IPetDetailsMapper
	{
		PetDetails MapToPetDetails(PetDetailsDTO PetDTO);
		PetDetailsDTO MapToPetDetailsDTO(PetDetails Pet);
	}
}
