using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAuthentication.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }

        public string UserName { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;


        private User()
        {
            //todo :  EF Core needs this constructor
            UserName = string.Empty;
            Email = string.Empty;
        }


        public User(
            string userName,
            string email)
        {
            Id = Guid.NewGuid();

            UserName = userName;

            Email = email;
        }
    }
}
