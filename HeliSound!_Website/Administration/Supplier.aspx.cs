using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Supplier : System.Web.UI.Page
{
   SqlConnection conn =
new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ToString());
   bool isDoubleName = false;
   protected void Page_Load(object sender, EventArgs e)
   {
      if (!IsPostBack) gvbind();

   }
   protected void gvbind()
   {
      //            SqlCommand cmd = new SqlCommand("Select * from [dbo].Categories", conn);
      SqlCommand sqlCommand = conn.CreateCommand();

      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "sp_getallsuppliers";
      //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);
      sqlCommand.Connection.Open();
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();

      SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
      DataSet ds = new DataSet();
      da.Fill(ds);
      if (ds.Tables[0].Rows.Count > 0)
      {
         try
         {
            GridView1.DataSource = ds;
            GridView1.DataBind();

         }
         catch(NullReferenceException a)
         {

         }
         finally
         {

         }
      }
   }
   protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
   {
      GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
      Label lbldeleteid = (Label)row.FindControl("lblID");

      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "sp_deletesupplier";
      sqlCommand.Parameters.AddWithValue("@name", row.Cells[0].Text);
      sqlCommand.Connection = conn;
      sqlCommand.Connection.Open();
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();
      gvbind();
   }
   protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
   {
      GridView1.EditIndex = e.NewEditIndex;
      gvbind();
   }
   protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
   {
      GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
      TextBox name = (TextBox)row.Cells[0].Controls[0];
      TextBox address = (TextBox)row.Cells[1].Controls[0];
      TextBox contact = (TextBox)row.Cells[2].Controls[0];
      TextBox telephone = (TextBox)row.Cells[3].Controls[0];
      TextBox status = (TextBox)row.Cells[4].Controls[0];
      GridView1.EditIndex = -1;

      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "sp_updatesuppliers1";
      sqlCommand.Connection = conn;
      sqlCommand.Parameters.AddWithValue("@name", name.Text);
      sqlCommand.Parameters.AddWithValue("@address", address.Text);
      sqlCommand.Parameters.AddWithValue("@contact", contact.Text);
      sqlCommand.Parameters.AddWithValue("@telephone", telephone.Text);
      sqlCommand.Parameters.AddWithValue("@status", status.Text);

      sqlCommand.CommandType = CommandType.StoredProcedure;

      //SqlCommand cmd = new SqlCommand("update [dbo].[Categories] set Description='" + textadd.Text.ToString()+"'where Category_ID='"+ txtname.Text.ToString() +"'", conn);
      sqlCommand.Connection.Open();
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();
      gvbind();
      //GridView1.DataBind();  
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
      foreach (GridViewRow r in GridView1.Rows)
      {
         if (r.Cells[0].Text.ToString() == addname.Text.ToString())
         {
            isDoubleName = true;
         }
      }
      if (!isDoubleName)
      {
         sqlCommand.Parameters.AddWithValue("@name", addname.Text);
         sqlCommand.Parameters.AddWithValue("@address", addaddress.Text);
         sqlCommand.Parameters.AddWithValue("@contact", addcontact.Text);
         sqlCommand.Parameters.AddWithValue("@telephone", addtelephone.Text);
         sqlCommand.Parameters.AddWithValue("@status", addstatus.Text);
         sqlCommand.Parameters.AddWithValue("@role_id", addrole_id.Text);
         sqlCommand.Parameters.AddWithValue("@category", addcategory.Text);
         sqlCommand.CommandText = "sp_savesuppliers";
         sqlCommand.CommandType = CommandType.StoredProcedure;

         sqlCommand.Connection.Open();
         sqlCommand.ExecuteNonQuery();
         sqlCommand.Connection.Close();

         //            SqlCommand sqlCommand = new SqlCommand("Insert INTO Categories(Description) VALUES('" + additem.Text.ToString()+"');", conn);
      }
      isDoubleName = false;
      gvbind();

   }
}