using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CouncilSoft.BootstrapAlert.Tests
{
    [TestClass]
    public class AlertDetailTests
    {
        [TestMethod]
        public void ConstructorWithNoArguments_ReturnsInstance()
        {
            AlertDetail instance = new AlertDetail();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ConstructorWithNoArgumentsVerifyDefaults_ReturnsInstance()
        {
            AlertDetail instance = new AlertDetail();

            Assert.AreEqual(instance.Severity , AlertSeverity.Info);
            Assert.AreEqual(instance.AlertMessage , "No message set.");
            Assert.AreEqual(instance.AutoDismissTime , new TimeSpan(0));
            Assert.AreEqual(instance.ShowDismissButton , true);
            Assert.AreEqual(instance.EnableCrossView , false);
        }
    }
}
