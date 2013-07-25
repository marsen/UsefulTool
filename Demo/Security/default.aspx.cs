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

        tbAESKey.Text = Security.AES.StrKey;
        tbAESIV.Text = Security.AES.StrIV;
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
    protected void btnMD5enCrypt_Click(object sender, EventArgs e)
    {
        var inputString = tbMD5Input.Text;
        tbMD5enCrypt.Text = Security.MD5.enCrypt(inputString);
    }
    protected void btnAESenCrypt_Click(object sender, EventArgs e)
    {
        var inputString = tbAESInput.Text;
        tbAESenCrypt.Text = Security.AES.enCrypt(inputString);
    }
    protected void btnAESdeCrypt_Click(object sender, EventArgs e)
    {
        var inputString = tbAESenCrypt.Text;
        tbAESdeCrypt.Text = Security.AES.deCrypt(inputString);
    }
}