using System.ComponentModel.DataAnnotations;

namespace KubaBlog.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen ad soyad giriniz")]
        public string? NameSurname { get; set; }
        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Lütfen parolanızı giriniz")]
        public string? Password { get; set; }

        [Display(Name = "Parola Tekrar")]
        [Compare("Password",ErrorMessage ="Girdiğiniz parolalar uyuşmuyor!")]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "Email Adresi")]
        [Required(ErrorMessage = "Lütfen email adresinizi giriniz")]
        public string? Email { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string? UserName { get; set; }
        public bool IsAcceptTheContract { get; set; }
    }
}
