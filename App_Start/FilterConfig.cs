using System.Web;
using System.Web.Mvc;

namespace innRoadAssignment_Dynamic
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
