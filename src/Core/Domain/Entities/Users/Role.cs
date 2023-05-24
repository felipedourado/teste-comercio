using Microsoft.AspNetCore.Identity;

namespace TesteComercio.Domain.Entities.Users
{
    public class Role : IdentityRole<int>, IEntity
    {
        public string Description { get; set; }
    }
}
