using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// DataAccess 的摘要描述
/// </summary>
public class DataAccess
{
    public DataAccess()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    #region DB Data Access

    public static string GetSingleValueForSQL(string cnString, string sqlString)
    {
        SqlConnection conn = null;
        string result = "";

        try
        {
            conn = new SqlConnection(cnString);
            conn.Open();

            var cm = new SqlCommand(sqlString, conn);
            cm.CommandTimeout = 180;

            result = cm.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            //TODO: catch exception
        }
        finally
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        return result;
    }

    public static string GetSingleValueForSQL(string cnString, string sqlString, SqlParameter[] _params)
    {
        SqlConnection conn = null;
        string result = "";

        try
        {
            conn = new SqlConnection(cnString);
            conn.Open();

            var cm = new SqlCommand(sqlString, conn);
            cm.Parameters.Clear();
            foreach (SqlParameter param in _params)
            {
                cm.Parameters.Add(param);
            }

            cm.CommandTimeout = 180;
            result = cm.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            //TODO: catch exception
        }
        finally
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        return result;
    }

    public static string GetSingleValueForSQL(string cnString, string sqlString, SqlParameter parameter)
    {
        SqlConnection conn = null;
        string result = "";

        try
        {
            conn = new SqlConnection(cnString);
            conn.Open();

            var cm = new SqlCommand(sqlString, conn);
            cm.Parameters.Clear();
            cm.Parameters.Add(parameter);
            cm.CommandTimeout = 180;
            result = cm.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            //TODO: catch exception
        }
        finally
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        return result;
    }

    public static bool ExecuteSQLForSQL(string cnString, string sqlString)
    {
        SqlConnection conn = null;
        bool result = false;

        try
        {
            conn = new SqlConnection(cnString);
            conn.Open();

            var cm = new SqlCommand(sqlString, conn);
            cm.CommandTimeout = 180;
            cm.ExecuteNonQuery();
            result = true;
        }
        catch (Exception ex)
        {
            //TODO: catch exception
        }
        finally
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        return result;
    }

    public static bool ExecuteSQLForSQL(string cnString, string sqlString, SqlParameter[] _params)
    {
        SqlConnection conn = null;
        bool result = false;

        try
        {
            conn = new SqlConnection(cnString);
            conn.Open();

            var cm = new SqlCommand(sqlString, conn);
            cm.Parameters.Clear();
            foreach (var param in _params)
            {
                cm.Parameters.Add(param);
            }
            cm.CommandTimeout = 180;
            cm.ExecuteNonQuery();
            result = true;
        }
        catch (Exception ex)
        {
            //TODO: catch exception
        }
        finally
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        return result;
    }

    public static System.Data.DataTable GetDataTableForSQL(string cnString, string sqlString, SqlParameter[] _params)
    {
        SqlConnection conn = null;
        DataTable result = new DataTable();

        try
        {
            conn = new SqlConnection(cnString);
            conn.Open();

            var cm = new SqlCommand(sqlString, conn);
            foreach (var param in _params)
            {
                cm.Parameters.Add(param);
            }
            result.Load(cm.ExecuteReader());
        }
        catch (Exception ex)
        {
            //TODO: catch exception
        }
        finally
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        return result;
    }

    public static System.Data.DataTable GetDataTableForSQL(string cnString, string sqlString, SqlParameter parameter)
    {
        SqlConnection conn = null;
        DataTable result = new DataTable();

        try
        {
            conn = new SqlConnection(cnString);
            conn.Open();

            var cm = new SqlCommand(sqlString, conn);
            cm.Parameters.Add(parameter);
            result.Load(cm.ExecuteReader());
        }
        catch (Exception ex)
        {
            //TODO: catch exception
        }
        finally
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        return result;
    }

    public static System.Data.DataTable GetDataTableForSQL(string cnString, string sqlString, string tableName)
    {
        SqlConnection conn = null;
        DataTable result = new DataTable();

        try
        {
            conn = new SqlConnection(cnString);
            conn.Open();

            var cm = new SqlCommand(sqlString, conn);
            result.Load(cm.ExecuteReader());
        }
        catch (Exception ex)
        {
            //TODO: catch exception
        }
        finally
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        return result;
    }

    public static System.Data.DataTable GetDataTableForSQL(string cnString, string sqlString)
    {
        return GetDataTableForSQL(cnString, sqlString, "Table");
    }
    #endregion
}