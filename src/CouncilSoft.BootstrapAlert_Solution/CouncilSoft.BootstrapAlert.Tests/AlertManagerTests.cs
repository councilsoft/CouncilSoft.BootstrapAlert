using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CouncilSoft.BootstrapAlert.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CouncilSoft.BootstrapAlert.Tests
{
    [TestClass]
    public class AlertManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AppendAlertWithNullControllerArgument_ShouldThrowException()
        {
            ControllerBase controllerBase = null;
            AlertDetail alert = new AlertDetail();
            AlertManager.AppendAlert(controllerBase, alert);

            Assert.Fail("Should have thrown ArgumentNullException.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AppendAlertWithNullAlertArgument_ShouldThrowException()
        {
            ControllerBase controllerBase = new MockController();
            AlertDetail alert = null;
            AlertManager.AppendAlert(controllerBase, alert);

            Assert.Fail("Should have thrown ArgumentNullException.");
        }

        [TestMethod]
        public void AppendAlertWithViewDataAlert_ShouldSaveToQueue()
        {
            Int32 expected = 1;
            Int32 actual = 0;
            ControllerBase controllerBase = new MockController();
            AlertDetail alert = new AlertDetail() { AlertMessage = "Unit Test" };
            AlertManager.AppendAlert(controllerBase, alert);

            Assert.IsNotNull(controllerBase.ViewData["CouncilSoft.BootstrapAlerts"]);

            Queue<AlertDetail> queue = controllerBase.ViewData["CouncilSoft.BootstrapAlerts"] as Queue<AlertDetail>;

            Assert.IsNotNull(queue);

            actual = queue.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppendAlertWithTempDataAlert_ShouldSaveToQueue()
        {
            Int32 expected = 1;
            Int32 actual = 0;
            ControllerBase controllerBase = new MockController();
            AlertDetail alert = new AlertDetail() { AlertMessage = "Unit Test", EnableCrossView = true };
            AlertManager.AppendAlert(controllerBase, alert);

            Assert.IsNotNull(controllerBase.TempData["CouncilSoft.BootstrapAlerts"]);

            Queue<AlertDetail> queue = controllerBase.TempData["CouncilSoft.BootstrapAlerts"] as Queue<AlertDetail>;

            Assert.IsNotNull(queue);

            actual = queue.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
