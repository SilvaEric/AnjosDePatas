using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Mappings
{
	public class PetMapper : IPetMapper
	{
        private readonly IPetDetailsMapper _petDetailsMapper;

        public PetMapper(IPetDetailsMapper petDetailsMapper)
        {
            _petDetailsMapper = petDetailsMapper;
        }

        public Pet MapToPet(PetDTO petDTO)
		{
			
			return new Pet
				(
					petDTO.PetName,
					petDTO.DateOfBirh,
					petDTO.Breed
				);
		}

		public PetDTO MapToPetDTO(Pet pet)
		{
			PetDetailsDTO details = null;
			if (pet.Details is not null)
				details = _petDetailsMapper.MapToPetDetailsDTO(pet.Details);

            return new PetDTO 
			{
				PetId = pet.PetId,
				PetName = pet.PetName,
				DateOfBirh = pet.DateOfBirh,
				Breed = pet.Breed,
				Details = details
			};
		}
	}
}
