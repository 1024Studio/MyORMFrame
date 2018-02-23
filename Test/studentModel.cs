using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMFrame.Mapping;

namespace MyORMFrame.Test
{
    
    public class StudentModel
    {
        public int id { get; set; }
        public List<Class> Class { get;set;}
    }

    public class @Class
    {
        public int id { get; set; }
        public List<StudentModel> students { get; set; }
    }
}
