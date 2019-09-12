using System.Web.Mvc;

namespace MyPortfolio.Areas.Portfoliom
{
    public class PortfoliomAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Portfoliom";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Portfoliom_default",
                "Portfoliom/{controller}/{action}/{id}",
                new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] {"MyPortfolio.Areas.Portfoliom.Controllers"}

            );
        } 
    }
}