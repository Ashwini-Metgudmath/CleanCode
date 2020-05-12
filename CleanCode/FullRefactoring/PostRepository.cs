using System;
using System.Linq;
using Project.UserControls;

namespace CleanCode.FullRefactoring
{
    public class PostRepository
    {
        private readonly PostDbContext _dbContext;

        public PostRepository()
        {
            _dbContext = new PostDbContext();
        }

        public Post GetPost(string postId)
        {
            return _dbContext.Posts.SingleOrDefault(p => p.Id == Convert.ToInt32(postId));
        }

        public void SavePost(Post post)
        {
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }
    }
}