using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using MyORMFrame.DBAccess;

namespace MyORMFrame.DBServerProvider
{
    class SQLServer : IDbServerProvider
    {
        public string ConnectionString
        {
            get;set;
        }

        private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            return conn;
        }

        public int ExcuteNonQuery(CommandType cmdType, string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = GetConnection();

            PreparCommand(cmd, cmdText, cmdType, conn);

            int val = cmd.ExecuteNonQuery();

            conn.Close();
            return val;
        }

        public DbDataReader ExcuteReader(CommandType cmdType, string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = GetConnection();

            PreparCommand(cmd, cmdText, cmdType, conn);

            SqlDataReader dataReader = cmd.ExecuteReader();

            return dataReader;
        }

        public object ExcuteScalar(CommandType cmdType, string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = GetConnection();

            PreparCommand(cmd, cmdText, cmdType, conn);

            object obj = cmd.ExecuteScalar();

            return obj;
        }

        private void PreparCommand(SqlCommand cmd, string cmdText, CommandType cmdType, SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandType = cmdType;

            cmd.CommandText = cmdText;
            
        }
    }
}
