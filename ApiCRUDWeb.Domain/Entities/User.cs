using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ApiCRUDWeb.Domain.Validations;

namespace ApiCRUDWeb.Domain.Entities
{
	public class User
	{
		public Guid UserId { get; } 
		public string UserName { get; private set; }
		public string EmailAdress { get; private set; }
		public byte[] PasswordSalt{ get; private set; }
        public byte[] PasswordHash { get; private set; }
        public DateOnly UserDateOfBirth { get; private set; }
		public Adress? Adress { get; private set; }
		public string PhoneNumber { get; private set; }
		public string Role { get; private set; }
		public DateTime? InsertionDate { get; private set; }
		public List<Pet>? Pets { get; private set; }

		public User(string userName, string emailAdress, DateOnly userDateOfBirth, 
			string phoneNumber, string role)
		{
			InsertionDate = DateTime.UtcNow;
			ValidateDomain(userName, emailAdress, userDateOfBirth,
			phoneNumber, role);
		}

		public void Update(string userName, string emailAdress, DateOnly userDateOfBirth,
			 string phoneNumber, string role)
		{
			ValidateDomain(userName,emailAdress, userDateOfBirth, phoneNumber, role);
		}

		public void ValidateDomain(string userName, string emailAdress, DateOnly userDateOfBirth, 
			string phoneNumber, string role)
		{
			

			UserName = userName;
			EmailAdress = emailAdress;
			UserDateOfBirth = userDateOfBirth;
			PhoneNumber = phoneNumber;
			Role = role;
		}

		public void AlteratePassword(byte[] passwordSalt, byte[] passwordHash)
		{
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
        }
	}
}
