using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Products : System.Web.UI.Page
{
   // status positive products only
   private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ToString());

   protected void Page_Load(object sender, EventArgs e)
   {

         SqlCommand sqlCommand = new SqlCommand();
         sqlCommand.Connection = conn;
         sqlCommand.CommandType = CommandType.StoredProcedure;

         sqlCommand.CommandText = "sp_infoforProducts";

         sqlCommand.Connection.Open();
         sqlCommand.ExecuteNonQuery();
         sqlCommand.Connection.Close();
         SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
         DataSet ds2 = new DataSet();
         da.Fill(ds2);
         GridView1.DataSource = ds2;
         GridView1.DataBind();
      }
      
   
   protected void saveitem_Click(object sender, EventArgs e)
   {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;

      //sqlCommand.Parameters.AddWithValue("@name", );
      sqlCommand.Parameters.AddWithValue("@name", addfirstname.Text);
      sqlCommand.Parameters.AddWithValue("@address", addaddress.Text);
      sqlCommand.Parameters.AddWithValue("@contact", addcontact.Text);
      sqlCommand.Parameters.AddWithValue("@telephone", addtelephone.Text);
      sqlCommand.Parameters.AddWithValue("@status", addstatus.Text);
      sqlCommand.Parameters.AddWithValue("@role_id", addrole_id.Text);
      sqlCommand.CommandText = "sp_saveProduct";
      sqlCommand.CommandType = CommandType.StoredProcedure;

      sqlCommand.Connection.Open();
      sqlCommand.ExecuteNonQuery();
      sqlCommand.Connection.Close();

      //            SqlCommand sqlCommand = new SqlCommand("Insert INTO Categories(Description) VALUES('" + additem.Text.ToString()+"');", conn);


   }

   
}