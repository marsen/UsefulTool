using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demo_Security_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region　DES 
        tbDESKey.Text = Security.DES.StrKey;
        tbDESIV.Text = Security.DES.StrIV;
        #endregion

    }
    protected void btnDESenCrypt_Click(object sender, EventArgs e)
    {
        var inputString = tbDESInput.Text;
        tbDESenCrypt.Text = Security.DES.enCrypt(inputString);
    }
    protected void btnDESdeCrypt_Click(object sender, EventArgs e)
    {
        var inputString = tbDESenCrypt.Text;
        tbDESdeCrypt.Text = Security.DES.deCrypt(inputString);
    }
}