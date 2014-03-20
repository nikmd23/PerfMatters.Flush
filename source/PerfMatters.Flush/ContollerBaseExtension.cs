using System.Web.Mvc;
using PerfMatters.Flush.Hydrators;

namespace PerfMatters.Flush
{
    public static class ControllerBaseExtension
    {
        public static void Flush(this ControllerBase controller, ActionResult result)
        {
            result.ExecuteResult(controller.ControllerContext);
            controller.ControllerContext.HttpContext.Response.Flush();
        }

        public static void FlushHead(this ControllerBase controller, string title)
        {
            FlushHead(controller, new TitleHydrator(title));
        }

        public static void FlushHead(this ControllerBase controller, object model)
        {
            FlushHead(controller, new ModelHydrator(model));
        }

        public static void FlushHead(this ControllerBase controller, params IHydrator[] hydrators)
        {
            if (hydrators != null) {
                foreach (var hydrator in hydrators) {
                    if (hydrator == null) continue;
                    hydrator.Hydrate(controller);
                }
            }

            var partialViewResult = new PartialViewResult
            {
                ViewName = "_Head",
                ViewData = controller.ViewData,
                TempData = controller.TempData,
            };

            controller.ViewBag.HeadFlushed = true;
            Flush(controller, partialViewResult);
        }
    }
}