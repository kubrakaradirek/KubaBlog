using System.ComponentModel.DataAnnotations;

namespace KubaBlog.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını girin")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Lütfen parolanızı girin")]
        public string password { get; set; }
    }
}
