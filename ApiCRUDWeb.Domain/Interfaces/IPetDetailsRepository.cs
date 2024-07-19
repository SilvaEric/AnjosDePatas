
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Domain.Interfaces
{
	public interface IPetDetailsRepository
	{
		Task<PetDetails> UpdatePetDetails(PetDetails petDetails);

		Task<PetDetails> AddPetDetails(PetDetails petDetails, Guid petId);
	}
}
