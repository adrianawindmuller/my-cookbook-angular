using Microsoft.AspNetCore.Identity;


namespace MyCookbook.Indentity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
