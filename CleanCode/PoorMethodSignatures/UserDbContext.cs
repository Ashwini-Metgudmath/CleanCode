using System.Linq;

namespace CleanCode.PoorMethodSignatures
{
    public class UserDbContext : DbContext
    {
        public IQueryable<User> Users { get; set; }
    }
}