using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Mapping
{
    public class PropertyMappingInfo
    {
        //逻辑列与关系列的映射关系
        public string DbColumnName { get; set; }

        public PropertyTypeRole Property_TypeRole { get; set; } //该属性的数据类型类别，是一般类型，model类，还是model集合

        public Type ReferenceModelType { get; set; }    //该属性引用的其他model的数据类型

        public enum PropertyTypeRole
        {
            Value = 0,
            Model = 1,
            ModelList_To_Obj = 2,
            ModelList_To_List = 3
        }
    }
}
