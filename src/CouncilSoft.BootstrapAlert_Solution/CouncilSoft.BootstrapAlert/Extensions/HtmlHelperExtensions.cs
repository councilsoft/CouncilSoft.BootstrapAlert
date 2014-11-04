using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CouncilSoft.BootstrapAlert.Extensions
{
    /// <summary>
    /// Extension class for HtmlHelper.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Returns bootstrap alert message block.
        /// </summary>
        /// <param name="instance">The instance of MVC helper from the MVC view.</param>
        /// <returns>The rendered HTML and JQuery to display the current alert message.</returns>
        public static String RenderAlertMessages(this HtmlHelper instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            TempDataDictionary tempData = instance.ViewContext.Controller.TempData;
            if (tempData == null || tempData["alertMessage"] == null || tempData["alertType"] == null)
                return String.Empty;

            StringBuilder result = new StringBuilder();                       

            AlertSeverity severity = AlertSeverity.Info;
            Enum.TryParse(tempData["alertType"].ToString(), true, out severity);

            switch (severity)
            {
                case AlertSeverity.Danger:
                    result.AppendLine("<script>$().ready(function () { addAlertToMessageArea(-2, \""
                                        + tempData["alertMessage"].ToString() + "\"); });</script>");
                    break;
                case AlertSeverity.Warning:
                    result.AppendLine("<script>$().ready(function () { addAlertToMessageArea(-1, \""
                                        + tempData["alertMessage"].ToString() + "\"); });</script>");
                    break;
                case AlertSeverity.Info:
                    result.AppendLine("<script>$().ready(function () { addAlertToMessageArea(-0, \""
                                        + tempData["alertMessage"].ToString() + "\"); });</script>");
                    break;
                case AlertSeverity.Success:
                    result.AppendLine("<script>$().ready(function () { addAlertToMessageArea(1, \""
                                        + tempData["alertMessage"].ToString() + "\"); });</script>");
                    break;
                default:
                    result.AppendLine("<script>$().ready(function () { addAlertToMessageArea(0, \""
                                        + tempData["alertMessage"].ToString() + "\"); });</script>");
                    break;
            }

            tempData["alertType"] = null;
            tempData["alertMessage"] = null;
            return result.ToString();
        }

        public static String RenderAlertScriptResource(this HtmlHelper instance) 
        {
            return "<script>" + Properties.Resources.BootstrapAlert + "</script>";
        }

        public static String RenderAlertMessageContainer(this HtmlHelper instance)
        {
            return "<div id=\"messageArea\"></div>";
        }
    }
}
