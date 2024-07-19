
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Domain.Interfaces
{
	public interface IPetDetailsRepository
	{
		Task<PetDetails> UpdatePetDetails(PetDetails petDetails, Guid petId);

		Task<PetDetails> AddPetDetails(PetDetails petDetails, Guid petId);
	}
}
