using System;
using Microsoft.AspNetCore.Identity;

namespace CashFlow.Api.Repository.Models
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}