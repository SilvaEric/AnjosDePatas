using System.ComponentModel.DataAnnotations;

namespace ApiCRUDWeb.Aplication.DTOs
{
	public class UserDTO
	{
		
		[Required(ErrorMessage = "O Nome é obrigatorio")]
		[StringLength(200,MinimumLength = 3, ErrorMessage ="O nome dever conter entre 3 a 200 caracteres")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "O Email é obrigatorio")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
		public string EmailAdress { get; set; }
		[Required(ErrorMessage = "A Senha é obrigatoria")]
		[StringLength(50, MinimumLength = 10, ErrorMessage = "O senha dever conter no máximo 50 caracteres")]
		[DataType(DataType.Password, ErrorMessage = "Senha Invalida")]
		public string Password { get; set; }
		[Required(ErrorMessage = "a Data de Nascimento é obrigatoria")]
		public DateOnly UserDateOfBirth { get; set; }
		[Required(ErrorMessage = "O Telefone é obrigatorio")]
		[StringLength(13, MinimumLength = 11, ErrorMessage = "O Telefone dever conter entre 11 a 13 caracteres")]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "A Função é obrigatoria")]
		public string Role { get; set; }
		public AdressDTO? Adress { get; set; }
	}
}
