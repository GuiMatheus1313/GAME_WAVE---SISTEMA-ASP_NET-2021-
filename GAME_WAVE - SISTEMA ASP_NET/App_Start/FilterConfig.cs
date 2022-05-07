using System.Web;
using System.Web.Mvc;

namespace GAME_WAVE___SISTEMA_ASP_NET
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
