using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Mapping
{
    public class RelationModel
    {
        public string TbName { get; set; }

        public List<RelationModelColumn> Columns { get; set; }

        public RelationModel(string relationName)
        {
            if (relationName != null && relationName != "")
            {
                this.TbName = relationName;
                this.Columns = new List<RelationModelColumn>();
            }
            else
            {
                throw new Exception("tbName 不能为空");
            }            
        }

        public List<string> GetAllColumnsName()
        {
            //可以优化
            List<string> allColumnsName = new List<string>();

            foreach (var column in Columns)
            {
                allColumnsName.Add(column.ColumnName);
            }
            return allColumnsName;
        }
    }

    public class RelationModelColumn
    {
        public string ColumnName { get; set; }

        public string TypeName { get; set; }

        public string Size { get; set; }

        public string ConstraintsStr { get; set; }

        public bool ReadOnly { get; set; }
        //还不如直接改成sql字串

        public RelationModelColumn(string ColumnName, string TypeName, string Size, string ConstraintsStr, bool readOnly = false)
        {
            this.ColumnName = ColumnName;

            this.TypeName = TypeName;

            this.Size = Size;

            this.ConstraintsStr = ConstraintsStr != null ? ConstraintsStr : string.Empty;

            this.ReadOnly = readOnly;
        }
    }   
}
