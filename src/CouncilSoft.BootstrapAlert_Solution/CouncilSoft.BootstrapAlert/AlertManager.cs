using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CouncilSoft.BootstrapAlert
{
    /// <summary>
    /// Static utility class for managing client side status messages.
    /// </summary>
    public static class AlertManager
    {
        /// <summary>
        /// Sets the alert for the mvc view to render. Rendered by Html.RenderAlertMessages().
        /// </summary>
        /// <param name="controllerBase"></param>
        /// <param name="severity"></param>
        /// <param name="alertMessage"></param>
        public static void SetAlert(ControllerBase controllerBase, AlertSeverity severity, String alertMessage)
        {
            if (controllerBase == null)
                throw new ArgumentNullException("controllerBase");
            if (alertMessage == null)
                throw new ArgumentNullException("alertMessage");

            controllerBase.TempData["alertType"] = (Int32)severity;
            controllerBase.TempData["alertMessage"] = alertMessage;
        }

        /// <summary>
        /// Removes the alert from being displayed in the UI.
        /// </summary>
        /// <param name="controllerBase"></param>
        public static void ClearAlert(ControllerBase controllerBase)
        {
            if (controllerBase == null)
                throw new ArgumentNullException("controllerBase");

            controllerBase.TempData["alertType"] = null;
            controllerBase.TempData["alertMessage"] = null;
        }
    }
}
