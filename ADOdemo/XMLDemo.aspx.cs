using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOdemo
{
    public partial class XMLDeml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoadXML_Click(object sender, EventArgs e)
        {
            lblDept.Visible = true;
            lblEmp.Visible = true;

            DataSet ds = new DataSet();

            ds.ReadXml(@"C:\Users\Snehal\source\Marlabs\ADOdemo\ADOdemo\file.xml");

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

            GridView2.DataSource = ds.Tables[1];
            GridView2.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            ds.ReadXml(@"C:\Users\Snehal\source\Marlabs\ADOdemo\ADOdemo\file.xml");


            string cs = ConfigurationManager.ConnectionStrings["ADOtableConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            DataTable dtDept = ds.Tables["Department"];
            DataTable dtEmp = ds.Tables["Employee"];
            con.Open();
            using (SqlBulkCopy sqlbc = new SqlBulkCopy(con))
            {
                sqlbc.DestinationTableName = "Departments";
                sqlbc.ColumnMappings.Add("Name", "Name");
                sqlbc.ColumnMappings.Add("Location", "Location");
                sqlbc.WriteToServer(dtDept);
                Response.Write("Bulk data stored successfully");
            }

            using (SqlBulkCopy sqlbc = new SqlBulkCopy(con))
            {
                sqlbc.DestinationTableName = "Employees";
                sqlbc.ColumnMappings.Add("Name", "Name");
                sqlbc.ColumnMappings.Add("Gender", "Gender");
                sqlbc.ColumnMappings.Add("DepartmentId", "DepartmentId");
                sqlbc.WriteToServer(dtEmp);
                Response.Write("Bulk data stored successfully2");
            }

        }
    }
}