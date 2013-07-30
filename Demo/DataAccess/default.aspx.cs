using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Demo_DataAccess_default : System.Web.UI.Page
{
    protected string cnString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\DemoDataBase.mdf;Database=DemoDataBase;Integrated Security=True;User Instance=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvDataTableForSQL.DataSource = DataAccess.GetDataTableForSQL(cnString, "select * from Employees");
            gvDataTableForSQL.DataBind();
            ddlTitle.DataValueField = "Title";
            ddlTitle.DataTextField = "Title";
            ddlTitle.DataSource = DataAccess.GetDataTableForSQL(cnString, @"SELECT DISTINCT Title  FROM Employees");
            ddlTitle.DataBind();
        }
    }
    protected void btnSingleValueForSQL_Click(object sender, EventArgs e)
    {
        string Name = this.tbName.Text;
        string sqlString = @"select Title from Employees where LastName like @Name or FirstName like @Name";
        SqlParameter parameter = new SqlParameter("@Name",Name) ;
        this.Label1.Text = DataAccess.GetSingleValueForSQL(cnString, sqlString, parameter);
    }
    protected void btnDataTableForSQL_Click(object sender, EventArgs e)
    {
        string Title = this.ddlTitle.SelectedValue;
        string sqlString = @"select  FirstName, LastName , Title from Employees where Title = @Title";
        SqlParameter parameter = new SqlParameter("@Title", Title);
        this.gvResult.DataSource = DataAccess.GetDataTableForSQL(cnString, sqlString, parameter);
        this.gvResult.DataBind();
    }
}