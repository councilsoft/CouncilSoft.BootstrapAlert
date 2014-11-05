using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace CouncilSoft.BootstrapAlert.Tests.Mocks
{
    public class MockController : Controller
    {
    }

    public class MockHtmlHelper : HtmlHelper
    {
        public MockHtmlHelper()
            : base(new ViewContext(), new MockViewDataContainer())
        {
        }

        public MockHtmlHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, 
            RouteCollection routeCollection)
            : base(viewContext, viewDataContainer, routeCollection)
        {
        }
    }

    public class MockViewDataContainer : IViewDataContainer
    {
        public ViewDataDictionary ViewData { get; set; }
    }
    
}
