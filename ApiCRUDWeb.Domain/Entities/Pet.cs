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
		public PetDetails Details{ get;  set; }
		public User Tutor { get; set; }

		public Pet(string petName, DateOnly dateOfBirh, string breed)
		{
			ValidationDomain( petName, dateOfBirh, breed);
		}
		public void Update(string petName, DateOnly dateOfBirh, string breed)
		{
			ValidationDomain(petName, dateOfBirh, breed);
		}

		public void ValidationDomain( string petName, DateOnly dateOfBirh, string breed )
		{
			PetName = petName;
			DateOfBirh = dateOfBirh;
			Breed = breed;
		}
	}
}