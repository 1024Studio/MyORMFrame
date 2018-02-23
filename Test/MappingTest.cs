using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyORMFrame.Mapping;
using System.Collections.Generic;
using System.Collections;

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
            var members = typeof(List<int>);
            IEnumerable list_entity = (IEnumerable)members.Assembly.CreateInstance(members.FullName);
            var referenceModelType = members.GetGenericArguments();//获取集合中的元素的数据类型

            var res = members.GetInterface("IEnumerable`1");

            ModelUtil m = new ModelUtil(typeof(StudentModel));
            var s = m.GetPropertyMappingInfo("Class");
            return;
        }
    }
}
