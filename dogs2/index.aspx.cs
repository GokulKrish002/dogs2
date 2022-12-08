using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace dogs2
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void RefreshTbl()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=GOKULSVICTUS\SQLEXPRESS;Initial Catalog=kaashiv;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("select * from User_tbl", connection);
                SqlDataAdapter d = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                d.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Response.Write(ex);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RefreshTbl();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=GOKULSVICTUS\SQLEXPRESS;Initial Catalog=kaashiv;Integrated Security=True");
            con.Open();
            using (SqlCommand cmd = new SqlCommand("User_Tbl_Insert", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@name", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = TextBox1.Text;
                SqlParameter param2 = new SqlParameter("@Email", SqlDbType.VarChar);
                cmd.Parameters.Add(param2).Value = TextBox2.Text;
                SqlParameter param3 = new SqlParameter("@age", SqlDbType.Int);
                cmd.Parameters.Add(param3).Value = TextBox3.Text;
                SqlParameter param4 = new SqlParameter("@password", SqlDbType.VarChar);
                cmd.Parameters.Add(param4).Value = TextBox4.Text;

                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    TextBox1.Text = "Success..!";
                    TextBox2.Text = "Success..!";
                    TextBox3.Text = "Success..!";
                    TextBox4.Text = "Success..!";
                }
                else
                {
                    TextBox1.Text = "Failure..!";
                    TextBox2.Text = "Failure..!";
                    TextBox3.Text = "Failure..!";
                    TextBox4.Text = "Failure..!";
                }

                RefreshTbl();
            }
        }
    }
}