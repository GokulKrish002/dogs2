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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=GOKULSVICTUS\SQLEXPRESS;Initial Catalog=kaashiv;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("User_Tbl_Search", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mail", TextBox1.Text);
            cmd.Parameters.AddWithValue("@pwd", TextBox2.Text);
            SqlDataReader readed;
            readed = cmd.ExecuteReader();
            if (readed.Read())
            {
                TextBox1.Text = readed["name"].ToString();
                Response.Redirect("index.aspx");
            }
            else
            {
                TextBox1.Text = "Yaru da ne ";
            }
            con.Close();
        }
    }
}

/*SqlCommand cmd = new SqlCommand("select * from saravanan where email=@email and password=@password", con);
            cmd.Parameters.AddWithValue("@email", TextBox1.Text);
            cmd.Parameters.AddWithValue("@password", TextBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "saravanan");
            if (ds.Tables["saravanan"].Rows.Count == 0) { 
            Response.Write("Invalid user");
                TextBox1.Text = "Invalid user";
            }
            else{
                Response.Redirect("index.aspx");
            }*/