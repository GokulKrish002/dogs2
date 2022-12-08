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
    }
}