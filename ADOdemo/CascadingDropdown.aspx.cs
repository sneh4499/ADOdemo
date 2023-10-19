using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOdemo
{
    public partial class CascadingDropdown : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ADOtableConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Cities where State like '"+DropDownList1.SelectedItem.Text+"'", con);
            da.Fill(ds);
            DropDownList2.DataSource = ds;
            DropDownList2.DataValueField = "City";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Please Select", "0"));
        }
    }
}