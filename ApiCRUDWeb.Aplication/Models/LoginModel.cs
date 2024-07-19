using System.ComponentModel.DataAnnotations;

namespace ApiCRUDWeb.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "O email é obrigatorio")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Email Inválido")]
		public string Email { get; set; }
		[Required(ErrorMessage = "A senha é obrigatoria")]
		[DataType(DataType.Password, ErrorMessage = "Senha Inválida")]
		public string Password { get; set; }
    }
}
