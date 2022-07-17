using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;
using OnlineApp.ServiceRep.DataFacotory;
using Microsoft.Extensions.Configuration;

namespace OnlineApp.Infrastructure.DataFacotory
{
    public class DataAccess : IDataAccess
    {
        public string _ConnectionStrings = ConnectionAttrib._ConStr;
        public string connectionString;
        public SqlConnection sqlConnection;
        private readonly IConfiguration configuration;
        public DataAccess(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void SetConfig(string _ConnectionStringsI = "")
        {
            if (!string.IsNullOrEmpty(_ConnectionStringsI))
                this._ConnectionStrings = _ConnectionStringsI;
            connectionString = configuration.GetConnectionString(this._ConnectionStrings);
            SetSqlConnection();
        }
        public string GetConnectionString()
        {
            return connectionString;
        }
        public void SetSqlConnection()
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
        }
        public SqlCommand GetStoredProcCommond(string storedProcedure)
        {
            SqlCommand SqlCommand = new SqlCommand();
            SqlCommand.CommandText = storedProcedure;
            SqlCommand.CommandType = CommandType.StoredProcedure;
            return SqlCommand;
        }
        //Selects the data based on Query
        public DataTable GetDataTable(string querySelect)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection = sqlConnection;
                cmd.Connection.Open();
                cmd.CommandText = querySelect;
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "-->" + querySelect);
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Dispose();
                da.Dispose();
            }
            return dt;
        }
        //Executes Query for Insert, Delete, Update etc
        public int SQLExecute(string query)
        {
            int result = -1;
            //Getting Selected database specific Adaptor from Factory class
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                result = cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                result = -1;
                cmd.Transaction.Rollback();
                throw new Exception(ex.Message + "-->" + query);
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Dispose();
            }
            return result;
        }

        public DataTable SQLExecuteTable(string SpText, string tableParam, DataTable dtMultiple, Hashtable SqlParameterlist)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = GetStoredProcCommond(SpText);
            cmd.Connection = sqlConnection;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                if (dtMultiple != null && dtMultiple.Rows.Count > 0)
                {
                    SqlParameter SqlParameter = new SqlParameter();
                    SqlParameter.ParameterName = tableParam;
                    SqlParameter.Value = dtMultiple;
                    cmd.Parameters.Add(SqlParameter);
                    if (SqlParameterlist != null)
                    {
                        foreach (DictionaryEntry hparam in SqlParameterlist)
                        {
                            SqlParameter = new SqlParameter();
                            SqlParameter.ParameterName = hparam.Key.ToString();
                            SqlParameter.Value = hparam.Value;
                            cmd.Parameters.Add(SqlParameter);
                        }
                    }
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    cmd.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            return dt;
        }


        public DataSet SQLExecuteTablesByDataSet(string SpText, string[] tableParam, DataSet dtMultiple, Hashtable SqlParameterlist)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = GetStoredProcCommond(SpText);
            cmd.Connection = sqlConnection;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlParameter SqlParameter = null;
                for (int tableCount = 0; tableCount < dtMultiple.Tables.Count; tableCount++)
                {
                    if (dtMultiple.Tables[tableCount] != null && dtMultiple.Tables[tableCount].Rows.Count > 0)
                    {
                        SqlParameter = new SqlParameter();
                        SqlParameter.ParameterName = tableParam[tableCount];
                        SqlParameter.Value = dtMultiple.Tables[tableCount];
                        cmd.Parameters.Add(SqlParameter);
                    }
                }
                if (SqlParameterlist != null)
                {
                    foreach (DictionaryEntry hparam in SqlParameterlist)
                    {
                        SqlParameter = new SqlParameter();
                        SqlParameter.ParameterName = hparam.Key.ToString();
                        SqlParameter.Value = hparam.Value;
                        cmd.Parameters.Add(SqlParameter);
                    }
                }
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            return ds;
        }

        public DataSet SQLExecuteTables(string SpText, string tableParam, DataTable dtMultiple, Hashtable SqlParameterlist)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = GetStoredProcCommond(SpText);
            cmd.Connection = sqlConnection;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                if (dtMultiple != null && dtMultiple.Rows.Count > 0)
                {
                    SqlParameter SqlParameter = new SqlParameter();
                    SqlParameter.ParameterName = tableParam;
                    SqlParameter.Value = dtMultiple;
                    cmd.Parameters.Add(SqlParameter);
                    if (SqlParameterlist != null)
                    {
                        foreach (DictionaryEntry hparam in SqlParameterlist)
                        {
                            SqlParameter = new SqlParameter();
                            SqlParameter.ParameterName = hparam.Key.ToString();
                            SqlParameter.Value = hparam.Value;
                            cmd.Parameters.Add(SqlParameter);
                        }
                    }
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    cmd.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            return ds;
        }
        public int SQLBulkCopyData(DataTable source, string DestinationTableName)
        {
            SqlConnection sqlConnection = null;
            int result = -1;
            try
            {
                SqlBulkCopy sbc = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.FireTriggers);
                sbc.DestinationTableName = DestinationTableName;
                foreach (DataColumn dc in source.Columns)
                {
                    SqlBulkCopyColumnMapping mapColumn = new SqlBulkCopyColumnMapping(dc.ColumnName, dc.ColumnName);
                    sbc.ColumnMappings.Add(mapColumn);
                }
                sbc.WriteToServer(source);
                sbc.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return result;
        }

        public int SQLExecuteTransaction(string[] SpTextList, DataTable dtMultiple, Hashtable SqlParameterlist)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection.Open();
            SqlTransaction dbTransaction;
            int result = -1;
            int SpTextCount = 0;
            dbTransaction = cmd.Connection.BeginTransaction();
            cmd.Transaction = dbTransaction;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (SpTextCount = 0; SpTextCount < SpTextList.Length; SpTextCount++)
                {
                    cmd.CommandText = SpTextList[SpTextCount];
                    Hashtable val = (Hashtable)SqlParameterlist[SpTextCount];
                    cmd = GetCommandParameters(cmd, val);
                    result = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                if (dtMultiple != null && dtMultiple.Rows.Count > 0)
                {
                    SqlParameter SqlParameter = new SqlParameter();
                    SqlParameter.ParameterName = "@dtable";
                    SqlParameter.Value = dtMultiple;
                    cmd.Parameters.Add(SqlParameter);
                    result = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                dbTransaction.Commit();
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    dbTransaction.Rollback();
                }
                catch (Exception ex2)
                {
                    throw ex2;
                }
            }
            finally
            {
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            return result;
        }
        //Returns a single row of the selected data from database
        public DataRow GetDataRow(string querySelect)
        {
            try
            {
                //Using GetDataTable function of class DataAccess to select data
                DataTable dt = GetDataTable(querySelect);
                //Data is selected
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                //No data is selected
                else
                {
                    return null;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //Reutrns a single element from data
        public string GetValue(string querySelect)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = querySelect;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                object resultObj = cmd.ExecuteScalar();
                cmd.Transaction.Commit();
                return resultObj == null ? null : resultObj.ToString();
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                throw new Exception(ex.Message + "-->" + querySelect);
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Dispose();
            }
        }
        //Selects the data based on Query
        public DataTable GetDataTable(SqlCommand cmd)
        {
            try
            {
                DataTable dt = new DataTable();
                //Getting Selected database specific Adaptor from Factory class
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //Executes Query for Insert, Delete, Update etc
        public int SQLExecute(SqlCommand cmd)
        {
            try
            {
                int result = -1;
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public int SQLExecuteCmd(SqlCommand cmd)
        {
            try
            {
                int result = -1;
                cmd.Connection = sqlConnection;
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public int SQLExecuteQuery(string query)
        {
            try
            {
                int result = -1;
                SqlCommand cmd = new SqlCommand(query);
                cmd.Connection = sqlConnection;
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //Returns a single row of the selected data from database
        public DataRow GetDataRow(SqlCommand cmd)
        {
            try
            {
                //Using GetDataTable function of class DataAccess to select data
                DataTable dt = GetDataTable(cmd);
                //Data is selected
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                //No data is selected
                else
                {
                    return null;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //Reutrns a single element from data
        public string GetValue(SqlCommand cmd)
        {
            try
            {
                object resultObj = cmd.ExecuteScalar();
                return resultObj == null ? null : resultObj.ToString();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //Executes Query for Insert, Delete, Update etc
        public int SQLExecuteSpOutput(string SpText, Hashtable SqlParameterlist)
        {
            try
            {
                int result = -1;
                SqlCommand cmd = GetStoredProcCommond(SpText);
                cmd.Connection = sqlConnection;
                cmd = GetCommandParametersOutput(cmd, SqlParameterlist);
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                //int output;
                //Int32.TryParse(cmd.Parameters["@OutPutResult"].Value.ToString(), out output);
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                return result;
            }
            catch (Exception expl)
            {
                throw expl;
            }
        }
        //Executes Query for Insert, Delete, Update etc
        public int SQLExecuteSp(string SpText, Hashtable SqlParameterlist)
        {
            try
            {
                int result = -1;
                SqlCommand cmd = GetStoredProcCommond(SpText);
                cmd.Connection = sqlConnection;
                cmd = GetCommandParameters(cmd, SqlParameterlist);
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                return result;
            }
            catch (Exception expl)
            { throw expl; }
        }
        public int SQLExecuteSpTimeOut(string SpText, Hashtable SqlParameterlist)
        {
            try
            {
                int result = -1;
                SqlCommand cmd = GetStoredProcCommond(SpText);
                cmd.CommandTimeout = 0;
                cmd.Connection = sqlConnection;
                cmd = GetCommandParameters(cmd, SqlParameterlist);
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                return result;
            }
            catch (Exception expl)
            { throw expl; }
        }
        public void SQLExecuteSpReturn(string SpText, Hashtable HParameterlist, SqlParameter[] SqlParameterlist)
        {
            try
            {
                int result = -1;
                SqlCommand cmd = GetStoredProcCommond(SpText);
                cmd.Connection = sqlConnection;
                cmd = GetCommandParameters(cmd, HParameterlist);
                cmd = GetCommandSQLParameters(cmd, SqlParameterlist);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            catch (Exception expl)
            { throw expl; }
        }
        public int SQLExecuteSpReturn(string SpText, Hashtable SqlParameterlist, Hashtable SqlParameterlistReturn)
        {
            try
            {
                int result = -1;
                SqlCommand cmd = GetStoredProcCommond(SpText);
                cmd.Connection = sqlConnection;
                cmd = GetCommandParameters(cmd, SqlParameterlist);
                cmd = GetCommandParametersReturn(cmd, SqlParameterlistReturn);
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                return result;
            }
            catch (Exception expl)
            { throw expl; }
        }
        //Executes Query for Insert, Delete, Update etc
        public int SQLExecuteSpScalar(string SpText, Hashtable SqlParameterlist)
        {
            try
            {
                int result = -1;
                SqlCommand cmd = GetStoredProcCommond(SpText);
                cmd.Connection = sqlConnection;
                cmd = GetCommandParameters(cmd, SqlParameterlist);
                cmd.Connection.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                return result;
            }
            catch (Exception expl)
            { throw expl; }
        }
        public SqlCommand GetCommandParametersOutput(SqlCommand cmd, Hashtable SqlParameterlist)
        {
            try
            {
                if (SqlParameterlist != null)
                {
                    foreach (DictionaryEntry hparam in SqlParameterlist)
                    {
                        SqlParameter SqlParameter = new SqlParameter();
                        SqlParameter.ParameterName = hparam.Key.ToString();
                        SqlParameter.Value = hparam.Value;
                        cmd.Parameters.Add(SqlParameter);
                    }
                    SqlParameter outParm = new SqlParameter("@OutPutResult", SqlDbType.Int);
                    outParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParm);
                }
                return cmd;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public SqlCommand GetCommandParameters(SqlCommand cmd, Hashtable SqlParameterlist)
        {
            try
            {
                if (SqlParameterlist != null)
                {
                    foreach (DictionaryEntry hparam in SqlParameterlist)
                    {
                        SqlParameter SqlParameter = new SqlParameter();
                        SqlParameter.ParameterName = hparam.Key.ToString();
                        SqlParameter.Value = hparam.Value;
                        cmd.Parameters.Add(SqlParameter);
                    }
                }
                return cmd;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public SqlParameter GetSqlParameterOut(string hparam, DbType dbType, int size)
        {
            try
            {
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = hparam;
                sqlParameter.Direction = ParameterDirection.Output;
                sqlParameter.DbType = dbType;
                sqlParameter.Size = size;
                return sqlParameter;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        private SqlCommand GetCommandSQLParameters(SqlCommand cmd, SqlParameter[] SqlParameterlist)
        {
            try
            {
                if (SqlParameterlist != null)
                {
                    foreach (SqlParameter hparam in SqlParameterlist)
                    {
                        cmd.Parameters.Add(hparam);
                    }
                }
                return cmd;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public SqlCommand GetCommandParametersReturn(SqlCommand cmd, Hashtable SqlParameterlist)
        {
            try
            {
                if (SqlParameterlist != null)
                {
                    foreach (DictionaryEntry hparam in SqlParameterlist)
                    {
                        SqlParameter SqlParameter = new SqlParameter();
                        SqlParameter.ParameterName = hparam.Key.ToString();
                        SqlParameter.Direction = ParameterDirection.Output;
                        SqlParameter.DbType = DbType.Int32;
                        cmd.Parameters.Add(SqlParameter);
                    }
                }
                return cmd;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataTable GetDataTableSP(string SpText, Hashtable SqlParameterlist)
        {
            try
            {
                SqlCommand cmd = GetStoredProcCommond(SpText);
                cmd.Connection = sqlConnection;
                cmd.CommandTimeout = 0;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                if (SqlParameterlist != null)
                {
                    foreach (DictionaryEntry hparam in SqlParameterlist)
                    {
                        SqlParameter SqlParameter = new SqlParameter();
                        SqlParameter.ParameterName = hparam.Key.ToString();
                        SqlParameter.Value = hparam.Value;
                        cmd.Parameters.Add(SqlParameter);
                    }
                }
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DataSet GetDataSetSP(string SpText, Hashtable SqlParameterlist)
        {
            try
            {
                SqlCommand cmd = GetStoredProcCommond(SpText);
                cmd.Connection = sqlConnection;
                cmd.CommandTimeout = 3600;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                foreach (DictionaryEntry hparam in SqlParameterlist)
                {
                    SqlParameter SqlParameter = new SqlParameter();
                    SqlParameter.ParameterName = hparam.Key.ToString();
                    SqlParameter.Value = hparam.Value;
                    cmd.Parameters.Add(SqlParameter);
                }
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}

