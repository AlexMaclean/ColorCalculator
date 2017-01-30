using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteganographyEngine;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStegonography()
        {
            string testMessage = "test123";
            string fileName = "TestImage.bmp";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            var steganography = new Steganography("zzz");
            var image = steganography.EncryptImage(path, testMessage);
            string message = steganography.DecryptImage(image);
            Assert.AreEqual(testMessage, message);
        }
    }
}
