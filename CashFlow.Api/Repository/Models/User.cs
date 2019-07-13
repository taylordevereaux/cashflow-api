using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CashFlow.Api.Repository.Models
{
    public class User : IdentityUser<Guid>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}