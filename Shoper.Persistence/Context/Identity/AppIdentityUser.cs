using Microsoft.AspNetCore.Identity;

namespace Shoper.Persistence.Context.Identity;

public class AppIdentityUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
}