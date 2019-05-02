using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_ViewHistory : System.Web.UI.Page
{
   SqlConnection conn =
            new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ToString());
   protected void Page_Load(object sender, EventArgs e)
   {
       if(!IsPostBack) gvbind();

   }
   protected void gvbind()
   {
      //            SqlCommand cmd = new SqlCommand("Select * from [dbo].Categories", conn);
      SqlCommand sqlCommand = new SqlCommand();

      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "sp_ViewHistory";
      sqlCommand.Connection = conn;
      sqlCommand.Connection.Open();

      //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);
      sqlCommand.Parameters.AddWithValue("@email", User.Identity.Name.ToString());
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();

      SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
      DataSet ds = new DataSet();
      da.Fill(ds);
      if (ds.Tables[0].Rows.Count > 0)
      {
         GridView1.DataSource = ds;
         GridView1.DataBind();
      }
   }

   protected void cancel_Click(object sender, EventArgs e)
   {
      SqlCommand sqlCommand = new SqlCommand();

      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "sp_ViewHistory";
      sqlCommand.Connection = conn;
      sqlCommand.Connection.Open();
      //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);
      sqlCommand.Parameters.AddWithValue("@email", User.Identity.Name);
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();

      SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
      DataSet ds = new DataSet();
      da.Fill(ds);
      if (ds.Tables[0].Rows.Count > 0)
      {
         GridView1.DataSource = ds;
         GridView1.DataBind();
      }
   }
}