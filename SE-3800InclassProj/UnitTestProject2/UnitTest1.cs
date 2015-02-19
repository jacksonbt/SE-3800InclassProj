using System;
using System.CodeDom;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SE_3800InclassProj.Controllers.API;
using SE_3800InclassProj.Models;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject2
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var NC = new NumbersController();
            Number max = NC.GetMaxNumber();
            Assert.AreEqual(max.number, 68);
        }
    }
}
