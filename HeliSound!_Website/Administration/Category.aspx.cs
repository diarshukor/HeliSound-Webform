using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Category : System.Web.UI.Page
{
   SqlConnection conn =
       new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ToString());
   string description, category;
   protected void Page_Load(object sender, EventArgs e)
   {


      gvbind();
   }
   protected void gvbind()
   {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "sp_getallcategory";
      sqlCommand.Connection.Open();
      sqlCommand.ExecuteNonQuery();
      SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
      DataSet ds = new DataSet();
      da.Fill(ds);
      try
      {
         GridView1.DataSource = ds;
         GridView1.DataBind();

      }
      catch(NullReferenceException e)
      {
      }
      finally
      {
      }
      sqlCommand.Connection.Close();

   }
   protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
   {
      GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;

      sqlCommand.Connection.Open();

      sqlCommand.CommandText = "sp_deletecategory";
      sqlCommand.Parameters.AddWithValue("@Category_ID", row.Cells[2].Text);
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();
      //SqlCommand cmd = new SqlCommand("delete FROM [dbo].Categories where Category_ID='" + row.Cells[0].Text + "'", conn);
      gvbind();
   }
   protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
   {
      GridView1.EditIndex = e.NewEditIndex;
      if(!IsPostBack) gvbind();
   }

   protected void SaveUpdate(object sender, EventArgs e)
   {
      foreach(GridViewRow x in GridView1.Rows)
      {
         description = x.Cells[2].Text;
         category = x.Cells[3].Text;

      }
      GridView1.EditIndex = -1;
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;
      sqlCommand.CommandType = CommandType.StoredProcedure;

      sqlCommand.CommandText = "sp_updatecategory";
      sqlCommand.Parameters.AddWithValue("@description", description.ToString());
      sqlCommand.Parameters.AddWithValue("@category", category.ToString());
      sqlCommand.Parameters.AddWithValue("@categoryid", category.ToString());
      sqlCommand.Connection.Open();
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();
      gvbind();
   }
   protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {
      GridView1.PageIndex = e.NewPageIndex;
      gvbind();
   }
   protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
   {
      GridView1.EditIndex = -1;
      gvbind();
   }

   protected void saveitem_Click(object sender, EventArgs e)
   {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;
      sqlCommand.Parameters.AddWithValue("@Name", Name.Text);
      sqlCommand.Parameters.AddWithValue("@Supplier", Supplier.Text);
      sqlCommand.Parameters.AddWithValue("@Category", Category1.Text);
      sqlCommand.Parameters.AddWithValue("@Price", Price.Text);
      sqlCommand.Parameters.AddWithValue("@Status", Status.Text);
      sqlCommand.Parameters.AddWithValue("@Description", Description.Text);
      sqlCommand.CommandText = "sp_savecategory";
      sqlCommand.CommandType = CommandType.StoredProcedure;

      sqlCommand.Connection.Open();

      sqlCommand.ExecuteNonQuery();
      
      sqlCommand.Connection.Close();
      gvbind();

   }
}