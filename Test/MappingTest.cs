using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyORMFrame.Mapping;
namespace MyORMFrame.Test
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
            IMappingData data = new MappingData(typeof(studentModel), MappingDataFactory.typeMappingMethod);

            return;
        }
    }
}
