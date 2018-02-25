using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.SQL
{
    //可能需要重构
    public class SQLScriptCreator
    {
        SqlScript InsertInto(string tableName, string[] columns, string[] values)
        {
            return null;
        }

        SqlScript InsertInto(string tableName, string[] values)
        {
            return null;
        }

        SqlScript Delete(string tableName, string condition)
        {
            return null;
        }

        SqlScript Update(string tableName, string[] columns, string[] values, string condition)
        {
            return null;
        }

        SqlScript Update(string tableName, string[] columns, string[] values)
        {
            return null;
        }

        SqlScript Select(string[] tablesName, string[] columns, string condition)
        {
            return null;
        }
    }
}
