using System.Web;
using System.Web.Mvc;

namespace ADVENSCO.Demos.CodeFirstFromDB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
