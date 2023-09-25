using System.ComponentModel.DataAnnotations;

namespace webapi._4eventplus.manha.ViewModels
{
    public class LoginViewModel
    {   
            [Required(ErrorMessage = "Email obrigatório!")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Senha obrigatório!")]
            public string Senha { get; set; }   
    }
}
