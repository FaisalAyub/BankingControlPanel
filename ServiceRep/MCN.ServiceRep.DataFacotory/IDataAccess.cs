using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OnlineApp.ServiceRep.DataFacotory
{
    public interface IDataAccess
    {
        void SetConfig(string _ConnectionStringsI = "");
        void SetSqlConnection();
        string GetConnectionString();
        DataTable GetDataTable(string querySelect);
        int SQLExecute(string query);
        DataTable SQLExecuteTable(string SpText, string tableParam, DataTable dtMultiple, Hashtable SqlParameterlist);
        DataSet SQLExecuteTablesByDataSet(string SpText, string[] tableParam, DataSet dtMultiple, Hashtable SqlParameterlist);
        DataSet SQLExecuteTables(string SpText, string tableParam, DataTable dtMultiple, Hashtable SqlParameterlist);
        int SQLBulkCopyData(DataTable source, string DestinationTableName);
        int SQLExecuteTransaction(string[] SpTextList, DataTable dtMultiple, Hashtable SqlParameterlist);
        DataRow GetDataRow(string querySelect);
        string GetValue(string querySelect);
        DataTable GetDataTable(SqlCommand cmd);
        //Executes Query for Insert, Delete, Update etc
        int SQLExecute(SqlCommand cmd);
        int SQLExecuteCmd(SqlCommand cmd);
        int SQLExecuteQuery(string query);
        //Returns a single row of the selected data from database
        DataRow GetDataRow(SqlCommand cmd);
        //Reutrns a single element from data
        string GetValue(SqlCommand cmd);
        //Executes Query for Insert, Delete, Update etc
        int SQLExecuteSpOutput(string SpText, Hashtable SqlParameterlist);
        //Executes Query for Insert, Delete, Update etc
        int SQLExecuteSp(string SpText, Hashtable SqlParameterlist);
        int SQLExecuteSpTimeOut(string SpText, Hashtable SqlParameterlist);
        void SQLExecuteSpReturn(string SpText, Hashtable HParameterlist, SqlParameter[] SqlParameterlist);
        SqlParameter GetSqlParameterOut(string hparam, DbType dbType, int size);
        //Executes Query for Insert, Delete, Update etc
        int SQLExecuteSpScalar(string SpText, Hashtable SqlParameterlist);
        SqlCommand GetCommandParametersOutput(SqlCommand cmd, Hashtable SqlParameterlist);
        SqlCommand GetCommandParameters(SqlCommand cmd, Hashtable SqlParameterlist);
        SqlCommand GetCommandParametersReturn(SqlCommand cmd, Hashtable SqlParameterlist);
        DataTable GetDataTableSP(string SpText, Hashtable SqlParameterlist);
        DataSet GetDataSetSP(string SpText, Hashtable SqlParameterlist);
    }
}
