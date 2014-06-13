using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BulkInsert
/// </summary>
public class BulkInsert
{
    /// <summary>
    /// BulkCopy 會清掉已存在的資料
    /// AllRatioStatistics 資料表必須與資料庫的欄位一致
    /// </summary>
    /// <param name="conn">資料庫連線SqlConnection</param>
    /// <param name="tableName">要寫入的table name</param>
    /// <param name="srcTable">要寫入的data</param>
    /// <param name="errorMessage">錯誤訊息</param>
    public static void Insert(
        SqlConnection conn,
        string tableName,
        DataTable srcTable,
        out string errorMessage)
    {
        //擲回初始
        errorMessage = string.Empty;

        try
        {
            //設定整批寫入的datatable
            using (SqlBulkCopy sqlBC = new SqlBulkCopy(conn))//宣告SqlBulkCopy
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                conn.Open();

                //設定一個批次量寫入多少筆資料 
                //sqlBC.BatchSize = 1000;

                //設定逾時的秒數          
                sqlBC.BulkCopyTimeout = 60;

                //設定 NotifyAfter 屬性，以便在每複製 10000 個資料列至資料表後，呼叫事件處理常式。     
                //sqlBC.NotifyAfter = 10000;
                //sqlBC.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);

                //設定要寫入的資料表    
                sqlBC.DestinationTableName = tableName;

                //對應資料行
                foreach (DataColumn item in srcTable.Columns)
                {
                    sqlBC.ColumnMappings.Add(item.ColumnName, item.ColumnName);
                }

                //整批寫入           
                sqlBC.WriteToServer(srcTable);
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }
    }

    /// <summary>
    /// BulkCopy 會清掉已存在的資料
    /// AllRatioStatistics 資料表必須與資料庫的欄位一致
    /// </summary>
    /// <param name="bulkCopyDbConnection">資料庫連線字串</param>
    /// <param name="tableName">要寫入的table name</param>
    /// <param name="srcTable">要寫入的data</param>
    /// <param name="errorMessage">錯誤訊息</param>
    public static void Insert(
        string bulkCopyDbConnection,
        string tableName,
        DataTable srcTable,
        out string errorMessage)
    {
        //擲回初始
        errorMessage = string.Empty;

        try
        {
            //設定整批寫入的datatable
            using (SqlConnection conn = new SqlConnection(bulkCopyDbConnection))//宣告連結字串 
            using (SqlBulkCopy sqlBC = new SqlBulkCopy(conn))//宣告SqlBulkCopy
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                conn.Open();

                //設定一個批次量寫入多少筆資料 
                //sqlBC.BatchSize = 1000;

                //設定逾時的秒數          
                sqlBC.BulkCopyTimeout = 60;

                //設定 NotifyAfter 屬性，以便在每複製 10000 個資料列至資料表後，呼叫事件處理常式。     
                //sqlBC.NotifyAfter = 10000;
                //sqlBC.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);

                //設定要寫入的資料表    
                sqlBC.DestinationTableName = tableName;

                //對應資料行
                foreach (DataColumn item in srcTable.Columns)
                {
                    sqlBC.ColumnMappings.Add(item.ColumnName, item.ColumnName);
                }

                //整批寫入           
                sqlBC.WriteToServer(srcTable);
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }
    }
}