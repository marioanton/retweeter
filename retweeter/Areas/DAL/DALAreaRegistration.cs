using System.Web.Mvc;

namespace twittora.Areas.DAL
{
    public class DALAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DAL";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DAL_default",
                "DAL/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}