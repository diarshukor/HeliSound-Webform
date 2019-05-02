using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_ProductManagement : System.Web.UI.Page
{
   SqlConnection conn =
            new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString.ToString());

   protected void Page_Load(object sender, EventArgs e)
   {
      //            SqlCommand cmd = new SqlCommand("Select * from [dbo].Categories", conn);
      SqlCommand sqlCommand = new SqlCommand("sp_getProduct", conn);

      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Connection = conn;
      sqlCommand.Connection.Open();

      SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
      DataSet ds = new DataSet();
      da.Fill(ds);
      foreach (DataTable table in ds.Tables)
      {
         foreach (DataRow row in table.Rows)
         {
            foreach (object item in row.ItemArray)
            {
               Debug.WriteLine(item);
            }
         }
      }
      try
      {
         thegrid.DataSource = ds.Tables[0];
         thegrid.DataBind();

      }catch(NullReferenceException a)
      {

      }
      finally
      {

      }
      sqlCommand.Connection.Close();
      

         }
   protected void thegrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
   {
      GridViewRow row = (GridViewRow)thegrid.Rows[e.RowIndex];
      Label lbldeleteid = (Label)row.FindControl("lblID");

      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;
      sqlCommand.CommandText = "sp_deletecategory";
      sqlCommand.Parameters.AddWithValue("@Category_ID", row.Cells[0].Text);
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Connection.Open();
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();
   }
   protected void thegrid_RowEditing(object sender, GridViewEditEventArgs e)
   {
      thegrid.EditIndex = e.NewEditIndex;
   }
   protected void thegrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
   {
      GridViewRow row = (GridViewRow)thegrid.Rows[e.RowIndex];
      TextBox txtname = (TextBox)row.Cells[0].Controls[0];
      TextBox textadd = (TextBox)row.Cells[1].Controls[0];
      thegrid.EditIndex = -1;
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;
      sqlCommand.CommandText = "sp_updatecategory";
      sqlCommand.Parameters.AddWithValue("@Description", textadd.Text);

      sqlCommand.CommandType = CommandType.StoredProcedure;

      //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);
      sqlCommand.Connection.Open();
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();
      //thegrid.DataBind();  
   }
   protected void thegrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {
      thegrid.PageIndex = e.NewPageIndex;

   }
   protected void thegrid_RowCancelingEdit(object sender, EventArgs a)
   {
      thegrid.EditIndex = -1;
   }

   protected void saveitem_Click(object sender, EventArgs e)
   {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;
      sqlCommand.Parameters.AddWithValue("@Name", Name.Text);
      sqlCommand.Parameters.AddWithValue("@Supplier", Supplier.Text);
      sqlCommand.Parameters.AddWithValue("@Category", Category.Text);
      sqlCommand.Parameters.AddWithValue("@Price", Price.Text);
      sqlCommand.Parameters.AddWithValue("@Status", Status.Text);
      sqlCommand.Parameters.AddWithValue("@Description", Description.Text);
      sqlCommand.CommandText = "sp_setNewProduct";
      sqlCommand.CommandType = CommandType.StoredProcedure;

      sqlCommand.Connection.Open();
      sqlCommand.ExecuteNonQuery();
      conn.Close();
      
   }
   protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
   { }
   protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
   {
      thegrid.EditIndex = e.NewEditIndex;
   }
   protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
   {
   }
   protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {
      thegrid.PageIndex = e.NewPageIndex;
   }
   protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
   {
      thegrid.EditIndex = -1;
   }
}