using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UsefulToolAP
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            var dt = new GetDirDataTable(@"C:\CMProj\WEB\web_0.2\app").OutputTable;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
 }
    /// <summary>
    /// 用遞迴存取指定目錄下所有檔案結構，並輸出成datatable
    /// </summary>
    public class GetDirDataTable
    {
        public DataTable OutputTable = new DataTable();


        public GetDirDataTable(string root)
        {
            OutputTable = GetTable();
            //var root = @"C:\CMProj\WEB\web_0.2\app";
            GetAllFile(root);
        }



        static DataTable GetTable()
        {
            //
            // Here we create a DataTable with four columns.
            //
            DataTable table = new DataTable();
            table.Columns.Add("ParentFolder", typeof(string));
            table.Columns.Add("FileName", typeof(string));
            table.Columns.Add("Command", typeof(string));
            return table;
        }

        private void GetAllFile(string filepath)
        {
            foreach (string path in System.IO.Directory.GetFileSystemEntries(filepath))
            {
                FileAttributes attr = File.GetAttributes(path);

                //detect whether its a directory or file
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    //Console.WriteLine(String.Format("{0} Its a directory", path));
                    GetAllFile(path);
                }
                else
                {
                    //Console.WriteLine(String.Format("{0} Its a file", path));
                    OutputTable.Rows.Add(new FileInfo(filepath).Name, new FileInfo(path).Name, path);
                }
            }
        }
   
    }   
}
