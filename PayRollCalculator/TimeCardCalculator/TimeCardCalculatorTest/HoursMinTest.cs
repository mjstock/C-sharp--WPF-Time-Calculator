using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeCardCalculator;


namespace TimeCardCalculatorTest
{
    [TestClass]
    public class HoursMinTest
    {
        [TestMethod]
        public void Hours_In_Range()
        {
            //arrange
            int[] expected = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            HourMin hour = new HourMin();

            //act
            int[] actual = hour.Hours;
            Assert.AreEqual(expected,actual);
            
        }
    }
}
