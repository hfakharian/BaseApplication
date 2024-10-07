

namespace Domain.DataTransferObjects.User.SignIn
{
    public class SignInResponseDTO
    {
        public string? Token { get; set; }
        public DateTime TokenCreate { get; set; }
        public long TokenCreateUnix { get; set; }
        public DateTime TokenExpire { get; set; }
        public long TokenExpireUnix { get; set; }
        public UserDTO? User { get; set; }
    }
}
