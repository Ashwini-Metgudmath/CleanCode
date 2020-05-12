using System;
using System.Web.UI.WebControls;
using Project.UserControls;

namespace CleanCode.FullRefactoring
{
    public class PostControl : System.Web.UI.UserControl
    {
        private readonly PostRepository _postRepository;
        private readonly PostValidator _validator;
        private Label PostBody { get; set; }
        private Label PostTitle { get; set; }
        private int? PostId { get; set; }

        public PostControl()
        {
            _postRepository = new PostRepository();
            _validator = new PostValidator();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack)
                TrySavePost();
            else
                DisplayPost();
           
        }

        private void TrySavePost()
        {
            var post = GetPost();

            ValidationResult results = _validator.Validate(post);

            if (results.IsValid)
                _postRepository.SavePost(post);
            else
                DisplayErrors(results);
        }

        private void DisplayErrors(ValidationResult results)
        {
            var errorSummary = FindErrorSummaryControl();

            foreach (var error in results.Errors)
            {
                var label = FindErrorLabel(error);

                if (label == null)
                    errorSummary.Items.Add(new ListItem(error.ErrorMessage));
                else
                    label.Text = error.ErrorMessage;
            }
        }
        private Label FindErrorLabel(ValidationError error)
        {
            return FindControl(error.PropertyName + "Error") as Label;
        }

        private BulletedList FindErrorSummaryControl()
        {
            return (BulletedList)FindControl("ErrorSummary");
        }


        private void DisplayPost()
        {
            var postId = Request.QueryString["id"];
            Post post = _postRepository.GetPost(postId);
            PostBody.Text = post.Body;
            PostTitle.Text = post.Title;
        }

        private Post GetPost()
        {
            return new Post()
            {
                Id = Convert.ToInt32(PostId.Value),
                Title = PostTitle.Text.Trim(),
                Body = PostBody.Text.Trim()
            };
        }




        
    }

    #region helpers

    #endregion

}