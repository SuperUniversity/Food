using System.Web.Mvc;

namespace WebApplication1.Areas.FoodArea
{
    public class FoodAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FoodArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FoodArea_default",
                "FoodArea/{controller}/{action}/{id}",
                new { controller="Food",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}