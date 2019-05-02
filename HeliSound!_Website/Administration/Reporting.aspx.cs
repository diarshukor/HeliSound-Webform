using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_Reporting : System.Web.UI.Page
{
   SqlConnection conn =
       new SqlConnection(ConfigurationManager.ConnectionStrings["db_connection"].ToString());
   protected void Page_Load(object sender, EventArgs e)
   {
      if (!IsPostBack) gvbind();

   }
   protected void gvbind()
   {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = conn;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "sp_reportsprocessFind";

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