using System.Web;
using System.Web.Mvc;

namespace BigScholl_2011143452_LeMinhSang
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
