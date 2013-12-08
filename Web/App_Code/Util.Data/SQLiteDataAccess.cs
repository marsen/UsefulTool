using System;
using System.Data;
using System.Data.SQLite;

namespace Util.Data
{
    /// <summary>
    /// DataAccess 的摘要描述 TODO
    /// </summary>
    public class SQLiteDataAccess
    {
       

        #region DB Data Access

        /// <summary>
        /// GetSingleValueForSQL
        /// </summary>
        /// <param name="cnString">連線字串</param>
        /// <param name="sqlString">SQL語法</param>
        /// <returns>查詢結果</returns>
        public static string GetSingleValueForSQL(string cnString, string sqlString)
        {
            SQLiteConnection conn = null;
            string result = "";

            try
            {
                conn = new SQLiteConnection(cnString);
                conn.Open();

                var cm = new SQLiteCommand(sqlString, conn);
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

        /// <summary>
        /// GetSingleValueForSQL
        /// </summary>
        /// <param name="cnString">連線字串</param>
        /// <param name="sqlString">SQL語法</param>
        /// <param name="parameter">查詢參數</param>
        /// <returns>查詢結果</returns>
        public static string GetSingleValueForSQL(string cnString, string sqlString, SQLiteParameter parameter)
        {
            var conn = new SQLiteConnection(cnString);
            string result = "";

            try
            {
                conn.Open();
                var cm = new SQLiteCommand(sqlString, conn);
                cm.Connection = conn;
                cm.CommandText = sqlString;
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

        /// <summary>
        /// GetSingleValueForSQL
        /// </summary>
        /// <param name="cnString">連線字串</param>
        /// <param name="sqlString">SQL語法</param>
        /// <param name="_params">查詢參數陣列</param>
        /// <returns>查詢結果</returns>
        public static string GetSingleValueForSQL(string cnString, string sqlString, SQLiteParameter[] _params)
        {
            SQLiteConnection conn = null;
            string result = "";

            try
            {
                conn = new SQLiteConnection(cnString);
                conn.Open();

                var cm = new SQLiteCommand(sqlString, conn);
                cm.Parameters.Clear();
                foreach (SQLiteParameter param in _params)
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

        /// <summary>
        /// ExecuteSQLForSQL
        /// </summary>
        /// <param name="cnString">連線字串</param>
        /// <param name="sqlString">SQL語法</param>
        /// <returns>執行是否成功?</returns>
        public static bool ExecuteSQLForSQL(string cnString, string sqlString)
        {
            SQLiteConnection conn = null;
            bool result = false;

            try
            {
                conn = new SQLiteConnection(cnString);
                conn.Open();

                var cm = new SQLiteCommand(sqlString, conn);
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

        /// <summary>
        /// ExecuteSQLForSQL
        /// </summary>
        /// <param name="cnString">連線字串</param>
        /// <param name="sqlString">SQL語法</param>
        /// <param name="parameter">查詢參數</param>
        /// <returns>執行是否成功?</returns>
        public static bool ExecuteSQLForSQL(string cnString, string sqlString, SQLiteParameter parameter)
        {
            SQLiteConnection conn = null;
            bool result = false;

            try
            {
                conn = new SQLiteConnection(cnString);
                conn.Open();

                var cm = new SQLiteCommand(sqlString, conn);
                cm.Parameters.Clear();
                cm.Parameters.Add(parameter);
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

        /// <summary>
        /// ExecuteSQLForSQL
        /// </summary>
        /// <param name="cnString">連線字串</param>
        /// <param name="sqlString">SQL語法</param>
        /// <param name="_params">參數陣列</param>
        /// <returns>執行是否成功?</returns>
        public static bool ExecuteSQLForSQL(string cnString, string sqlString, SQLiteParameter[] _params)
        {
            SQLiteConnection conn = null;
            bool result = false;

            try
            {
                conn = new SQLiteConnection(cnString);
                conn.Open();

                var cm = new SQLiteCommand(sqlString, conn);
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

        /// <summary>
        /// GetDataTableForSQL
        /// </summary>
        /// <param name="cnString">連線字串</param>
        /// <param name="sqlString">SQL語法</param>
        /// <returns>查詢結果</returns>
        public static System.Data.DataTable GetDataTableForSQL(string cnString, string sqlString)
        {
            return GetDataTableForSQL(cnString, sqlString, "Table");
        }

        /// <summary>
        /// GetDataTableForSQL
        /// </summary>
        /// <param name="cnString">連線字串</param>
        /// <param name="sqlString">SQL語法</param>
        /// <param name="tableName">table Name</param>
        /// <returns>查詢結果</returns>
        public static System.Data.DataTable GetDataTableForSQL(string cnString, string sqlString, string tableName)
        {
            SQLiteConnection conn = null;
            DataTable result = new DataTable();

            try
            {
                conn = new SQLiteConnection(cnString);
                conn.Open();
                var cm = new SQLiteCommand(sqlString, conn);
                cm.Connection = conn;
                cm.CommandText = sqlString;
                result.Load(cm.ExecuteReader());
            }
            catch (Exception ex)
            {
                throw ex;
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

        /// <summary>
        /// GetDataTableForSQL
        /// </summary>
        /// <param name="cnString">連線字串</param>
        /// <param name="sqlString">SQL語法</param>
        /// <param name="_params">查詢參數陣列</param>
        /// <returns>查詢結果</returns>
        public static System.Data.DataTable GetDataTableForSQL(string cnString, string sqlString, SQLiteParameter[] _params)
        {
            SQLiteConnection conn = null;
            DataTable result = new DataTable();

            try
            {
                conn = new SQLiteConnection(cnString);
                conn.Open();

                var cm = new SQLiteCommand(sqlString, conn);
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

        /// <summary>
        /// GetDataTableForSQL
        /// </summary>
        /// <param name="cnString">連線字串</param>
        /// <param name="sqlString">SQL語法</param>
        /// <param name="parameter">查詢參數</param>
        /// <returns>查詢結果</returns>
        public static System.Data.DataTable GetDataTableForSQL(string cnString, string sqlString, SQLiteParameter parameter)
        {
            SQLiteConnection conn = null;
            DataTable result = new DataTable();

            try
            {
                conn = new SQLiteConnection(cnString);
                conn.Open();

                var cm = new SQLiteCommand(cnString, conn);
                cm.Connection = conn;
                cm.CommandText = sqlString;
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

        #endregion
    }
}