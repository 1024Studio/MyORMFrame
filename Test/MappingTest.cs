using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mapping;

namespace Test
{
    [TestClass]
    public class MappingTest
    {
        public static void Main(string[] args)
        {
            TestMethod1();
        }
        [TestMethod]
        public static void TestMethod1()
        {
            IMappingData data = new MappingData(typeof(studentModel));

            return;
        }
    }
}
