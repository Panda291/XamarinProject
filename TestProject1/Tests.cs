using System;
using System.IO;
using NUnit.Framework;
using XamarinProject.Models;
using XamarinProject.Services;
using XamarinProject.Views;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void LevelFalseForLowerThan0()
        {
            NewItemPage obj = new NewItemPage(true);
            var output = obj.IsValidLevel(-1);
            Assert.AreEqual(output, -1, 0, "input smaller than 0 but output not -1");
        }

        [Test]
        public void LevelFalseForHigherThan12()
        {
            NewItemPage obj = new NewItemPage(true);
            var output = obj.IsValidLevel(13);
            Assert.AreEqual(output, 1, 0, "input higher than 12 but output not 1");
        }

        [Test]
        public void LevelTrueForEquals0()
        {
            NewItemPage obj = new NewItemPage(true);
            var output = obj.IsValidLevel(0);
            Assert.AreEqual(output, 0, 0, "input is 0 but output not 0");
        }

        [Test]
        public void LevelTrueForEquals12()
        {
            NewItemPage obj = new NewItemPage(true);
            var output = obj.IsValidLevel(12);
            Assert.AreEqual(output, 0, 0, "input is 12 but output not 0");
        }

        [Test]
        public void LevelTrueForbetween0and12()
        {
            NewItemPage obj = new NewItemPage(true);
            var output = obj.IsValidLevel(7);
            Assert.AreEqual(output, 0, 0, "input is valid but output not 0");
        }

        [Test]
        public void AmountFalseForLowerThan0()
        {
            NewItemPage obj = new NewItemPage(true);
            var output = obj.IsValidAmount(-1);
            Assert.False(output);
        }
        [Test]
        public void AmountFalseForEqualTo0()
        {
            NewItemPage obj = new NewItemPage(true);
            var output = obj.IsValidAmount(0);
            Assert.False(output);
        }
        [Test]
        public void AmountTrueForHigherThan0()
        {
            NewItemPage obj = new NewItemPage(true);
            var output = obj.IsValidAmount(1);
            Assert.True(output);
        }
    }
}