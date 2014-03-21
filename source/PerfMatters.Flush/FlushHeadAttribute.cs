using System.Linq;
using System.Web.Mvc;
using PerfMatters.Flush.Hydrators;

namespace PerfMatters.Flush
{
    public class FlushHeadAttribute : ActionFilterAttribute
    {
        public string Title { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller;
            controller.FlushHead(new TitleHydrator(Title));
        }
    }

    public class GlobalFlushHeadAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller;
            var hydrators = DependencyResolver.Current.GetServices<IHydrator>();
            controller.FlushHead((hydrators ?? Enumerable.Empty<IHydrator>()).ToArray());
        }
    }
}