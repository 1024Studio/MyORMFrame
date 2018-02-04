using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.SQLScriptCreator
{
    //可能需要重构
    public class SQLScriptCreator
    {
        SQLScript InsertInto(string tableName, string[] columns, string[] values)
        {
            return null;
        }

        SQLScript InsertInto(string tableName, string[] values)
        {
            return null;
        }

        SQLScript Delete(string tableName, string condition)
        {
            return null;
        }

        SQLScript Update(string tableName, string[] columns, string[] values, string condition)
        {
            return null;
        }

        SQLScript Update(string tableName, string[] columns, string[] values)
        {
            return null;
        }

        SQLScript Select(string[] tablesName, string[] columns, string condition)
        {
            return null;
        }
    }
}
