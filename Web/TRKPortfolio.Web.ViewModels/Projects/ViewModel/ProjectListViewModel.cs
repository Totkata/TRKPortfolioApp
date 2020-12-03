namespace TRKPortfolio.Web.ViewModels.Projects.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Web.ViewModels.Administration.Projects.ViewModel;

    public class ProjectListViewModel
    {
        public IEnumerable<ProjectViewModel> Projects { get; set; }
    }
}
