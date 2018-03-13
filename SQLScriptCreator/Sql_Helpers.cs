using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.SQL
{
    public class CreateDB : ISqlHelper
    {
        private string dbName { get; set; }
        static CreateDB instance { get; set; }
        private CreateDB() { }

        public static CreateDB CreateDb(string databaseName)
        {
            if (instance == null)
                instance = new CreateDB();

            return instance;
        }
        public void Flush()
        {
            dbName = null;
        }
        public SqlScript ToSql()
        {
            return new SqlScript(string.Format("create database {0}", dbName));
        }
    }

    public class CreateTable : ISqlHelper
    {
        private string TbName { get; set; }

        private List<string> Columns { get; set; }

        static CreateTable instance { get; set; }

        private CreateTable() { }
        public static CreateTable CreateTb(string tableName)
        {
            if (instance == null)
                instance = new CreateTable();

            instance.Flush();
            instance.TbName = tableName;
            instance.Columns = new List<string>();

            return instance;
        }
        public CreateTable AddColumn(string columnName, string type, string size, string constraints)
        {
            if (TbName != null && columnName != null && type != null)
            {
                size = size != null ? string.Format("({0})", size) : string.Empty;
                Columns.Add(string.Format("{0} {1}{2} {3}", columnName, type, size, constraints));
            }

            return this;
        }

        public void Flush()
        {
            TbName = null;
            Columns = null;
        }

        public SqlScript ToSql()
        {
            if (TbName != null)
            {
                string sql = string.Format("create table {0}(", TbName);

                for (int i = 0; i < (Columns.Count - 1); i++)
                {
                    sql += Columns[i] + ",";
                }

                sql += Columns[Columns.Count - 1] + ");";

                return new SqlScript(sql);

            }
            else
            {
                return null;
            }

        }
    }

    public class InsertInto : ISqlHelper
    {
        private string TableName { get; set; }

        private List<string> Values { get; set; }

        static InsertInto instance { get; set; }

        private InsertInto() { }
        public static InsertInto InSertInto(string tableName)
        {
            if (instance == null)
            {
                instance = new InsertInto();
            }
            instance.Flush();
            return instance;
        }
        public void Flush()
        {
            this.TableName = null;
            this.Values = null;
        }
        public SqlScript ToSql()
        {
            throw new NotImplementedException();
        }
    }

    public class Select : ISqlHelper
    {
        private List<string> Tables { get; set; }
        private List<string> Columns { get; set; }
        private string Where { get; set; }

        private static Select instance { get; set; }
        private Select() { }

        public static Select From(List<string> tables)
        {
            if (instance == null)
            {
                instance = new Select();
            }

            instance.Flush();
            if (tables != null)
                instance.Tables = tables;
            else
                instance.Tables = new List<string>();

            instance.Columns = new List<string>();
            instance.Where = string.Empty;
            return instance;
        }
        public Select AddColumns(string ColumnName)
        {
            if (!Columns.Contains(ColumnName))
                Columns.Add(ColumnName);

            return this;
        }
        public Select SetWhere(string Where)
        {
            if(Where != null)
                this.Where = Where;

            return this;
        }
        public void Flush()
        {
            Tables = null;
            Columns = null;
            Where = null;
        }
        public SqlScript ToSql()
        {
            if (Tables.Count > 0)
            {
                string sql = "Select {0} FROM {1} {2}";
                string columns = string.Empty;
                string tables = string.Empty;
                string where = Where != string.Empty ? string.Format("WHERE {0}", Where) : string.Empty;
                foreach (var c in Columns)
                {
                    if (columns == string.Empty)
                    {
                        columns = c;
                        continue;
                    }
                        
                    columns = string.Format("{0},{1}", columns, c);
                }

                foreach (var t in Tables)
                {
                    if(tables == string.Empty)
                    {
                        tables = t;
                        continue;
                    }
                    tables = string.Format("{0},{1}", tables, t);
                }

                sql = string.Format(sql, columns, tables, where);

                return new SqlScript(sql);
            }

            return null;
        }
    }
    public class Update : ISqlHelper
    {
        public SqlScript ToSql()
        {
            throw new NotImplementedException();
        }
    }
 }

