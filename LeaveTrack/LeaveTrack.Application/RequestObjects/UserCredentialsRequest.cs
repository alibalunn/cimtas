using System.ComponentModel.DataAnnotations;

namespace LeaveTrack.Application.RequestObjects
{
    public class UserCredentialsRequest
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [MinLength(3, ErrorMessage = "Kullanıcı adı en az 3 karakter olmalıdır.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }
    }
}
