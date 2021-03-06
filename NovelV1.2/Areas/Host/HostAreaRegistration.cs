using System.Web.Mvc;

namespace NovelV1._2.Areas.Host
{
    public class HostAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Host";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Host_default",
                "Host/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}