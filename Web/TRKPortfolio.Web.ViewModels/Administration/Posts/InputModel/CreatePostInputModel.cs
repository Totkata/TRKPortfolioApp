namespace TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Web.ViewModels.Administration.Categories.InputModel;

    public class CreatePostInputModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Text { get; set; }

        public virtual ICollection<CreateCategoryInputModel> Categories { get; set; }

        // public int CategoryId { get; set; }   //ToDo: Make to select many from dropDown menu!!!
    }
}
