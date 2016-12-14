using ReflectionDemo.Models;
using System.Web;
using System.Web.Mvc;

namespace ReflectionDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            ModelBinders.Binders.DefaultBinder = new TrimModelBinder();
        }
    }
}