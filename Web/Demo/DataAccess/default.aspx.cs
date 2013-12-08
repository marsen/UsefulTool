using System;

using System.Data.SQLite;
using Util.Data;

public partial class Demo_DataAccess_default : System.Web.UI.Page
{
    //如果無法連接，請檢查DemoDataBase.mdf是否被其它程序鎖住，通常是sqlserver.exe;可以用unlocker來解鎖。
    //protected string cnString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\user1\Documents\GitHub\UsefulTool\Web\App_Data\DemoDataBase.mdf;Database=DemoDataBase2;Integrated Security=True;User Instance=True";
    //SQLite Connection String
    protected string cnString =
        @"Data Source=C:\Users\Marsen\Documents\GitHub\UsefulTool\Web\App_Data\northwindEF.db;Version=3;";

    protected void Page_Load(object sender, EventArgs e)
    {
        cnString = String.Format(@"Data Source={0}\App_Data\northwindEF.db;Version=3;", Server.MapPath("~"));
        //var sqlite_conn =
        //    new SQLiteConnection(
        //        @"Data Source=C:\Users\user1\Documents\GitHub\UsefulTool\Web\App_Data\northwindEF.db;Version=3;");
        if (!IsPostBack)
        {
            /*
            DataTable result = new DataTable();

            try
            {
                sqlite_conn.Open();
                var cm = new SQLiteCommand("select * from Employees", sqlite_conn);
                result.Load(cm.ExecuteReader());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlite_conn != null && sqlite_conn.State != ConnectionState.Closed)
                {
                    sqlite_conn.Close();
                }
            }*/
            //gvDataTableForSQL.DataSource = result;
            //gvDataTableForSQL.DataBind();  
            
            gvDataTableForSQL.DataSource = SQLiteDataAccess.GetDataTableForSQL(cnString, "select * from Employees");
            gvDataTableForSQL.DataBind(); 
            ddlTitle.DataValueField = "Title";
            ddlTitle.DataTextField = "Title";
            ddlTitle.DataSource = SQLiteDataAccess.GetDataTableForSQL(cnString, @"SELECT DISTINCT Title  FROM Employees");
            ddlTitle.DataBind();
             
        }
    }


    protected void btnSingleValueForSQL_Click(object sender, EventArgs e)
    {
        string Name = this.tbName.Text;
        string sqlString = @"select Title from Employees where LastName like @Name or FirstName like @Name";
        SQLiteParameter parameter = new SQLiteParameter("@Name",Name) ;
        this.Label1.Text = SQLiteDataAccess.GetSingleValueForSQL(cnString, sqlString, parameter);
    }
    protected void btnDataTableForSQL_Click(object sender, EventArgs e)
    {
        string Title = this.ddlTitle.SelectedValue;
        string sqlString = @"select  FirstName, LastName , Title from Employees where Title = @Title";
        SQLiteParameter parameter = new SQLiteParameter("@Title", Title);
        this.gvResult.DataSource = SQLiteDataAccess.GetDataTableForSQL(cnString, sqlString, parameter);
        this.gvResult.DataBind();
    }
}