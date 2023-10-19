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
    public partial class CommandBuilderDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["ADOtableConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Students", con);

                SqlCommandBuilder builde = new SqlCommandBuilder(da);

                DataSet ds = new DataSet();
                da.Fill(ds);

                DataRow dr = ds.Tables[0].NewRow();

                dr["Name"] = txtStudentName.Text;
                dr["Gender"] = txtGender.Text;
                dr["TotalMarks"] = txtMarks.Text;
                ds.Tables[0].Rows.Add(dr);

                int rowsupdated = da.Update(ds);
                if (rowsupdated > 0)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Student record with student Id - " + txtStudentId.Text + " has been Inserted..";

                    txtStudentId.Text = "";
                    txtStudentName.Text = "";
                    txtGender.Text = "";
                    txtMarks.Text = "";

                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Student record with student Id - " + txtStudentId.Text + " not Inserted..";

                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                }
            }
            catch
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Something went wrong.. Please try again..";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["ADOtableConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQL_QUERY"], con);

                SqlCommandBuilder builde = new SqlCommandBuilder(da);

                DataSet ds = (DataSet)ViewState["DATASET"];
                DataRow dr = ds.Tables["Students"].Rows[0];

                dr["Name"] = txtStudentName.Text;
                dr["Gender"] = txtGender.Text;
                dr["TotalMarks"] = txtMarks.Text;

                int rowsupdated = da.Update(ds, "Students");
                if(rowsupdated > 0)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Student record with student Id - " + txtStudentId.Text + " has been Updated..";

                    txtStudentId.Text = "";
                    txtStudentName.Text = "";
                    txtGender.Text = "";
                    txtMarks.Text = "";

                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Student record with student Id - "+txtStudentId.Text+" not Updated..";

                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                }
            }
            catch
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Something went wrong.. Please try again..";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["ADOtableConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQL_QUERY"], con);

                SqlCommandBuilder builde = new SqlCommandBuilder(da);

                DataSet ds = (DataSet)ViewState["DATASET"];
                DataRow dr = ds.Tables["Students"].Rows[0];

                dr.Delete();

                int rowsupdated = da.Update(ds, "Students");
                if (rowsupdated > 0)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Student record with student Id - " + txtStudentId.Text + " has been Deleted..";

                    txtStudentId.Text = "";
                    txtStudentName.Text = "";
                    txtGender.Text = "";
                    txtMarks.Text = "";

                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Student record with student Id - " + txtStudentId.Text + " not Deleted..";

                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                }
            }
            catch
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Something went wrong.. Please try again..";
            }
        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["ADOtableConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            string query = "select * from Students where Id=" + txtStudentId.Text;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Students");

                ViewState["SQL_QUERY"] = query;
                ViewState["DATASET"] = ds;

                if (ds.Tables["Students"].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["Students"].Rows[0];
                    txtStudentName.Text = dr["Name"].ToString();
                    txtGender.Text = dr["Gender"].ToString();
                    txtMarks.Text = dr["TotalMarks"].ToString();

                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Student's record with Id - " + txtStudentId.Text + " Loaded..";

                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "No Student's record found with Id - " + txtStudentId.Text;
                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                }
            }
            catch
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Something went wrong.. Please try again..";
            }
            
        }
    }
}