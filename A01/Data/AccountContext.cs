using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AccountContext(DbContextOptions<AccountContext> options) : IdentityDbContext<A01.Data.ApplicationUser>(options)
{
    
}
