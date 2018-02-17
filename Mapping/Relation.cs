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

        public List<ColumnOfRelationModel> Columns { get; set; }

        public RelationModel(string relationName)
        {
            if (relationName != null && relationName != "")
            {
                this.TbName = relationName;
                this.Columns = new List<ColumnOfRelationModel>();
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

    public class ColumnOfRelationModel
    {
        public string ColumnName { get; set; }

        public string TypeName { get; set; }

        public RelationModelColumnSetting ColumnSetting { get; set; }

        public ColumnOfRelationModel(string ColumnName, string TypeName, RelationModelColumnSetting ColumnSetting)
        {

        }

    }

    public class RelationModelColumnSetting
    {
        public bool IsPrimaryKey { get; set; }

        public bool AllowNull { get; set; }

        public int Size { get; set; }

        public RelationModelColumnSetting(bool isPrimaryKey, bool allowNull)
        {

        }
    }
}
