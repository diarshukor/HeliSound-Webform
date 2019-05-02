using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shipping_OrderShipping : System.Web.UI.Page
{
   SqlConnection conn =
           new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ToString());
   protected void Page_Load(object sender, EventArgs e)
   {
               gvbind();
         shipped_bind();
      

   }
   protected void gvbind()
   {
      //            SqlCommand cmd = new SqlCommand("Select * from [dbo].Categories", conn);
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;

      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "sp_ViewOrderShipping";
      //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);
      sqlCommand.Connection.Open();
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();

      SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
      DataSet ds = new DataSet();
      da.Fill(ds);
      try
      {
         GridView1.DataSource = ds;
         GridView1.DataBind();

      }
      catch(Exception a)
      {

      }
      finally { }

   }
   protected void shipped_bind()
   {
      //            SqlCommand cmd = new SqlCommand("Select * from [dbo].Categories", conn);
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;
      sqlCommand.Connection.Open();

      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "sp_ViewOrderShipped";
      //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);

      sqlCommand.ExecuteNonQuery();

      sqlCommand.Connection.Close();

      SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
      DataSet ds = new DataSet();
      da.Fill(ds);
      conn.Close();
      try
      {
         GridView2.DataSource = ds;
         GridView2.DataBind();
      }
      catch(Exception a)
      {

      }
      finally
      {

      }
         
      }
   

   protected void Ship_Click(object sender, EventArgs e)
   {
      foreach (GridViewRow s in GridView1.Rows)
      {
            //            SqlCommand cmd = new SqlCommand("Select * from [dbo].Categories", conn);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.Connection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@invoicenumber", int.Parse(s.Cells[2].Text));
            sqlCommand.CommandText = "sp_ShipIt";
            //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);

            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
         
      }

   }



}