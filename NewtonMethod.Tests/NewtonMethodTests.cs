using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewtonMethod;

namespace NewtonMethod.Tests
{
    [TestClass]
    public class NewtonMethodTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void NewtonMethod_2RootOf9_3Returned()
        {
            double number = 9;
            int pow = 2;

            double result = NewtonMethod.Root(number, pow);

            Assert.AreEqual(result, 3.0);
        }

        [TestMethod]
        public void NewtonMethod_0RootOf9_NaNReturned()
        {
            double number = 9;
            int pow = 0;

            double result = NewtonMethod.Root(number, pow);

            Assert.AreEqual(result, Double.NaN);
        }

        [TestMethod]
        public void NewtonMethod_2RootOfMinus9_NaNReturned()
        {
            double number = -9;
            int pow = 2;

            var result = NewtonMethod.Root(number, pow);

            Assert.AreEqual(result, Double.NaN);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NewtonMethod_NegtiveAccuracy_ArgumentException()
        {
            double number = 9;
            int pow = 2;
            double eps = -0.15;

            NewtonMethod.Root(number, pow, eps);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                    "|DataDirectory|\\NewtonMethodTestCases.xml",
                    "TestCase",
                     DataAccessMethod.Sequential)]
        [DeploymentItem("NewtonMethod.Tests\\\\NewtonMethodTestCases.xml")]
        [TestMethod]
        public void NewtonMethod_DDT()
        {
            double number = double.Parse(TestContext.DataRow["Number"].ToString());
            int pow = int.Parse(TestContext.DataRow["Pow"].ToString());
            double expResult = double.Parse(TestContext.DataRow["Result"].ToString());

            double newtonResult = Math.Round(NewtonMethod.Root(number, pow), 4);

            Assert.AreEqual(newtonResult, expResult);
        }
    }
}
