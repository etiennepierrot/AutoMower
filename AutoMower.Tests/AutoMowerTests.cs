using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMower.Tests
{
    [TestClass]
    public class AutoMowerTests
    {
        private Domain.AutoMower _autoMower;

        [TestInitialize]
        public void Setup()
        {
            _autoMower = new Domain.AutoMower();

        }

        [TestMethod]
        public void Move_One_Mower_To_The_Left()
        {
            Assert.AreEqual("0 0 W", 
                _autoMower.Run("5 5\r\n1 0 N\r\nLF"));
        }
        
        [TestMethod]
        public void Move_One_Mower_To_The_Right()
        {
            Assert.AreEqual("2 0 E",
                _autoMower.Run("5 5\r\n1 0 N\r\nRF"));
        }

        [TestMethod]
        public void Move_Two_Mower()
        {
            Assert.AreEqual("1 1 N\r\n2 1 N", 
                _autoMower.Run("5 5\r\n1 0 N\r\nF\r\n2 0 N\r\nF\r\n"));
        }

        [TestMethod]
        public void Example_From_Spec()
        {
            Assert.AreEqual("1 3 N\r\n5 1 E", 
                _autoMower.Run("5 5\r\n1 2 N\r\nLFLFLFLFF\r\n3 3 E\r\nFFRFFRFRRF\r\n"));

        }

    }
}
