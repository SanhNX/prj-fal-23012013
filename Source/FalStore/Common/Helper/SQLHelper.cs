using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Common.Helper
{
    public static class SQLHelper
    {

        /// <summary>
        /// ConnectionString
        /// </summary>
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        public static SqlDataReader ExecuteReader(string storedProcedureName, Collection<SqlParameter> parameterList)
        {
            SqlDataReader result = null;
            try
            {
                var conn = new SqlConnection(ConnectionString);
                conn.Open();

                var cmd = new SqlCommand(storedProcedureName, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Clear();

                if (parameterList != null)
                {
                    for (int i = 0; i < parameterList.Count; i++)
                    {
                        cmd.Parameters.Add(parameterList[i]);
                    }
                }

                result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (parameterList != null)
                {
                    for (int i = 0; i < parameterList.Count; i++)
                    {
                        if (parameterList[i].Direction == ParameterDirection.Output ||
                            parameterList[i].Direction == ParameterDirection.InputOutput ||
                            parameterList[i].Direction == ParameterDirection.ReturnValue) // if is output
                        {
                            parameterList[i].Value = cmd.Parameters[parameterList[i].ParameterName].Value;
                        }
                    }
                }

                return result;
            }
            catch
            {
                if (result != null)
                {
                    result.Close();
                }
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string storedProcedureName)
        {
            SqlDataReader result = null;
            try
            {
                var conn = new SqlConnection(ConnectionString);
                conn.Open();

                var cmd = new SqlCommand(storedProcedureName, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Clear();

                result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return result;
            }
            catch
            {
                if (result != null)
                {
                    result.Close();
                }
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string storedProcedureName, Collection<SqlParameter> parameterList)
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(storedProcedureName, conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Clear();

            if (parameterList != null)
            {
                for (int i = 0; i < parameterList.Count; i++)
                {
                    cmd.Parameters.Add(parameterList[i]);
                }
            }
            int result = cmd.ExecuteNonQuery();

            if (parameterList != null)
            {
                for (int i = 0; i < parameterList.Count; i++)
                {
                    if (parameterList[i].Direction == ParameterDirection.Output ||
                        parameterList[i].Direction == ParameterDirection.InputOutput ||
                        parameterList[i].Direction == ParameterDirection.ReturnValue)
                        parameterList[i].Value = cmd.Parameters[parameterList[i].ParameterName].Value;
                }
            }
            conn.Dispose();
            return result;
        }


    }
}
