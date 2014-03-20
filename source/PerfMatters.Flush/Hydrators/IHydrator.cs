using System.Web.Mvc;

namespace PerfMatters.Flush.Hydrators
{
    public interface IHydrator
    {
        void Hydrate(ControllerBase controller);
    }

    public class TitleHydrator : IHydrator
    {
        private readonly string _title;

        public TitleHydrator(string title)
        {
            _title = title;
        }

        public void Hydrate(ControllerBase controller)
        {
            if (string.IsNullOrEmpty(_title))
                return;

            controller.ViewBag.Title = _title;
        }
    }

    public class ModelHydrator : IHydrator
    {
        private readonly object _model;

        public ModelHydrator(object model)
        {
            _model = model;
        }

        public void Hydrate(ControllerBase controller)
        {
            if (_model == null)
                return;

            controller.ViewData.Model = _model;
        }
    }

}
