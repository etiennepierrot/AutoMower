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
            Assert.AreEqual("0 0 W", _autoMower.Run("5 5\r\n1 0 N\r\nLF"));
        }
        
        [TestMethod]
        public void Move_One_Mower_To_The_Right()
        {
            Assert.AreEqual("2 0 E", _autoMower.Run("5 5\r\n1 0 N\r\nRF"));
        }
        
    }
}
