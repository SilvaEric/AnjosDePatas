using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ApiCRUDWeb.Domain.Validations;

namespace ApiCRUDWeb.Domain.Entities
{
	public class Pet
	{
		public Guid? PetId { get; private set; }
		public Guid UserId { get; private set; }
		public string PetName { get; private set; }
		public DateOnly DateOfBirh { get; private set; }
		public string Breed { get; private set; }
		public PetDetails? Details{ get; set; }
		public User Tutor { get; set; }

		public Pet(Guid userId, string petName, DateOnly dateOfBirh, string breed)
		{
			ValidationDomain(userId, petName, dateOfBirh, breed);
		}
		public void Update(Guid userId, string petName, DateOnly dateOfBirh, string breed)
		{
			ValidationDomain(userId, petName, dateOfBirh, breed);
		}

		public void ValidationDomain(Guid userId, string petName, DateOnly dateOfBirh, string breed)
		{
			UserId = userId;
			DomainExceptionValidation.When(petName.Length > 100, "O nome deve ter no maximo 100 caracteres");
			DomainExceptionValidation.When(breed.Length > 50, "A raça deve ter no maximo 50 caracteres");
			PetName = petName;
			DateOfBirh = dateOfBirh;
			Breed = breed;
		}
	}
}