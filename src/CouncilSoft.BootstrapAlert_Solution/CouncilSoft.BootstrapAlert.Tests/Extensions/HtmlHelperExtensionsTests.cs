using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CouncilSoft.BootstrapAlert.Extensions;
using CouncilSoft.BootstrapAlert.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CouncilSoft.BootstrapAlert.Tests.Extensions
{
    [TestClass]
    public class HtmlHelperExtensionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RenderAlertMessageContainerWithNullArgument_ShouldThrowException()
        {
            HtmlHelper instance = null;
            HtmlHelperExtensions.RenderAlertMessageContainer(instance);

            Assert.Fail("Should have thrown an ArgumentNullException.");
        }

        [TestMethod]
        public void RenderAlertMessageContainerWithValidArgument_ReturnsExpected()
        {
            String expected = "<div id=\"messageArea\"></div>";
            String actual = String.Empty;
            HtmlHelper instance = new MockHtmlHelper();
            
            actual = HtmlHelperExtensions.RenderAlertMessageContainer(instance);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RenderAlertScriptResourceWithNullArgument_ShouldThrowException()
        {
            HtmlHelper instance = null;
            HtmlHelperExtensions.RenderAlertScriptResource(instance);

            Assert.Fail("Should have thrown an ArgumentNullException.");
        }

        [TestMethod]
        public void RenderAlertScriptResourceWithValidArgument_ReturnsExpected()
        {
            String expected = "<script>function addAlertToMessageArea(severity, alertMessage, autoDismissInMilliseconds, showDismissButton) {\r\n\tconsole.log(\"Queueing new alert: '\" + alertMessage + \"'\");\r\n    $messageArea = $('#messageArea');\r\n    var alertLevel = \"alert-info\";\r\n    var glyph = \"glyphicon-info-sign\";\r\n    var html;\r\n\r\n     if (severity == -2) {\r\n        alertLevel = \"alert-danger\";\r\n        glyph = \"glyphicon-remove-sign\";\r\n\t\tname = \"Error\";\r\n    }\r\n    else if (severity == -1) {\r\n        alertLevel = \"alert-warning\";\r\n        glyph = \"glyphicon-exclamation-sign\";\r\n\t\tname = \"Warning\";\r\n    }\r\n    else if (severity == 0) {\r\n        alertLevel = \"alert-info\";\r\n        glyph = \"glyphicon-info-sign\";\r\n\t\tname = \"Info\";\r\n    }\r\n    else if (severity == 1) {\r\n        alertLevel = \"alert-success\";\r\n        glyph = \"glyphicon-ok-sign\";\r\n\t\tname = \"Success\";\r\n    }\r\n\r\n    var randomNumber = Math.round(Math.random() * 999999);\r\n    var newId = \"message_\" + randomNumber;\r\n\r\n    html = \"<div class='alert \" + alertLevel + \" alert-dismissible' role='alert' id='\" + newId + \"'>\";\r\n\tif (showDismissButton)\r\n\t{\r\n\t\thtml += \"<button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>&times;</span>\";\r\n\t\thtml += \"<span class='sr-only'>Close</span></button>\";\r\n\t}\r\n    html += \"<i class='glyphicon \" + glyph + \"'></i>&nbsp;\";\r\n\thtml += \"<strong>\" + name + \":</strong>&nbsp;\"\r\n    html += alertMessage;\r\n    html += \"</div>\";\r\n\r\n    $messageArea.append(html);\r\n\r\n\tconsole.log(\"Auto-dismiss in \" + autoDismissInMilliseconds);\r\n    if ( autoDismissInMilliseconds > 0 )\r\n\t{\r\n\t\tconsole.log(\"Dismissing message...\");\r\n\t\twindow.setTimeout(function() {\r\n\t\t\t$(\"#\" + newId).fadeTo(500, 0).slideUp(500, function(){\r\n\t\t\t\t$(this).remove();\r\n\t\t\t});\r\n\t\t}, autoDismissInMilliseconds);\r\n\t}\r\n}</script>";
            String actual = String.Empty;
            HtmlHelper instance = new MockHtmlHelper();

            actual = HtmlHelperExtensions.RenderAlertScriptResource(instance);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RenderAlertMessagesFromQueueWithNullArgument_ShouldThrowException()
        {
            HtmlHelper instance = null;
            HtmlHelperExtensions.RenderAlertMessagesFromQueue(instance);

            Assert.Fail("Should have thrown an ArgumentNullException.");
        }

        [TestMethod]
        public void RenderAlertMessagesFromQueueWithValidArgumentAndNoMessage_ReturnsExpected()
        {
            String expected = "\r\n\r\n";
            String actual = String.Empty;
            HtmlHelper instance = new MockHtmlHelper();
            instance.ViewContext.Controller = new MockController();

            actual = HtmlHelperExtensions.RenderAlertMessagesFromQueue(instance);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RenderAlertMessagesFromQueueWithValidArgumentAndValidMessage_ReturnsExpected()
        {
            String expected = "\r\n<script>$().ready(function () { addAlertToMessageArea(0, 'No message set.',0,1); });</script>\r\n\r\n";
            String actual = String.Empty;
            Controller controller = new MockController();
            AlertManager.AppendAlert(controller, new AlertDetail());
            HtmlHelper instance = new MockHtmlHelper();
            instance.ViewContext.Controller = controller;

            actual = HtmlHelperExtensions.RenderAlertMessagesFromQueue(instance);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProcessQueueWithNullQueue_ReturnsEmptyString()
        {
            String expected = String.Empty;
            String actual = "Not String.Empty";

            Queue<AlertDetail> queue = null;
            actual = HtmlHelperExtensions.ProcessQueue(queue);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProcessQueueWithValidQueue_ReturnsExpected()
        {
            String expected = "<script>$().ready(function () { addAlertToMessageArea(0, 'No message set.',0,1); });</script>\r\n";
            String actual = String.Empty;

            Queue<AlertDetail> queue = new Queue<AlertDetail>();
            queue.Enqueue(new AlertDetail());
            actual = HtmlHelperExtensions.ProcessQueue(queue);

            Assert.AreEqual(expected, actual);
        }
    }
}
