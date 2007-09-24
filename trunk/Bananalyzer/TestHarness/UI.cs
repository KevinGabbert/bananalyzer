using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

namespace TestHarness
{
    [TestFixture(Description="Test Harness for UI. Get TestDriven .net to debug functions in Visual Studio")]
    public class UI
    {
        [Test(Description="Verify NUnit Works")]
        public void NUnit_Works()
        {
            Assert.IsTrue(true);
        }
    }
}
