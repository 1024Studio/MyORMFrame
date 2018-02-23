using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true,Inherited = false)]
    public class PrimaryKeyAttribute : Attribute
    {
        //注意能设置主键的数据类型, int可以, string 可能不行
        //可能要继承一个转换sql代码的接口
    }
}
