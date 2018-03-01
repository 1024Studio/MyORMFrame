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

            ModelUtil m = new ModelUtil(typeof(Student));
            var s = m.GetPropertyMappingInfo("Class");

            List<RelationModel> relations = new ModelUtil(typeof(Student)).GetRelations();

            InputRelations(relations);
            return;
        }

        public static void InputRelations(List<RelationModel> relations)
        {
            foreach (var r in relations)
            {
                System.Console.WriteLine(r.TbName + ":");
                foreach (var c in r.Columns)
                {
                    System.Console.WriteLine(string.Format(" {0} {1}({2}) {3}", c.ColumnName, c.TypeName, c.Size, c.ConstraintsStr));
                }
                System.Console.WriteLine("\r");

            }

            Console.ReadKey();
        }
    }
}
