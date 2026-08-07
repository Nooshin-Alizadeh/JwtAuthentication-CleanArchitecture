using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAuthentication.Infrastructure.Identity
{
    internal class ApplicationUser : IdentityUser<Guid>
    {
    }
}
