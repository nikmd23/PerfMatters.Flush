using System;
using System.Web.Mvc;

namespace CourtesyFlush
{
    public class FlushHeadAttribute : ActionFilterAttribute
    {
        public string Title { get; set; }
        public bool FlushAntiForgeryToken { get; set; }

        private readonly Func<ActionDescriptor, ViewDataDictionary> _viewDataFunction;

        public FlushHeadAttribute()
        {
        }

        public FlushHeadAttribute(Func<ActionDescriptor, ViewDataDictionary> viewDataFunction)
        {
            _viewDataFunction = viewDataFunction;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller;

            if (_viewDataFunction != null)
                controller.ViewData = _viewDataFunction(filterContext.ActionDescriptor);

            controller.FlushHead(Title, null, FlushAntiForgeryToken);
        }
    }
}