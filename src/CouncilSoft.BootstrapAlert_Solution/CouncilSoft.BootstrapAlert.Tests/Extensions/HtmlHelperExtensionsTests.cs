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
