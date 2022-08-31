using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Act21.API.Models
{
    public class LoginModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /*public long Id { get; set; }*/
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        /*public string Role { get; set; }*/

        /*public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }*/
    }

    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
        /*public string? RefreshToken { get; set; }*/
    }
}
