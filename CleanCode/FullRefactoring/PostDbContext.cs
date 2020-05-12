namespace Project.UserControls
{
    public class PostDbContext
    {
        public DbSet<Post> Posts { get; set; }

        public void SaveChanges()
        {
        }
    }
}