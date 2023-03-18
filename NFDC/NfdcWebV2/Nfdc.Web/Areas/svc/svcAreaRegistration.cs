using System.Web.Mvc;

namespace Nfdc.Web.Areas.svc
{
    public class svcAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "svc";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "svc_default",
                "svc/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}