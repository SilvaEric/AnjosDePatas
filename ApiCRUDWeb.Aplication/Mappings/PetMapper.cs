using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Interfaces
{
	public class PetMapper : IPetMapper
	{
		public Pet MapToPet(PetDTO petDTO)
		{
			
			return new Pet
				(
					petDTO.UserId,
					petDTO.PetName,
					petDTO.DateOfBirh,
					petDTO.Breed
				);
		}

		public PetDTO MapToPetDTO(Pet pet)
		{

			return new PetDTO 
			{
				UserId = pet.UserId,
				PetName = pet.PetName,
				DateOfBirh = pet.DateOfBirh,
				Breed = pet.Breed
			};
		}
	}
}
