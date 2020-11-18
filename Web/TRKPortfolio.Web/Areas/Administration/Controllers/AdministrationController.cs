namespace TRKPortfolio.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TRKPortfolio.Common;
    using TRKPortfolio.Web.Controllers;

    [Authorize(Roles = "Admin")]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
