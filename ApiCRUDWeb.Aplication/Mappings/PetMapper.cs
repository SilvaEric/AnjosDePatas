using ApiCRUDWeb.Aplication.DTOs;
using ApiCRUDWeb.Aplication.Interfaces;
using ApiCRUDWeb.Domain.Entities;

namespace ApiCRUDWeb.Aplication.Mappings
{
	internal class PetMapper : IPetMapper
	{
        private readonly IPetDetailsMapper _petDetailsMapper;

        public PetMapper(IPetDetailsMapper petDetailsMapper)
        {
            _petDetailsMapper = petDetailsMapper;
        }

        public Pet MapToPet(PetDTO petDTO)
		{

			var pet = new Pet
				(
					petDTO.PetName,
					petDTO.DateOfBirh,
					petDTO.Breed
				);

			if (petDTO.Details is not null)
				pet.Details  = _petDetailsMapper.MapToPetDetails(petDTO.Details);

			return pet;
		}

		public PetDTO MapToPetDTO(Pet pet)
		{
			PetDetailsDTO? details = null;

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
