using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.UI.Site.Models
{
    public class MVLogin
    {
        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }
    }
}
