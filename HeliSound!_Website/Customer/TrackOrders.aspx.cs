using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_TrackOrders : System.Web.UI.Page
{
   SqlConnection conn =
       new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ToString());
   protected void Page_Load(object sender, EventArgs e)
   {
      if (!IsPostBack) gvbind();

   }
   protected void gvbind()
   {
      //            SqlCommand cmd = new SqlCommand("Select * from [dbo].Categories", conn);
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;

      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "sp_orderreviewing";
      sqlCommand.Parameters.AddWithValue("@email", User.Identity.Name.ToString());
      //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);
      sqlCommand.Connection.Open();
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();
      SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
      DataSet ds = new DataSet();
      da.Fill(ds);
      conn.Close();
      if (ds.Tables[0].Rows.Count > 0)
      {
         GridView1.DataSource = ds;
         GridView1.DataBind();
      }
   }
   protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
   {
      GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
      Label lbldeleteid = (Label)row.FindControl("lblID");

      SqlCommand sqlCommand = new SqlCommand();
      if (row.Cells[4].Text.ToString() == "1")
      {
         lblMessage.Text = "Invalid, Order has Shipped";
      }
      else
      {
         sqlCommand.Connection = conn;
         sqlCommand.Connection.Open();

         sqlCommand.CommandText = "sp_orderreviewingUpdate";
         sqlCommand.Parameters.AddWithValue("@invoicenumber", int.Parse(row.Cells[1].Text));

         sqlCommand.CommandType = CommandType.StoredProcedure;
         sqlCommand.ExecuteNonQuery();
         sqlCommand.Connection.Close();
      }


      //SqlCommand cmd = new SqlCommand("delete FROM [dbo].Categories where Category_ID='" + row.Cells[0].Text + "'", conn);
      gvbind();
   }


   protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {
      GridView1.PageIndex = e.NewPageIndex;
      gvbind();
   }
}