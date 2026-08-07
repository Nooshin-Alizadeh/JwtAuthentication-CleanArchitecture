using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAuthentication.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}
