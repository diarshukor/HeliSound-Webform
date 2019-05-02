using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_TrackOrders : System.Web.UI.Page
{
   SqlConnection conn =
          new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ToString());
   protected void Page_Load(object sender, EventArgs e)
   {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;
      sqlCommand.Connection.Open();
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "sp_TrackOrders";

      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();

      SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
      DataSet ds = new DataSet();
      da.Fill(ds);
      GridView1.DataSource = ds;
      GridView1.DataBind();
   }
   protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
   {
      try
      {
         GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
         if (double.Parse(row.Cells[5].Text.ToString()) == 1)
         {
            lblmessage.Text = "Already shipped";
         }
         else
         {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;


            sqlCommand.CommandText = "sp_deleteTrackOrdersDelete";
            sqlCommand.Parameters.AddWithValue("@invoicenumber", row.Cells[12].Text);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
         }
      }
      catch (Exception a)
      {

      }
      finally { }

      }
   
   protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
   {
      GridView1.EditIndex = e.NewEditIndex;
   }
   protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {
      GridView1.PageIndex = e.NewPageIndex;
   }

   protected void searchinvoice_Click(object sender, EventArgs e)
   {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;
      sqlCommand.Parameters.AddWithValue("@invoicenumber", enterinvoice.Text.ToString());
      sqlCommand.Parameters.AddWithValue("@email", User.Identity.Name.ToString());
      sqlCommand.CommandText = "sp_TrackOrdersSearch";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Connection.Open();


      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();

      SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
      DataSet ds = new DataSet();
      da.Fill(ds);
      GridView1.DataSource = ds;
      GridView1.DataBind();
   }




}