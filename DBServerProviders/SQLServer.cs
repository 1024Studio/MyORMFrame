using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace MyORMFrame.DBServerProvider
{
    public class SQLServer : IDbServerProvider
    {
        public string ConnectionString
        {
            get;set;
        }
        public string DataBase
        {
            get
            {
                SqlConnection conn = new SqlConnection(ConnectionString);

                return conn.Database;
            }
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

        public DataSet ExcuteDataSet(CommandType cmdType, string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = GetConnection();

            PreparCommand(cmd, cmdText, cmdType, conn);

            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                // 填充DataSet.  
                da.Fill(ds); 

                return ds;
            }
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

        public SqlException ConvertToSqlException(Exception exception)
        {
            SqlException ex = new SqlException(exception.Message, exception.InnerException,  ((System.Data.SqlClient.SqlException)exception).Number);

            return ex;
        }
    }
}
