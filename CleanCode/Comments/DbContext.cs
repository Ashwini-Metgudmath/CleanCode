namespace CleanCode.Comments
{
    public class DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public void SaveChanges()
        {


        }
    }
}