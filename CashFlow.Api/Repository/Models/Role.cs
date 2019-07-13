using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CashFlow.Api.Repository.Models
{
    public class Role : IdentityRole<Guid>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}