using ApiCRUDWeb.Domain.Validations;

namespace ApiCRUDWeb.Domain.Entities
{
	public class Adress
	{
        public Guid AdressId { get; private set; }
		public Guid UserId { get; private set; }
		public string Country { get; private set; }
		public string State { get; private set; }
		public string City { get; private set; }
		public string Neighborhood { get; private set; }
		public string PublicPlace { get; private set; }
		public string Complement { get; private set; }
		public User User { get; set; }

		public Adress(Guid userId, string country, string state, string city, string neighborhood, string publicPlace, string complement)
		{
			ValidateDomain(userId, country, state, city, neighborhood, publicPlace, complement);
		}
		public void Update(Guid userId, string country, string state, string city, string neighborhood, string publicPlace, string complement)
		{
			ValidateDomain(userId, country, state, city, neighborhood, publicPlace, complement);
		}

		public void ValidateDomain(Guid userId, string country, string state, string city, string neighborhood, string publicPlace, string complement)
		{
			DomainExceptionValidation.When(country.Length > 80, "O nome do pais deve ter no maximo 80 caracteres");
			DomainExceptionValidation.When(state.Length > 80, "O nome deve ter no maximo 80 caracteres");
			DomainExceptionValidation.When(city.Length > 80, "O nome deve ter no maximo 80 caracteres");
			DomainExceptionValidation.When(neighborhood.Length > 80, "O nome deve ter no maximo 80 caracteres");
			DomainExceptionValidation.When(publicPlace.Length > 100, "O nome deve ter no maximo 100 caracteres");
			DomainExceptionValidation.When(complement.Length > 50, "O nome deve ter no maximo 50 caracteres");

			UserId = userId;
			Country = country;
			State = state;
			City = city;
			Neighborhood = neighborhood;
			PublicPlace = publicPlace;
			Complement = complement;
		}
	}
}
