using ApiCRUDWeb.Aplication.DTOs;

namespace ApiCRUDWeb.Aplication.Interfaces
{
	public interface IPetDetailsService
	{
		Task<PetDetailsDTO> UpdatePetDetails(PetDetailsDTO petDetailsDTO, Guid petId);

		Task<PetDetailsDTO> AddPetDetails(PetDetailsDTO petDetailsDTO, Guid petId);
	}
}
