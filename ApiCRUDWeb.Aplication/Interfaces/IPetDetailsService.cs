using ApiCRUDWeb.Aplication.DTOs;

namespace ApiCRUDWeb.Aplication.Interfaces
{
	public interface IPetDetailsService
	{
		Task<PetDetailsDTO> UpdatePetDetails(PetDetailsDTO petDetailsDTO);

		Task<PetDetailsDTO> AddPetDetails(PetDetailsDTO petDetailsDTO, Guid petId);
	}
}
