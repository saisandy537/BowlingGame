using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling;

namespace UnitTestGame
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestRoll()             // Test method written to test Roll method
        {
            Game obj = new Game();


            Assert.AreEqual(-1, obj.Roll(-1));

            Assert.AreEqual(0, obj.Roll(0));
            Assert.AreEqual(0, obj.Roll(1));

            Assert.AreEqual(0, obj.Roll(10));
            Assert.AreEqual(-1, obj.Roll(11));




        }

        [TestMethod]
        public void TestScore()         // Test method written to test score method
        {
            Game obj = new Game();

            obj.Roll(1);
            obj.Roll(4);

            obj.Roll(4);
            obj.Roll(5);

            obj.Roll(6);
            obj.Roll(4);

            obj.Roll(5);
            obj.Roll(5);

            obj.Roll(10);

            obj.Roll(0);
            obj.Roll(1);

            obj.Roll(7);
            obj.Roll(3);

            obj.Roll(6);
            obj.Roll(4);

            obj.Roll(10);
            obj.Roll(2);

            obj.Roll(8);
            obj.Roll(6);

            Assert.AreEqual(133, obj.Score());
        }

        [TestMethod]
        public void TestSpares()               // Test method written to test Spare method
        {
            Game obj = new Game();

            obj.Roll(1);
            obj.Roll(4);

            obj.Roll(4);
            obj.Roll(5);

            obj.Roll(6);
            obj.Roll(4);

            obj.Roll(2);
            obj.Roll(4);

            Assert.AreEqual(2, obj.SpareValue(2));
        }

        [TestMethod]
        public void TestStrike()               // Test method written to test strike method
        {
            Game obj = new Game();

            obj.Roll(1);
            obj.Roll(4);

            obj.Roll(10);

            obj.Roll(4);
            obj.Roll(5);

            obj.Roll(4);
            obj.Roll(4);

            Assert.AreEqual(9, obj.strikeValue(1));
        }
    }
}