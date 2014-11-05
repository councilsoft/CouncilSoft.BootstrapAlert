using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CouncilSoft.BootstrapAlert.UIMvcSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AlertManager.AppendAlert(this,
                new AlertDetail()
                {
                    AlertMessage = "Test DANGER message.",
                    Severity = AlertSeverity.Danger,
                    AutoDismissTime = new TimeSpan(0, 0, 5)
                });
            AlertManager.AppendAlert(this,
                new AlertDetail()
                {
                    AlertMessage = "Test WARNING message.",
                    Severity = AlertSeverity.Warning,
                    AutoDismissTime = new TimeSpan(0, 0, 4)
                });
            AlertManager.AppendAlert(this,
                new AlertDetail()
                {
                    AlertMessage = "Test INFO message.",
                    Severity = AlertSeverity.Info,
                    AutoDismissTime = new TimeSpan(0, 0, 3)
                });
            AlertManager.AppendAlert(this,
                new AlertDetail()
                {
                    AlertMessage = "Test SUCCESS message.",
                    Severity = AlertSeverity.Success,
                    AutoDismissTime = new TimeSpan(0, 0, 2)
                });
            return View();
        }

        [HttpPost]
        public ActionResult Index(Guid? id)
        {
            // Note the setting of "EnableCrossView". This puts the alert into TempData
            // so that it will be available over in the other view.

            AlertManager.AppendAlert(this, new AlertDetail()
            {
                AlertMessage = "Test DANGER message.",
                Severity = AlertSeverity.Danger,
                AutoDismissTime = new TimeSpan(0, 0, 5),
                EnableCrossView = true
            });
            AlertManager.AppendAlert(this, new AlertDetail()
            {
                AlertMessage = "Test WARNING message.",
                Severity = AlertSeverity.Warning,
                AutoDismissTime = new TimeSpan(0, 0, 4),
                EnableCrossView = true

            });
            AlertManager.AppendAlert(this, new AlertDetail()
            {
                AlertMessage = "Test INFO message.",
                Severity = AlertSeverity.Info,
                AutoDismissTime = new TimeSpan(0, 0, 3),
                EnableCrossView = true

            });
            AlertManager.AppendAlert(this, new AlertDetail()
            {
                AlertMessage = "Test SUCCESS message.",
                Severity = AlertSeverity.Success,
                AutoDismissTime = new TimeSpan(0, 0, 2),
                EnableCrossView = true

            });

            return RedirectToAction("Index", "About");
        }
    }
}