using System;
using System.IO;
using NUnit.Framework;
using XamarinProject.Models;
using XamarinProject.Services;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void falseForLowerThan5()
        {
            ClassForUnitTest obj = new ClassForUnitTest();
            var output = obj.isBetween5and10(4);
            Assert.AreEqual(output, -1, 0, "input smaller than 5 but output not -1");
        }

        [Test]
        public void falseForHigherThan10()
        {
            ClassForUnitTest obj = new ClassForUnitTest();
            var output = obj.isBetween5and10(11);
            Assert.AreEqual(output, 1, 0, "input higher than 10 but output not 1");
        }

        [Test]
        public void trueForEquals5()
        {
            ClassForUnitTest obj = new ClassForUnitTest();
            var output = obj.isBetween5and10(5);
            Assert.AreEqual(output, 0, 0, "input is 5 but output not 0");
        }

        [Test]
        public void trueForEquals10()
        {
            ClassForUnitTest obj = new ClassForUnitTest();
            var output = obj.isBetween5and10(10);
            Assert.AreEqual(output, 0, 0, "input is 10 but output not 0");
        }

        [Test]
        public void trueForbetween5and10()
        {
            ClassForUnitTest obj = new ClassForUnitTest();
            var output = obj.isBetween5and10(7);
            Assert.AreEqual(output, 0, 0, "input is valid but output not 0");
        }
    }
}