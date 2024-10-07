using Domain.Entities.Base;
using Domain.Entities.User.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{

    [Table("User", Schema = "User")]
    public class User : BaseEntity<long>
    {
        public User()
        {
            UserType = UserType.System;
            UserStatus = UserStatus.Active;
            Gender = Enum.Gender.Male;
            NationalCode = null;
            FirstName = null;
            LastName = null;
            Username = string.Empty;
            Password = null;
            UserDetail = null;
        }

        public UserType UserType { get; set; }
        public UserStatus UserStatus { get; set; }
        public Gender Gender { get; set; }
        public string? NationalCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }


        public DateTime? DateChangePassword { get; set; }
        public DateTime? DateForgotPassword { get; set; }


        public virtual UserDetail? UserDetail { get; set; }
        public virtual ICollection<UserUnitRole>? UserUnitRoles { get; set; }

    }
}
