namespace DosToCyrillicTextConverter.Tests
{
    using Helpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class CyrillicHelperTests
    {
        [TestMethod]
        public void TestConvertString_ShouldReturnCorrectResult()
        {
            string expected = "COORDTYPE  1970,Балтийска,K5";
            string actual = CyrillicHelper.ConvertString("COORDTYPE  1970,Ѓ «ІЁ©±Є ,K5");

            Assert.AreEqual(expected, actual);
        }
    }
}
